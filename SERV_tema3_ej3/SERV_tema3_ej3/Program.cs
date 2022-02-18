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
  // En cuanto un cliente se desconecta ya no es posible usar los demás clientes
    class Program
    {   
        static object l = new object();
        static IPEndPoint endpoint;
        static bool running = true;
        static List<StreamWriter> messageList = new List<StreamWriter>();
        static List<Cliente> clientList = new List<Cliente>();

        static void Hilo(object socket)
        {
            Cliente cliente;
            string msg = "";
            string username = "";
            Socket socketCliente = (Socket)socket;
            IPEndPoint endpointCliente = (IPEndPoint)socketCliente.RemoteEndPoint;

            using (NetworkStream stream = new NetworkStream(socketCliente))
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                messageList.Add(writer);

                msg = "Escribe tu nombre de usuario";
                writer.WriteLine(msg);
                writer.Flush();
                username = reader.ReadLine();

                cliente = CreaClientes(username, endpointCliente, socketCliente);
                clientList.Add(cliente);
                writer.WriteLine("Se ha conectado {0} ({1})", cliente.Nombre, cliente.EndPoint);
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

                                        foreach (Cliente client in clientList)
                                        {
                                            clientList.Remove(client);
                                        }
                                        break;
                                    case "#lista":
                                        foreach (Cliente client in clientList)
                                        {
                                            msg = $"Username: {client.Nombre} IP: {client.EndPoint.Address} Puerto: {client.EndPoint.Port}";
                                            writer.WriteLine(msg);

                                            if (socketCliente.AddressFamily == client.SocketC.AddressFamily) // Solo se muestran en el cliente que lo pone
                                            {
                                                writer.Flush();
                                            }
                                        }
                                        break;
                                    default:
                                        foreach (StreamWriter writerMsg in messageList) // Si no es ni #salir ni #lista muestra el mensaje enviado
                                        {
                                            writerMsg.WriteLine($"{cliente.Nombre}@{cliente.EndPoint.Address} dice: \"{msg}\"");

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

        static Cliente CreaClientes(string username, IPEndPoint endPoint, Socket socket)
        {
            return new Cliente(username, endPoint, socket);
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