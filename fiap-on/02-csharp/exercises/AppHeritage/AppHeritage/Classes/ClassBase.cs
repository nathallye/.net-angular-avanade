using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHeritage.Classes
{
    public abstract class ClassBase
    {
        public virtual void Method() 
        {
            Console.WriteLine("Método ClassBase");
        }

        public abstract void MethodAbstract();
    }
}