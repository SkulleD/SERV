using System;
using System.Threading;

namespace _3EVA_SERV_ej3
{
    class Program
    {
        static readonly object l = new object();
        static int valor = 0;

        static void Main(string[] args)
        {
            Thread tSumar = new Thread(() =>
            {
                do
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
                } while (valor != 1000);
            });
            Thread tRestar = new Thread(() =>
            {
                do
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
                } while (valor != -1000);
            });
            tSumar.Priority = ThreadPriority.Highest;
            tRestar.Priority = ThreadPriority.Lowest;
            tSumar.Start();
            tRestar.Start();
            Console.ReadKey();
        }
    }
}