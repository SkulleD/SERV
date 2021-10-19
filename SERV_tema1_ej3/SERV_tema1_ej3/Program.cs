using System;
using System.Threading;

namespace SERV_tema1_ej3
{
    class Program
    {
        static int num = 0;
        static bool finished = false;

        public static void increment()
        {
            if (num == 1000 || num == -1000)
            {
                finished = true;
            }

            while (num <= 1000)
            {
                Console.WriteLine(num);
                num++;
            }
        }

        public static void decrement()
        {
            if (num == 1000 || num == -1000)
            {
                finished = true;
            }

            while (num >= -1000)
            {
                Console.WriteLine(num);
                num--;
            }
        }

        static void Main(string[] args)
        {
            //Program ej3 = new Program();
            Thread tIncrease = new Thread(increment);
            Thread tDecrease = new Thread(decrement);

            tIncrease.Start();
            tDecrease.Start();

            if (finished)
            {
                tIncrease.Join();
                tDecrease.Join();
            }

            Console.ReadKey();
        }
    }
}