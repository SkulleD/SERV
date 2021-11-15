using System;
using System.Threading;

namespace SERV_tema1_ej4
{
    class Program
    {
        Caballo[] caballos;

        static object l = new object();
        bool meta = false;
        string winner = "";

        public void CorrerMain(object i)
        {
            while (!meta)
            {
                lock (l)
                {
                    Monitor.Pulse(l);
                    if (((Caballo)i).Position < 50 && !meta)
                    {
                        Console.SetCursorPosition(((Caballo)i).Correr(), ((Caballo)i).Y);
                        Console.Write("*");
                        Thread.Sleep(50);
                        Monitor.Wait(l);
                    }
                    else
                    {
                        winner = ((Caballo)i).Name;
                        Console.SetCursorPosition(0, caballos.Length);
                        Console.WriteLine($"\n----> The winner is {winner}!");
                        meta = true;
                    }
                }
            }
        }

        public void StartCarrera()
        {
            Thread[] carrera = new Thread[5];
            Caballo caballo;
            caballos = new Caballo[5];
            string name = "1";

            for (int i = 0; i < caballos.Length; i++)
            {
                caballo = new Caballo("" + i, i);
                caballos[i] = caballo;
                carrera[i] = new Thread(CorrerMain);
                carrera[i].Start(caballos[i]);
                name = "" + i;
            }


        }

        static void Main(string[] args)
        {
            Program ej4 = new Program();
            ej4.StartCarrera();
        }
    }
}