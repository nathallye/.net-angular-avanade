using System;

namespace RepeatingStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            */

            /*
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }
            */

            /*
            int i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 10);
            */

            string[] list = { "Fiap", "Fiap On", "Avanade", "Microsoft" };

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}