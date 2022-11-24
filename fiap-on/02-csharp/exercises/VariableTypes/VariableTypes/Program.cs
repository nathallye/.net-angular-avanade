using System;

namespace VariableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int valueInt = 100;

            // convertendo inteiro para long
            long valueLong = valueInt;

            // convertendo long para double
            double valueDouble = valueLong;

            // Tentando converter long para int
            // valueInt = valueLong;

            // declaração de conversação (Parse)
            valueInt = (int) valueLong;

            // Imprimindo conteúdo das variáveis
            Console.WriteLine("Valor Inteiro: " + valueInt);
            Console.WriteLine("Valor Long: " + valueLong);
            Console.WriteLine("Valor Double: " + valueDouble);

            // Para a execução até o usuário teclar Enter.
            Console.Read();
        }
    }
}