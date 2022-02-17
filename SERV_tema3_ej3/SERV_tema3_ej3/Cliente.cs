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
        private IPEndPoint endPoint;
        private Socket socketCliente;

        public Cliente(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get; set; }
    }
}
