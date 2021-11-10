using System;
using System.Threading;

namespace SERV_tema1_ej4
{
    class Program
    {
        static Caballo h1 = new Caballo();
        static Caballo h2 = new Caballo();
        static Caballo h3 = new Caballo();
        static Caballo h4 = new Caballo();
        static Caballo h5 = new Caballo();

        Caballo[] caballos = { h1, h2, h3, h4, h5 };

        Thread correr1;
        Thread correr2;
        Thread correr3;
        Thread correr4;
        Thread correr5;

        static object l = new object();
        bool pillado = false;

        public void Correr1()
        {
            while (!pillado)
            {
                lock (l)
                {
                    if (!pillado)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write("*");
                        h1.Correr();
                    }
                }
            }
        }

        public void Correr2()
        {
            while (!pillado)
            {
                lock (l)
                {
                    if (!pillado)
                    {
                        Console.SetCursorPosition(0, 1);
                        Console.Write("*");
                        h1.Correr();
                    }
                }
            }
        }

        public void Correr3()
        {
            while (!pillado)
            {
                lock (l)
                {
                    if (!pillado)
                    {
                        Console.SetCursorPosition(0, 2);
                        Console.Write("*");
                        h1.Correr();
                    }
                }
            }
        }

        public void Correr4()
        {
            while (!pillado)
            {
                lock (l)
                {
                    if (!pillado)
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.Write("*");
                        h1.Correr();
                    }
                }
            }
        }

        public void Correr5()
        {
            while (!pillado)
            {
                lock (l)
                {
                    if (!pillado)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.Write("*");
                        h1.Correr();
                    }
                }
            }
        }

        public void StartCarrera()
        {
            correr1 = new Thread(Correr1);
            correr2 = new Thread(Correr2);
            correr3 = new Thread(Correr3);
            correr4 = new Thread(Correr4);
            correr5 = new Thread(Correr5);

            Thread[] carrera = { correr1, correr2, correr3, correr4, correr5 };

            for (int i = 0; i < carrera.Length; i++)
            {
                carrera[i].Start();
            }
        }

        static void Main(string[] args)
        {
            Program ej4 = new Program();
            ej4.StartCarrera();
        }
    }
}