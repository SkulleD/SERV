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
        static IPEndPoint endpoint;
        static Socket socket;
        static string ip;
        static int port;
        static bool running = true;

        static void Hilo(object socket)
        {
            string msg = "";
            Socket socketCliente = (Socket)socket;
            Console.WriteLine("Se ha conectado {0} en puerto {1}", endpoint.Address, endpoint.Port);
            
            using (NetworkStream stream = new NetworkStream(socketCliente))
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {

            }
        }

        static void Main(string[] args)
        {
            while (running)
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

                    while (running)
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