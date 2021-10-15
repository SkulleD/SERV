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

            Console.WriteLine("---Enter the number of the method you want to run---");
            foreach (string nombre in options)
            {
                Console.WriteLine(cont + ": " + nombre);
                cont++;
            }

            choice = int.Parse(Console.ReadLine());

            choice--;
            functions[choice]();
        }

        static void f1()
        {
            Console.WriteLine("\nA");
        }
        static void f2()
        {
            Console.WriteLine("\nB");
        }
        static void f3()
        {
            Console.WriteLine("\nC");
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.MenuGenerator(new string[] { "Op1", "Op2", "Op3" }, new MyDelegate[] { f1, f2, f3 });
            Console.ReadKey();
        }
    }
}