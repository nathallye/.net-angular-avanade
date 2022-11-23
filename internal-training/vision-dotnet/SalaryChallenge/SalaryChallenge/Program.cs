using System;
using System.Globalization;

namespace SalaryChallenge
{
    class Program
    {
        static void Main(string[] args) 
        {
            double salary = 0;
            double adjustment = 0;
            double salaryWithAdjustment = 0;

            Console.WriteLine("Entre com o salário atual do colaborador: ");
            salary = double.Parse(Console.ReadLine());

            adjustment = salary * 0.10;
            salaryWithAdjustment = salary + adjustment;

            Console.WriteLine("O salário ajustado do colaborador é: " + salaryWithAdjustment.ToString("F2"));
        }
    }
}