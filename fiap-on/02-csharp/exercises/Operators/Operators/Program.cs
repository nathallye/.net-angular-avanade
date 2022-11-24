using System;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Operadores para Cálculos 
            int soma = 10 + 15 + 3;
            int subtracao = soma - 10;
            int multiplicacao = soma * subtracao;
            double divisao = multiplicacao / subtracao;

            Console.WriteLine(soma);
            Console.WriteLine(subtracao);
            Console.WriteLine(multiplicacao);
            Console.WriteLine(divisao);

            Console.Read();
        }
    }
}