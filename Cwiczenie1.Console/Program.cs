using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace Cwiczenie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc Kalkulator1 = new Calc(10, 20);
            Console.WriteLine("Suma = " + Kalkulator1.Suma());
            Console.ReadKey();

           
        }
    }
}
