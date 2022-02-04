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
    public partial class Form1 : Form
    {
        string ip;
        int port;
        Socket socket;
        IPEndPoint endPoint;

        public Form1()
        {
            InitializeComponent();
        }

        public void Connection()
        {
            try
            {

            }
            catch (SocketException e)
            {
                MessageBox.Show($"Error connection: {e.Message}\n Error code: {(SocketError)e.ErrorCode}({e.ErrorCode})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentOutOfRangeException || ex is OverflowException)
            {

            }
        }
    }
}