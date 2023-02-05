using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesandMethodsAssignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();
            int a = 10;
            int b = 2;
            Console.WriteLine(operations.Operation(a, b));
            Console.ReadLine();
        }
    }
}
