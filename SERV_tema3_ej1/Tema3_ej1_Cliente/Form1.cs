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

namespace Tema3_ej1_Cliente
{
    public partial class Form1 : Form
    {
        public string ip = "192.168.22.32";
        public int port = 242;
        Socket socket;
        IPEndPoint endPoint;
        Form2 form2 = new Form2();
        DialogResult res;

        public Form1()
        {
            InitializeComponent();
            lblResult.Text = "Awaiting command...";
        }

        public void Connection()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                socket.Connect(endPoint);
            }
            catch (SocketException e)
            {
                MessageBox.Show($"Error connection: {e.Message}\n Error code: {(SocketError)e.ErrorCode}({e.ErrorCode})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentOutOfRangeException || ex is OverflowException)
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Connection();
            string msg = ((Button)sender).Text.ToUpper();
            SendCommand(msg);
        }

        private void SendCommand(string msg)
        {
            try
            {
                using (NetworkStream stream = new NetworkStream(socket))
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    reader.ReadLine();

                    writer.WriteLine(msg);
                    writer.Flush();

                    lblResult.Text = reader.ReadLine(); // Sale el resultado del comando en la label
                    socket.Close();
                }
            }
            catch (Exception ex) when (ex is IOException || ex is ArgumentNullException)
            {

            }
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            res = form2.ShowDialog();

            if (res == DialogResult.OK)
            {
                ip = form2.txtIP.Text;
                port = int.Parse(form2.Text.ToString());
            }
        }
    }
}