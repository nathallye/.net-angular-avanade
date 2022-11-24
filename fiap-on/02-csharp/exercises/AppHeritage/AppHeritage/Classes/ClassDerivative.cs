using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHeritage.Classes
{
    public class ClassDerivative: ClassBase
    {
        public override void Method()
        {
            Console.WriteLine("Método ClassDerivative");
        }

        public override void MethodAbstract()
        {
            Console.WriteLine("Método MethodAbstract");
        }
    }
}
