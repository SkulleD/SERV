using System;
using System.Threading;

namespace SERV_tema1_ej4
{
    class Program
    {
        Caballo[] caballos;

        static object l = new object();
        bool meta = false;
        int winner = 0;
        int bet = 0;
        bool runboth = true;
        string again = "";
        string empty = "                                                                                        ";

        public void CorrerMain(object i)
        {
            Console.SetCursorPosition(0, caballos.Length + 1);
            Console.Write(empty);

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
                        winner = ((Caballo)i).Number;
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
            int number = 1;

            for (int i = 0; i < caballos.Length; i++)
            {
                caballo = new Caballo((i + 1), i);
                caballos[i] = caballo;
                carrera[i] = new Thread(CorrerMain);
                carrera[i].Start(caballos[i]);
                number = i;
            }

            for (int i = 0; i < caballos.Length; i++)
            {
                carrera[i].Join();
            }

            if (meta)
            {
                RunAgain();
            }
        }

        public void Apuesta()
        {
            do
            {
                caballos = new Caballo[5];
                Console.SetCursorPosition(0, caballos.Length + 4);
                Console.Write(empty);
                Console.SetCursorPosition(0, caballos.Length + 5);
                Console.Write(empty);
                Console.SetCursorPosition(0, caballos.Length + 2);
                Console.WriteLine("Which horse do you want to bet on?");

                try
                {
                    if (bet < caballos.Length)
                    {
                        Console.Write(empty);
                        Console.SetCursorPosition(0, caballos.Length + 3);
                        bet = int.Parse(Console.ReadLine());
                        Console.Write(empty);
                    }
                    else
                    {
                        Console.SetCursorPosition(0, caballos.Length + 1);
                        Console.WriteLine("Can't bet on a horse that doesn't exist!");
                        Console.Write(empty);

                    }
                }
                catch (Exception ex) when (ex is ArgumentException || ex is OverflowException || ex is FormatException)
                {
                    Console.SetCursorPosition(0, caballos.Length + 1);
                    Console.WriteLine($"You can only bet on a horse between 1 and {caballos.Length}!");
                    Console.Write(empty);

                }
            } while (bet > caballos.Length || bet <= 0);
        }

        public void RunBoth()
        {
            caballos = new Caballo[5];

            do
            {
                if (runboth)
                {
                    Apuesta();
                    StartCarrera();
                }
                else
                {
                    Console.Write(empty);
                    Console.SetCursorPosition(0, caballos.Length + 4);
                    Console.WriteLine("See you!");
                }
            } while (again.ToUpper().Equals("Y"));
        }

        public void RunAgain()
        {
            Console.Write(empty);
            Console.SetCursorPosition(0, caballos.Length + 4);
            Console.WriteLine("Do you want to play again? Y/N");
            again = Console.ReadLine();
            Console.Write(empty);
        }

        static void Main(string[] args)
        {
            Program ej4 = new Program();
            ej4.RunBoth();
        }
    }
}