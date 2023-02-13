using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructsAssignment
{
    internal class Program
    {
        static void Main()
        {
            Number number = new Number();
            number.Amount = 20.213m;

            Console.WriteLine(number.Amount);
            Console.ReadLine();
        }
    }
}
