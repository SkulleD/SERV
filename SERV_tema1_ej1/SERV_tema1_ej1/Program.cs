using System;

namespace SERV_tema1_ej1
{
    class Program
    {
        public delegate void MyDelegate();

        public void MenuGenerator(string[] options, MyDelegate[] functions)
        {
            int cont = 1;
            int choice = 0;

            do
            {
                try
                {
                    cont = 1;

                    Console.WriteLine("---Enter the number of the method you want to run---");
                    foreach (string nombre in options)
                    {
                        Console.WriteLine(cont + ": " + nombre);
                        cont++;
                    }
                    Console.WriteLine(cont + ": Exit");

                    choice = int.Parse(Console.ReadLine());

                    if (choice != cont && (choice > 0 && choice < cont))
                    {
                        choice--;
                        functions[choice]();

                    }
                    else if (choice > cont)
                    {
                        Console.WriteLine("Enter a number lesser than {0}", cont);
                    }
                    else if (options.Length != functions.Length) //No se repite al pasar por esta sección
                    {
                        Console.WriteLine("Number of options doesn't match number of functions. No function exists within that option.");
                    }
                    else
                    {
                        Console.WriteLine("See ya");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a number lesser than {0}", cont);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Enter a number lesser than {0}", cont);
                }
            } while (choice != cont);
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.MenuGenerator(new string[] { "Op1", "Op2", "Op3", "Op4" },
                new MyDelegate[]
                {
                () => Console.WriteLine("\nOption A"),
                () => Console.WriteLine("\nOption B"),
                () => Console.WriteLine("\nOption C"),
                () => Console.WriteLine("\nOption D"),
                });
            Console.ReadKey();
        }
    }
}
