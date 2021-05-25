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
                        if (run)
                        {
                            valor++;
                            if (valor == 1000)
                            {
                                run = false;
                            }
                            //Console.SetCursorPosition(2, 2);
                            Console.WriteLine(valor + " Sumado por Suma");
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
                        if (run)
                        {
                            valor--;
                            if (valor == -1000)
                            {
                                run = false;
                            }
                            //Console.SetCursorPosition(2, 2);
                            Console.WriteLine(valor + " Restado por Resta");
                        }
                    }
                }
            });

            tSumar.Start();
            tRestar.Start();

            Console.ReadKey();
        }
    }
}