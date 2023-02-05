using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesandMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassandMethods Operation = new ClassandMethods();      //Created an object of that class so that I can call in the methods of the class
            Console.WriteLine("Please choose a number to be multiplied by 3");
            int input = Convert.ToInt32(Console.ReadLine());
            int result = Operation.Operation(input);    //Assigning as the result, the calling of the method from the class
            Console.WriteLine("Your chosen number " + input + " multiplied by 3 is " + result);

            Console.WriteLine("Now please choose a decimal number that will be divided by 3");
            decimal input2 = Convert.ToDecimal(Console.ReadLine());
            int result2 = (int)Operation.Operation(input2);     //assigning as a result the calling of the method from the class
            Console.WriteLine("Your decimal " + input2 + " divided by 3 is " + result2);
            

            Console.WriteLine("Now choose another number, we will do an addition this time");
            string input3 = Console.ReadLine();
            string result3 = Operation.Operation(input3);       //assigning as a result the calling of the method from class, this time as an integer
            Console.WriteLine("Your chosen number " + input3 + " with an addition of 10 is " + result3);
            Console.ReadLine();
        }
    }
}
