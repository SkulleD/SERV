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
            while (run)
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
                            else
                            {
                                run = false;
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
                            else
                            {
                                run = false;
                            }
                        }
                    }
                });

                tSumar.Priority = ThreadPriority.Highest;
                tRestar.Priority = ThreadPriority.Lowest;
                tSumar.Start();
                tRestar.Start();
            }
            Console.ReadKey();
        }
    }
}