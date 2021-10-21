using System;
using System.Threading;

namespace SERV_tema1_ej3
{
    class Program
    {
        static int num = 0;
        static bool finished = false;
        static object l = new object();

        static void Main(string[] args)
        {
            Thread tIncrease = new Thread(
                () =>
                {
                    while (!finished)
                    {
                        lock (l)
                        {
                            if (!finished)
                            {
                                num++;
                                Console.WriteLine("Incrementa {0}", num);

                                if (num == 1000)
                                {
                                    finished = true;
                                }
                            }
                        }
                    }
                });
            Thread tDecrease = new Thread(
                () =>
                {
                    while (!finished)
                    {
                        lock (l)
                        {
                            if (!finished)
                            {
                                num--;
                                Console.WriteLine("Decrementa {0}", num);

                                if (num == -1000)
                                {
                                    finished = true;
                                }
                            }
                        }
                    }
                });

            tIncrease.Start();
            tDecrease.Start();

            tIncrease.Join();
            tDecrease.Join();

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