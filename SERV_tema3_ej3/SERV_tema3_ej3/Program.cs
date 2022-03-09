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
{
    class Program
    {
        static object l = new object();
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
                //messageList.Add(writer);

                msg = "Te damos la bienvenida";
                writer.WriteLine(msg);
                writer.Flush();

                do
                {
                    try
                    {
                        msg = "Escribe tu nombre de usuario (no puede ser repetido)";
                        writer.WriteLine(msg);
                        writer.Flush();
                        username = reader.ReadLine();
                    }
                    catch (IOException)
                    {

                    }

                    lock (l)
                    {
                        foreach (Cliente clientName in clientList)
                        {
                            if (username.Equals(clientName.Nombre) || username == null || clientName.Nombre == null)
                            {
                                repetirUsername = true;
                            }
                            else
                            {
                                repetirUsername = false;
                            }
                        }
                    }

                } while (repetirUsername || username == null);

                cliente = CreaClientes(username, endpointCliente, socketCliente, writer);

                lock (l)
                {
                    clientList.Add(cliente);

                    if (cliente.WriterMsg == null)
                    {
                        foreach (Cliente client in clientList)
                        {
                            if (endpointCliente.Port != client.EndPoint.Port)
                            {
                                msg = $"{endpointCliente.Address}:{endpointCliente.Port} se ha desconectado.";
                                client.WriterMsg.WriteLine(msg);
                                client.WriterMsg.Flush();
                            }
                        }
                        clientList.Remove(cliente);
                        running = false;
                    }

                    if (cliente.Nombre != null)
                    {
                        foreach (Cliente client in clientList)
                        {
                            client.WriterMsg.WriteLine("Se ha conectado {0} ({1})", cliente.Nombre, cliente.EndPoint);
                            client.WriterMsg.Flush();
                        }
                    }
                }

                while (running)
                {
                    try
                    {
                        msg = reader.ReadLine();

                        if (msg != null)
                        {
                            lock (l)
                            {
                                switch (msg)
                                {
                                    case "#salir":
                                        foreach (Cliente client in clientList)
                                        {
                                            if (endpointCliente.Port != client.EndPoint.Port)
                                            {
                                                msg = $"{endpointCliente.Address}:{endpointCliente.Port} se ha desconectado.";
                                                client.WriterMsg.WriteLine(msg);
                                                client.WriterMsg.Flush();
                                            }
                                        }
                                        clientList.Remove(cliente);
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
                                        foreach (Cliente client in clientList) // Si no es ni #salir ni #lista muestra el mensaje enviado
                                        {
                                            if (writer != client.WriterMsg && !client.WriterMsg.Equals("")) // Se muestra a todos excepto al propio que lo envía
                                            {
                                                client.WriterMsg.WriteLine($"{cliente.Nombre}@{cliente.EndPoint.Address}:{cliente.EndPoint.Port} dice: \"{msg}\"");
                                                client.WriterMsg.Flush();
                                            }
                                        }
                                        break;
                                }
                            }
                        } else
                        {
                            running = false;
                        }
                    }
                    catch (IOException)
                    {
                        break;
                    }
                }
            }

            clientList.Remove(cliente);
            socketCliente.Close();
        }

        static Cliente CreaClientes(string username, IPEndPoint endPoint, Socket socket, StreamWriter writerMsg)
        {
            return new Cliente(username, endPoint, socket, writerMsg);
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