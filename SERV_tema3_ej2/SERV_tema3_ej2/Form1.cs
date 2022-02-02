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
        bool connected = false; // Mientras sea true, los botones están activos
        bool btnClick = false; // Mientras sea true, la conexión permanece activa
        IPEndPoint ipEndPoint;
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


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
                ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 45);

                socket.Connect(ipEndPoint);
                connected = true;
                lbl_Info.Text = "User connected!";
            }
            catch (SocketException e)
            {
                MessageBox.Show($"Error connection: {e.Message}\n Error code: {(SocketError)e.ErrorCode}({e.ErrorCode})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (FormatException e)
            {
                MessageBox.Show("Not valid IP!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connection();

            if (connected)
            {
                btnAdd.Visible = true;
                btnList.Visible = true;
            }

            while (!btnClick)
            {

            }

            lbl_Info.Text = "(!) User disconnected";
            btnAdd.Visible = false;
            btnList.Visible = false;
            connected = false;
            socket.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string msg = "add";
            WriteMessage(msg);
            btnClick = true;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string msg = "list";
            WriteMessage(msg);
            btnClick = true;
        }

        private void WriteMessage(string msg)
        {
            string msgServer;

            using (NetworkStream netStream = new NetworkStream(socket))
            using (StreamReader reader = new StreamReader(netStream))
            using (StreamWriter writer = new StreamWriter(netStream))
            {
                writer.WriteLine($"User {txtUser.Text}");

                msgServer = reader.ReadLine();

                writer.WriteLine(msg);
                writer.Flush();
            }
        }
    }
}
