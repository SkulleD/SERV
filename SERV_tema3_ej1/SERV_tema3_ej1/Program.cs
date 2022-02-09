using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SERV_tema3_ej1
{
    class Program
    {
        static IPEndPoint endPoint;
        static bool running = true;

        static void Main(string[] args)
        {
            while (running)
            {
                endPoint = new IPEndPoint(IPAddress.Any, 11037);

                using (Socket socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Bind(endPoint);
                    socket.Listen(10);
                    Console.WriteLine($"Server listening. Port: {endPoint.Port}");
                    Socket socketClient = socket.Accept();
                    IPEndPoint endPointClient = (IPEndPoint)socketClient.RemoteEndPoint;
                    Console.WriteLine("Client {0} connected at port {1}", endPointClient.Address, endPointClient.Port);

                    using (NetworkStream stream = new NetworkStream(socketClient))
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        string bienvenida = "You are now in Alvaro's amazing Time and Date information server!";

                        writer.WriteLine(bienvenida);
                        writer.Flush();

                        string msg = "";

                        try
                        {
                            msg = reader.ReadLine();

                            if (msg != null)
                            {
                                msg = msg.ToUpper();

                                switch (msg)
                                {
                                    case "HORA":
                                        msg = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                                        SendMessage();
                                        break;
                                    case "FECHA":
                                        msg = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                                        SendMessage();
                                        break;
                                    case "TODO":
                                        msg = DateTime.Now.ToString();
                                        SendMessage();
                                        break;
                                    case "APAGAR":
                                        Console.WriteLine("Server closed");
                                        running = false;
                                        socket.Close();
                                        break;
                                    default:
                                        msg = "Unknown command";
                                        SendMessage();
                                        break;
                                }
                            }
                        }
                        catch (IOException e)
                        {
                            msg = null;
                        }

                        void SendMessage()
                        {
                            Console.WriteLine(msg);
                            writer.WriteLine(msg);
                            writer.Flush();
                        }

                        Console.WriteLine("Client disconnected");
                        socketClient.Close();
                    }
                }
            }
        }
    }
}