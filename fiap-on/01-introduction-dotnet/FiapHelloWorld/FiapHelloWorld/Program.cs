using System;
using FiapHelloWorld.Models;

namespace FiapHelloWorld // namespace
{
    class Program // classe
    {
        static void Main(string[] args) // método
        {
            HelloModel helloModel = new Models.HelloModel();
            Console.WriteLine(helloModel.Message);

            Console.Read(); // trecho para manter a janela aberta
        }

    }
}