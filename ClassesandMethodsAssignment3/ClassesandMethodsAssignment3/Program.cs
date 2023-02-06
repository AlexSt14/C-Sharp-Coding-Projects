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
            Operations operations = new Operations();   //Instantiating the class
            int a = 10;
            int b = 15;
            operations.Operation(numberOne: a, numberTwo: b);       //calling the function and passing in two parameters to it
            Console.ReadLine();
        }
    }
}
