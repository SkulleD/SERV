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
  // En cuanto un cliente se desconecta ya no va
    class Program
    {
        static object l = new object();
        static List<StreamWriter> messageList = new List<StreamWriter>();
        static List<Cliente> clientList = new List<Cliente>();

        static void Hilo(object socket)
        {
            Cliente cliente;
            bool running = true;
            string msg = "";
            string username = "";
            bool repetirUsername = false;
            Socket socketCliente = (Socket)socket;
            IPEndPoint endpointCliente = (IPEndPoint)socketCliente.RemoteEndPoint;

            using (NetworkStream stream = new NetworkStream(socketCliente))
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                messageList.Add(writer);

                msg = "Te damos la bienvenida";
                writer.WriteLine(msg);
                writer.Flush();

                do
                {
                    msg = "Escribe tu nombre de usuario (no puede ser repetido)";
                    writer.WriteLine(msg);
                    writer.Flush();
                    username = reader.ReadLine();

                    foreach (Cliente clientName in clientList)
                    {
                        if (clientName.Nombre.Equals(username))
                        {
                            repetirUsername = true;
                        }
                        else
                        {
                            repetirUsername = false;
                        }
                    }

                } while (repetirUsername);

                cliente = CreaClientes(username, endpointCliente, socketCliente);
                clientList.Add(cliente);

                foreach (StreamWriter writerMsg in messageList)
                {
                    writerMsg.WriteLine("Se ha conectado {0} ({1})", cliente.Nombre, cliente.EndPoint);
                    writerMsg.Flush();
                }

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
                                        for (int i = clientList.Count - 1; i >= 0; i--)
                                        {
                                            if (endpointCliente.Port == clientList[i].EndPoint.Port)
                                            {
                                                foreach (StreamWriter writerMsg in messageList)
                                                {
                                                    msg = $"{endpointCliente.Address}:{endpointCliente.Port} se ha desconectado.";
                                                    writerMsg.WriteLine(msg);
                                                    writerMsg.Flush();
                                                }

                                                clientList.RemoveAt(i);
                                            }
                                        }

                                        running = false;
                                        break;
                                    case "#lista":
                                        foreach (Cliente client in clientList)
                                        {
                                            msg = $"Username: {client.Nombre} IP: {client.EndPoint.Address} Puerto: {client.EndPoint.Port}";
                                            writer.WriteLine(msg);
                                            writer.Flush();
                                        }
                                        break;
                                    default:
                                        foreach (StreamWriter writerMsg in messageList) // Si no es ni #salir ni #lista muestra el mensaje enviado
                                        {
                                            if (writer != writerMsg) // Se muestra a todos excepto al propio que lo envía
                                            {
                                                writerMsg.WriteLine($"{cliente.Nombre}@{cliente.EndPoint.Address}:{cliente.EndPoint.Port} dice: \"{msg}\"");
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
                Console.ReadLine();

            }

            socketCliente.Close();
        }

        static Cliente CreaClientes(string username, IPEndPoint endPoint, Socket socket)
        {
            return new Cliente(username, endPoint, socket);
        }

        static void Main(string[] args)
        {
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