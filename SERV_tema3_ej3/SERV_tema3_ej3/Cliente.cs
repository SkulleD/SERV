using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SERV_tema3_ej3
{
    class Cliente
    {
        private string nombre = "";
        public string Nombre { get; set; }
        private IPEndPoint endPoint;
        public IPEndPoint EndPoint { get; set; }
        private Socket socketC;
        public Socket SocketC { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nombre, IPEndPoint endPoint, Socket socketC)
        {
            this.Nombre = nombre;
            this.EndPoint = endPoint;
            this.SocketC = socketC;
        }
    }
}
