using System;
using System.Threading;

namespace SERV_tema1_ej3
{
    class Program
    {
        static int num = 0;
        static bool finished = false;
        static object l = new object();

        public static void increment()
        {
            while (!finished)
            {
                lock (l)
                {
                    Console.WriteLine("Incrementa {0}", num);
                    num++;
                    if (num == 1000)
                    {
                        finished = true;
                    }
                }
            }
        }

        public static void decrement()
        {
            while (!finished)
            {
                lock (l)
                {
                    Console.WriteLine("Decrementa {0}", num);
                    num--;

                    if (num == -1000)
                    {
                        finished = true;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Thread tIncrease = new Thread(increment);
            Thread tDecrease = new Thread(decrement);

            tIncrease.Start();
            tDecrease.Start();

            Console.ReadKey();

            if (finished)
            {
                tIncrease.Join();
                tDecrease.Join();

                if (num == 999)
                {
                    num++;
                }

                if (num == -999)
                {
                    num--;
                }

                if (num == 1000)
                {
                    Console.WriteLine("\nGANADOR: INCREMENTO");
                }
                else
                {
                    Console.WriteLine("\nGANADOR: DECREMENTO");
                }

                Console.WriteLine(num);
            }
        }
    }
}