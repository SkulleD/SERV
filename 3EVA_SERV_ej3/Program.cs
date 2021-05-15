using System;
using System.Threading;

namespace _3EVA_SERV_ej3
{
    class Program
    {
        static readonly object l = new object();
        static int valor = 0;
        static bool run = true;

        static void Main(string[] args)
        {
            Thread tSumar = new Thread(() =>
            {
                while (run)
                {
                    lock (l)
                    {
                        if (valor != 1000)
                        {
                            //Thread.Sleep(1);
                            valor++;
                            Console.SetCursorPosition(2, 2);
                            Console.Write(valor + " Sumado por Suma");
                        }
                    }
                }
            });
            Thread tRestar = new Thread(() =>
            {
                while (run)
                {
                    lock (l)
                    {
                        if (valor != -1000)
                        {
                            //Thread.Sleep(1);
                            valor--;
                            Console.SetCursorPosition(2, 2);
                            Console.Write(valor + " Restado por Resta");
                        }
                    }
                }
            });
            tSumar.Priority = ThreadPriority.Highest;
            tRestar.Priority = ThreadPriority.Lowest;
            tSumar.Start();
            tRestar.Start();

            while (run)
            {
                if (valor == 900)
                {
                    run = false;
                }
                if (valor == -1000)
                {
                    run = false;
                }
            }
            Console.ReadKey();
        }
    }
}