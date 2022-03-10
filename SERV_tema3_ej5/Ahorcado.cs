using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SERV_tema3_ej5
{
    class Ahorcado
    {
        static object l = new object();
        bool running = true;

        public void Hilo(object sClient)
        {
            string directorioActual = Directory.GetCurrentDirectory();
            string ruta = directorioActual + "\\palabras.txt";
            string rutaRecords = directorioActual + "\\records.txt";
            string[] listaPalabras = { };
            char[] charsPalabraJuego = { };
            string msg;
            string palabraJuego = "";
            string sendPalabra = "";
            string sendRecord = "";
            string[] opcionSend = { };
            string playerName = "";
            string playerTime = "";
            Socket socketCliente = (Socket)sClient;
            IPEndPoint endPointClient = (IPEndPoint)socketCliente.RemoteEndPoint;


            using (NetworkStream stream = new NetworkStream(socketCliente))
            using (StreamWriter writer = new StreamWriter(stream))
            using (StreamReader reader = new StreamReader(stream))
            {
                // Se introduce la ruta de un fichero para obtener su contenido
                msg = "Introduce ruta del fichero de donde quieres sacar la palabra";
                EnviaMensaje(socketCliente, msg);

                do
                {
                    ruta = "C:\\";

                    try
                    {
                        ruta = ruta + reader.ReadLine();

                        // Se consiguen el archivo y las palabras contenidas en el mismo
                        if (File.Exists(ruta))
                        {
                            StreamReader reader2;

                            lock (l)
                            {
                                using (reader2 = new StreamReader(ruta))
                                {
                                    listaPalabras = reader2.ReadToEnd().Split(' ', '\r', '\n');
                                }
                            }
                        }

                        else
                        {
                            msg = "Esa ruta no existe!";
                            EnviaMensaje(socketCliente, msg);
                        }
                    }
                    catch (IOException)
                    {

                    }
                } while (!File.Exists(ruta));

                while (running)
                {
                    try
                    {
                        // La persona jugando elige uno de los comandos
                        msg = "Comandos: getword, sendword (palabra), getrecords, " +
                              "sendrecord (record), closeserver (clave).";
                        writer.WriteLine(msg);
                        writer.Flush();

                        msg = reader.ReadLine();

                        if (msg != null)
                        {
                            msg = msg.ToLower();

                            // Comprueba si es comando es sendword + palabra
                            if (msg.StartsWith("sendword"))
                            {
                                opcionSend = msg.Split(' ');

                                if (opcionSend.Length == 2)
                                {
                                    msg = opcionSend[0]; // sendword
                                    sendPalabra = opcionSend[1]; // Palabra
                                }

                            }

                            // Comprueba si es comando es sendrecord + record
                            if (msg.StartsWith("sendrecord"))
                            {
                                opcionSend = msg.Split(' ');

                                if (opcionSend.Length == 3)
                                {
                                    if (opcionSend[2].Length > 3 && opcionSend[1].Equals("") && opcionSend[2].Equals(""))
                                    {
                                        msg = "Los parametros no son validos";
                                    }
                                    else
                                    {
                                        msg = opcionSend[0]; // sendrecord
                                        sendRecord = $"{opcionSend[1]} {opcionSend[2].ToUpper()} {endPointClient.Address}"; // Tiempo Nombre IP
                                    }
                                }
                            }

                            switch (msg)
                            {
                                case "getword": // getword
                                    Random rand = new Random();
                                    int contPistas = 0;
                                    bool pistaON = false;

                                    int valorRand = rand.Next(0, listaPalabras.Length + 1);

                                    for (int i = 0; i < listaPalabras.Length; i++)
                                    {
                                        // Comprueba que la palabra que toca no sea cadena vacía
                                        if (i == valorRand && listaPalabras[i].Length >= 3)
                                        {
                                            palabraJuego = listaPalabras[i].ToLower();

                                            // Se crea un array con los caracteres de la palabra para más tarde dar pistas
                                            charsPalabraJuego = palabraJuego.ToCharArray();
                                        }
                                    }

                                    // Comienza el juego
                                    msg = "La palabra a adivinar ha sido asignada, comienza el juego.";
                                    EnviaMensaje(socketCliente, msg);
                                    msg = $"La palabra tiene una longitud de {palabraJuego.Length} caracteres";
                                    EnviaMensaje(socketCliente, msg);

                                    do
                                    {
                                        contPistas++;
                                        pistaON = false; // Para que a veces no salgan 2 mensajes en vez de 1

                                        // Se van dando pistas de las letras que contiene la palabra de vez en cuando
                                        if (contPistas % 2 == 0)
                                        {
                                            for (int i = 0; i < charsPalabraJuego.Length; i++)
                                            {
                                                if (i == rand.Next(0, charsPalabraJuego.Length) && !pistaON)
                                                {
                                                    msg = $"La palabra contiene la siguiente letra: {charsPalabraJuego[i]}";
                                                    EnviaMensaje(socketCliente, msg);
                                                    pistaON = true;
                                                }
                                            }
                                        }
                                    } while (reader.ReadLine() != palabraJuego);

                                    // La palabra es adivinada
                                    msg = $"Felicidades, has adivinado la palabra, la cual era \"{palabraJuego}\"!";
                                    EnviaMensaje(socketCliente, msg);
                                    msg = "Por favor, escribe tu tiempo total y tu nombre (3 cifras maximo)";
                                    EnviaMensaje(socketCliente, msg);

                                    do
                                    {
                                        msg = "Tiempo total:";
                                        EnviaMensaje(socketCliente, msg);
                                        playerTime = reader.ReadLine();
                                    } while (playerTime.Equals(""));


                                    do
                                    {
                                        msg = "Nombre (3 cifras maximo):";
                                        EnviaMensaje(socketCliente, msg);
                                        playerName = reader.ReadLine();
                                    } while (playerName.Length > 3 || playerName.Equals(""));

                                    StreamWriter writer2;

                                    // Se añade el récord al archivo de récords
                                    try
                                    {
                                        lock (l)
                                        {
                                            using (writer2 = new StreamWriter(rutaRecords, true))
                                            {
                                                writer2.Write($"{playerTime} {playerName.ToUpper()} {endPointClient.Address}\r\n");
                                            }
                                        }
                                    }
                                    catch (Exception ex) when (ex is UnauthorizedAccessException || ex is IOException)
                                    {

                                    }

                                    break;

                                case "sendword": // sendword (palabra)
                                    StreamWriter writerPalabra;

                                    try
                                    {
                                        using (writerPalabra = new StreamWriter(ruta, true))
                                        {
                                            writerPalabra.Write($"\r\n{sendPalabra}");
                                        }

                                        msg = $"La palabra \"{sendPalabra}\" ha sido añadida.";
                                        EnviaMensaje(socketCliente, msg);
                                    }
                                    catch (IOException)
                                    {

                                    }

                                    break;

                                case "getrecords": // getrecords
                                    try
                                    {
                                        StreamReader readerRecords;

                                        lock (l)
                                        {
                                            using (readerRecords = new StreamReader(rutaRecords))
                                            {
                                                msg = readerRecords.ReadToEnd();
                                            }
                                        }
                                    }
                                    catch (IOException)
                                    {

                                    }

                                    EnviaMensaje(socketCliente, msg);
                                    break;

                                case "sendrecord": // sendrecords (récord)
                                    StreamWriter writerRecords;

                                    try
                                    {
                                        lock (l)
                                        {
                                            using (writerRecords = new StreamWriter(rutaRecords, true))
                                            {
                                                writerRecords.Write($"\r\n{sendRecord}");
                                            }

                                            msg = $"El record \"{sendRecord}\" ha sido añadida.";
                                            EnviaMensaje(socketCliente, msg);
                                        }
                                    }

                                    catch (IOException)
                                    {

                                    }
                                    break;

                                case "closeserver": // closeserver (clave)
                                    lock (l)
                                    {
                                        // El servidor es apagado para todos
                                        running = false;
                                    }
                                    break;

                                default:
                                    msg = "Esa no es una opcion valida.";
                                    EnviaMensaje(socketCliente, msg);
                                    break;
                            }
                        }
                    }
                    catch (IOException)
                    {

                    }
                }

            }

            socketCliente.Close();
        }

        public void EnviaMensaje(Socket socketCliente, string msg)
        {
            try
            {
                using (NetworkStream stream = new NetworkStream(socketCliente))
                using (StreamWriter writer = new StreamWriter(stream))
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(msg);
                    writer.WriteLine(msg);
                    writer.Flush();
                }
            }
            catch (IOException)
            {

            }

        }

        static void Main(string[] args)
        {
            Ahorcado servidor = new Ahorcado();
            IPEndPoint endpoint;

            while (true)
            {
                endpoint = new IPEndPoint(IPAddress.Any, 4242);
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    try
                    {
                        socket.Bind(endpoint);
                    }
                    catch (SocketException e) when (e.ErrorCode == (int)SocketError.AddressAlreadyInUse)
                    {
                        endpoint = new IPEndPoint(IPAddress.Any, 5656);
                        socket.Bind(endpoint);
                    }

                    socket.Listen(20);
                    Console.WriteLine("Servidor escuchando...");

                    while (true)
                    {
                        Socket sClient = socket.Accept();
                        Thread hilo = new Thread(servidor.Hilo);
                        hilo.Start(sClient);
                    }
                }
            }
        }
    }
}