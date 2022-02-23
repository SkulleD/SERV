using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SERV_tema3_ej3
{
    class Cliente
    {
        public string Nombre { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public Socket SocketC { get; set; }
        public StreamWriter WriterMsg { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nombre, IPEndPoint endPoint, Socket socketC)
        {
            this.Nombre = nombre;
            this.EndPoint = endPoint;
            this.SocketC = socketC;
            //this.WriterMsg = writerMsg;
        }
    }
}
