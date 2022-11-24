using System;
using AppHeritage.Classes;

namespace AppHeritage
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassDerivative b = new ClassDerivative();
            b.Method();

            ClassBase c = new ClassDerivative();
            c.Method();
            c.MethodAbstract();

            Console.Read();
        }
    }
}