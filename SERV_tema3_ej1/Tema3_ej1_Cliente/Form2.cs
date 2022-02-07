using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema3_ej1_Cliente
{
    public partial class Form2 : Form
    {
        public string ip;
        public int port;
        Socket socket;
        IPEndPoint endPoint;
        string msg;

        public Form2(string ip, int port)
        {
            InitializeComponent();
            this.ip = ip;
            this.port = port;
        }

        public void Connection()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                lblResult.Text = ip;

                socket.Connect(endPoint);
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
        }
    }
}
