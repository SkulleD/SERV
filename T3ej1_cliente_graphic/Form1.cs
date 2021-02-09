using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ej1_cliente_graphic
{
    public partial class Form1 : Form
    {
        const string IP_SERVER = "127.0.0.1";
        string msg;
        string userMsg;

        IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), 31416);
        Socket server = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream, ProtocolType.Tcp);

        StreamReader sr;
        StreamWriter sw;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                server.Connect(ie);
            }
            catch (SocketException eee)
            {
                return;
            }

            NetworkStream ns = new NetworkStream(server);
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);

            while (true)
            {
                userMsg = Console.ReadLine();

                if (userMsg == "salir")
                {
                    break;
                }
            }

            sr.Close();
            sw.Close();
            ns.Close();
            server.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw.WriteLine("HORA");
            sw.Flush();
            msg = sr.ReadLine();
            label.Text = msg;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sw.WriteLine(userMsg);
            sw.Flush();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sw.WriteLine(userMsg);
            sw.Flush();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sw.WriteLine(userMsg);
            sw.Flush();
        }
    }
}
