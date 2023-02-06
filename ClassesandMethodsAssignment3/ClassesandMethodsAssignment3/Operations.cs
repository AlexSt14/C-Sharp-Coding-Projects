using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesandMethodsAssignment3
{
    internal class Operations
    {
        public void Operation(int numberOne, int numberTwo)     //Creating a void function, this function runs on itself(the class) and does not need a return
        {
            int operation = numberOne * 5;
            Console.WriteLine(numberTwo);
        }
    }
}
