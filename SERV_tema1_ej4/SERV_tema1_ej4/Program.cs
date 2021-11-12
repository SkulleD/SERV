using System;
using System.Threading;

namespace SERV_tema1_ej4
{
    class Program
    {
        static Caballo h1 = new Caballo("Horse 1");
        static Caballo h2 = new Caballo("Horse 2");
        static Caballo h3 = new Caballo("Horse 3");
        static Caballo h4 = new Caballo("Horse 4");
        static Caballo h5 = new Caballo("Horse 5");

        Caballo[] caballos = { h1, h2, h3, h4, h5 };

        static Thread correr1;
        static Thread correr2;
        static Thread correr3;
        static Thread correr4;
        static Thread correr5;

        static object l = new object();
        bool meta = false;
        string winner = "";

        public void Correr1() // HACER UN DELEGADO PARA NO TENER TANTOS METODOS
        {
            while (!meta)
            {
                lock (l)
                {
                    Monitor.Pulse(l);
                    if (!meta)
                    {
                        if (h1.Position <= 50)
                        {
                            Console.SetCursorPosition(h1.Correr(), 0);
                            Console.Write("*");
                            Thread.Sleep(50);
                            Monitor.Wait(l);
                        }
                        else
                        {
                            winner = h1.Name;
                            meta = true;
                        }
                    }
                }
            }
        }

        public void Correr2()
        {
            while (!meta)
            {
                lock (l)
                {
                    Monitor.Pulse(l);
                    if (!meta)
                    {
                        if (h2.Position <= 50)
                        {
                            Console.SetCursorPosition(h2.Correr(), 1);
                            Console.Write("*");
                            Thread.Sleep(50);
                            Monitor.Wait(l);
                        }
                        else
                        {
                            winner = h2.Name;
                            meta = true;
                        }
                    }
                }
            }
        }

        public void Correr3()
        {
            while (!meta)
            {
                lock (l)
                {
                    Monitor.Pulse(l);
                    if (!meta)
                    {
                        if (h3.Position <= 50)
                        {
                            Console.SetCursorPosition(h3.Correr(), 2);
                            Console.Write("*");
                            Thread.Sleep(50);
                            Monitor.Wait(l);
                        }
                        else
                        {
                            winner = h3.Name;
                            meta = true;
                        }
                    }
                }
            }
        }

        public void Correr4()
        {
            while (!meta)
            {
                lock (l)
                {
                    Monitor.Pulse(l);
                    if (!meta)
                    {
                        if (h4.Position <= 50)
                        {
                            Console.SetCursorPosition(h4.Correr(), 3);
                            Console.Write("*");
                            Thread.Sleep(50);
                            Monitor.Wait(l);
                        }
                        else
                        {
                            winner = h4.Name;
                            meta = true;
                        }
                    }
                }
            }
        }

        public void Correr5()
        {
            while (!meta)
            {
                lock (l)
                {
                    Monitor.Pulse(l);
                    if (!meta)
                    {
                        if (h5.Position <= 50)
                        {
                            Console.SetCursorPosition(h5.Correr(), 4);
                            Console.Write("*");
                            Thread.Sleep(50);
                            Monitor.Wait(l);
                        }
                        else
                        {
                            winner = h5.Name;
                            meta = true;
                        }
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
            Thread[] alvaroFlipalo = new Thread[5];

            Thread[] carrera = { correr1, correr2, correr3, correr4, correr5 };

            for (int i = 0; i < carrera.Length; i++)
            {
                //alvaroFlipalo[i] = new Thread(Correr1(i));
                carrera[i].Start();
            }

            correr1.Join();
            correr2.Join();
            correr3.Join();
            correr4.Join();
            correr5.Join();
        }

        static void Main(string[] args)
        {
            Program ej4 = new Program();
            ej4.StartCarrera();



            Console.SetCursorPosition(0, ej4.caballos.Length);
            Console.WriteLine($"\n----> The winner is {ej4.winner}!");
        }
    }
}