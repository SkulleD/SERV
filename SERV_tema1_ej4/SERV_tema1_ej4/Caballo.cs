using System;
using System.Collections.Generic;
using System.Text;

namespace SERV_tema1_ej4
{
    class Caballo
    {
        public int Position { set; get; }

        public Caballo()
        {
            this.Position = 0;
        }

        public void Correr()
        {
            Random random = new Random();
            this.Position = random.Next(1, 4);
        }
    }
}