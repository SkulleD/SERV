using System;
using System.Threading;

namespace _3EVA_SERV_ej3
{
    class Program
    {
        static int valor = 0;

        static void Main(string[] args)
        {
            Thread tSumar = new Thread(sumar);
            Thread tRestar = new Thread(restar);
            tSumar.Priority = ThreadPriority.Highest;
            tRestar.Priority = ThreadPriority.Lowest;
            tSumar.Start();
            tRestar.Start();
            Console.ReadKey();

            //for (int i = 0; i <= 1000; i++) valor++;
        }

        static void sumar()
        {
            for (int i = 0; i <= 1000; i++)
            {
                if (valor == 1000)
                {
                    Console.WriteLine(valor);
                }
                else
                {
                    valor++;
                    Console.WriteLine(valor + " Sumado por Suma");
                }
            }
        }

        static void restar()
        {
            for (int i = 0; i <= 1000; i++)
            {
                if (valor == 1000)
                {
                    Console.WriteLine(valor);
                }
                else
                {
                    valor--;
                    Console.WriteLine(valor + " Restado por Resta");
                }
            }
        }
    }
}
