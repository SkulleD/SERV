using System;
using System.Threading;

namespace _3EVA_SERV_ej3
{
    class Program
    {
        static int valor = 0;

        static void Main(string[] args)
        {
            Thread tSumar = new Thread(() =>
            {
                do
                {
                    if (valor != 1000)
                    {
                        valor++;
                        Console.WriteLine(valor + " Sumado por Suma");
                    }
                } while (valor != 1000);
            });
            Thread tRestar = new Thread(() =>
            {
                do
                {
                    if (valor != -1000)
                    {
                        valor--;
                        Console.WriteLine(valor + " Restado por Resta");
                    }
                } while (valor != -1000);
            });
            tSumar.Priority = ThreadPriority.Highest;
            tRestar.Priority = ThreadPriority.Lowest;
            tSumar.Start();
            tRestar.Start();
            Console.ReadKey();
        }

        //static void Sumar()
        //{
        //    do
        //    {
        //        if (valor != 1000)
        //        {
        //            valor++;
        //            Console.WriteLine(valor + " Sumado por Suma");
        //        }
        //    } while (valor != 1000);
        //}

        //static void Restar()
        //{
        //    do
        //    {
        //        if (valor != -1000)
        //        {
        //            valor--;
        //            Console.WriteLine(valor + " Restado por Resta");
        //        }
        //    } while (valor != -1000);
        //}
    }
}