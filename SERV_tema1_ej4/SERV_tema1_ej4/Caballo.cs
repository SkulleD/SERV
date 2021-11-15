using System;
using System.Collections.Generic;
using System.Text;

namespace SERV_tema1_ej4
{
    class Caballo
    {
        public int Position { set; get; }
        public string Name{ set; get; }
        public int Y { set; get; }

        public Caballo(string name, int y)
        {
            this.Position = 0;
            this.Name = name;
            this.Y = y;
        }

        public int Correr()
        {
            Random random = new Random();
            this.Position += random.Next(1, 2);
            if (Position > 50)
            {
                Position = 50;
            }
            return Position;
        }
    }
}