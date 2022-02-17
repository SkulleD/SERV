using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SERV_tema3_ej3
{ // PROBLEMAS:
  // Al enviar un mensaje también aparece el enviado anteriormente
  // En cuanto un cliente se desconecta ya no es posible usar los demás clientes
    class Program
    {
        static object l = new object();
        static IPEndPoint endpoint;
        static bool running = true;
        static List<StreamWriter> messageList = new List<StreamWriter>();
        static List<Socket> socketList = new List<Socket>();

        static void Hilo(object socket)
        {
            string msg = "";
            Socket socketCliente = (Socket)socket;
            IPEndPoint endpointCliente = (IPEndPoint)socketCliente.RemoteEndPoint;
            Console.WriteLine("Se ha conectado {0} en puerto {1}", endpointCliente.Address, endpointCliente.Port);

            using (NetworkStream stream = new NetworkStream(socketCliente))
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                messageList.Add(writer);
                socketList.Add(socketCliente);

                msg = "Funcionando";
                writer.WriteLine(msg);
                writer.Flush();

                while (running)
                {
                    try
                    {
                        msg = reader.ReadLine();
                        writer.Flush();

                        if (msg != null)
                        {
                            lock (l)
                            {
                                switch (msg)
                                {
                                    case "#salir":
                                        foreach (StreamWriter writerMsg in messageList)
                                        {
                                            messageList.Remove(writerMsg);
                                        }

                                        foreach (Socket socketC in socketList)
                                        {
                                            socketList.Remove(socketC);
                                        }
                                        break;
                                    case "#lista":
                                        foreach (Socket socketC in socketList)
                                        {
                                            msg = $"IP: {endpointCliente.Address} Puerto: {endpointCliente.Port}";
                                            writer.WriteLine(msg);

                                            if (socketCliente.AddressFamily == socketC.AddressFamily) // Solo se muestran en el cliente que lo pone
                                            {
                                                writer.Flush();
                                            }
                                        }
                                        break;
                                    default:
                                        foreach (StreamWriter writerMsg in messageList)
                                        {
                                            writerMsg.WriteLine($"{endpointCliente.Address} {endpointCliente.Port} dice: \"{msg}\"");

                                            if (writer != writerMsg) // Se muestra a todos excepto al propio que lo envía
                                            {
                                                writerMsg.Flush();
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    catch (IOException)
                    {
                        break;
                    }
                }
            }

            if (!running)
            {
                Console.WriteLine($"Cerrada conexión con {endpointCliente.Address}:{endpointCliente.Port}");
                Console.ReadLine();

            }

            socketCliente.Close();
        }

        static void Main(string[] args)
        {
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
                        endpoint = new IPEndPoint(IPAddress.Any, 3560);
                        socket.Bind(endpoint);
                    }

                    socket.Listen(30);
                    Console.WriteLine($"Server listening at port: {endpoint.Port}");

                    while (true)
                    {
                        Socket socketCliente = socket.Accept();
                        Thread hilo = new Thread(Hilo);
                        hilo.Start(socketCliente);
                    }
                }
            }
        }
    }
}