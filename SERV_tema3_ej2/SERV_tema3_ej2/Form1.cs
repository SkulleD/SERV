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

namespace SERV_tema3_ej2
{
    public partial class Form1 : Form
    {
        string ip;
        int port;
        bool addOrList = false; // Determina lo que hace WriteMessage() al pulsar uno de los botones
        Socket socket;
        IPEndPoint ipEndPoint;


        public Form1()
        {
            InitializeComponent();
        }

        private void Connection()
        {
            try
            {
                ip = txtIP.Text;
                port = int.Parse(txtPort.Text);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                socket.Connect(ipEndPoint);

            }
            catch (SocketException e)
            {
                MessageBox.Show($"Error connection: {e.Message}\n Error code: {(SocketError)e.ErrorCode}({e.ErrorCode})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentOutOfRangeException || ex is OverflowException)
            {

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Connection();
            string msg = ((Button)sender).Text.ToLower();
            WriteMessage(msg);
        }

        private void WriteMessage(string msg)
        {
            string msgServer;

            try
            {
                using (NetworkStream netStream = new NetworkStream(socket))
                using (StreamReader reader = new StreamReader(netStream))
                using (StreamWriter writer = new StreamWriter(netStream))
                {
                    writer.WriteLine($"User {txtUser.Text}");
                    writer.Flush();

                    msgServer = reader.ReadLine();

                    if (msg.Contains("add"))
                    {
                        writer.WriteLine(msg);
                        writer.Flush();
                    }
                    else
                    {
                        writer.WriteLine(msg);
                        writer.Flush();

                        while (reader.ReadLine() != null)
                        {
                            txtList.Text += reader.ReadLine();
                            txtList.Text += Environment.NewLine;
                        }
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentNullException)
            {
                MessageBox.Show("Not valid parameters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}