using System;

namespace ControlStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 16;

            switch (age)
            {
                case 15:
                    Console.WriteLine("SUB-15");
                    break;
                case 16:
                    Console.WriteLine("SUB-16");
                    break;
                case 17:
                    Console.WriteLine("SUB-17");
                    break;
                case 18:
                    Console.WriteLine("SUB-18");
                    break;
                case 19:
                    Console.WriteLine("SUB-19");
                    break;
                case 20:
                    Console.WriteLine("SUB-20");
                    break;
                default: 
                    Console.WriteLine("Categoria não definida!");
                    break;
            }

            Console.Read();
        }
    }
}