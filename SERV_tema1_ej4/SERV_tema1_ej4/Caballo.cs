using System;
using System.Collections.Generic;
using System.Text;

namespace SERV_tema1_ej4
{
    class Caballo
    {
        public int Position { set; get; }
        public string Name{ set; get; }

        public Caballo(string name)
        {
            this.Position = 0;
            this.Name = name;
        }

        public int Correr()
        {
            Random random = new Random();
            this.Position += random.Next(1, 2);
            return Position;
        }
    }
}