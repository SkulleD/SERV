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
        string empty = "                                                                                                                                      ";
        int maxNumber = 6;
        Random random = new Random();

        public void CorrerMain(object i)
        {
            Caballo horse = (Caballo)i;
            Console.SetCursorPosition(0, caballos.Length + 1);
            Console.Write(empty);

            while (!meta)
            {
                Thread.Sleep(random.Next(1, 350));

                lock (l)
                {
                    if (!meta)
                    {
                        Console.SetCursorPosition(horse.Correr(), horse.Y);
                        Console.Write("*");

                        if (horse.Position == horse.Finishline)
                        {
                            meta = true;
                            winner = horse.Number;
                        }
                    }
                }
            }
        }

        public void StartCarrera()
        {
            Thread[] carrera = new Thread[maxNumber];
            Caballo caballo;
            caballos = new Caballo[maxNumber];
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
                Console.SetCursorPosition(0, caballos.Length + 1);
                Console.WriteLine($"\n--> The winner is {winner}!");

                if (bet == winner)
                {
                    Console.Write(empty);
                    Console.WriteLine("You won the bet!!!");
                }
                else
                {
                    Console.Write(empty);
                    Console.WriteLine("You lost the bet...");
                }

                RunAgain();
            }
        }

        public void Apuesta()
        {
            do
            {
                caballos = new Caballo[maxNumber];

                Console.SetCursorPosition(0, caballos.Length + 4);
                Console.Write(empty);
                Console.SetCursorPosition(0, caballos.Length + 5);
                Console.Write(empty);
                Console.SetCursorPosition(0, caballos.Length + 2);
                Console.WriteLine("Which horse do you want to bet on?");

                try
                {
                    Console.Write(empty);
                    Console.SetCursorPosition(0, caballos.Length + 3);
                    bet = int.Parse(Console.ReadLine());
                    Console.Write(empty);

                    if (bet > caballos.Length)
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

        public void RunBoth() // Runs 3 functions but there were only 2 at first
        {
            do
            {
                caballos = new Caballo[maxNumber];

                if (runboth)
                {
                    meta = false; // Set to "false" so the race can be started again
                    Apuesta();
                    MakeFinishline();
                    StartCarrera();
                }
                else
                {
                    Console.Write(empty);
                    Console.SetCursorPosition(0, caballos.Length + 4);
                    Console.WriteLine("See you!");
                }
            } while (again.ToUpper().Equals("Y") && again.Trim().Length == 1);
        }

        public void RunAgain()
        {
            Console.Write(empty);
            Console.SetCursorPosition(0, caballos.Length + 5);
            Console.WriteLine("Do you want to play again? Y/N or other"); // If not "Y" the program ends
            again = Console.ReadLine();
            Console.Write(empty);
        }

        public void MakeFinishline()
        {
            Caballo horse = new Caballo(0, 0);
            for (int i = 0; i < caballos.Length; i++)
            {
                Console.SetCursorPosition(0, i); // Cleans the last horse race to make room for a new one
                Console.Write(empty);
            }

            for (int i = 0; i < caballos.Length; i++)
            {
                Console.SetCursorPosition(horse.Finishline, i);
                Console.WriteLine("||");
            }
        }

        static void Main(string[] args)
        {
            Program ej4 = new Program();
            ej4.RunBoth();
        }
    }
}