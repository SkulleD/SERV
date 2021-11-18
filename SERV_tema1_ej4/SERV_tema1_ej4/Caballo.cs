using System;
using System.Collections.Generic;
using System.Text;

namespace SERV_tema1_ej4
{
    class Caballo
    {
        public int Position { set; get; }
        public int Number{ set; get; }
        public int Y { set; get; }
        public int Finishline { set; get; }

        public Caballo(int number, int y)
        {
            this.Position = 0;
            this.Number = number;
            this.Y = y;
            this.Finishline = 30; // Length of the race
        }

        public int Correr()
        {
            Random random = new Random();
            this.Position += random.Next(1, 2);
            if (Position > Finishline)
            {
                Position = Finishline;
            }
            return Position;
        }
    }
}