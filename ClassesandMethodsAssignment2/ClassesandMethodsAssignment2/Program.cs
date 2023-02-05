using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesandMethodsAssignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operation operation = new Operation();
            Console.WriteLine("Choose a number");
            int input1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose a second number, this is optional, if you don't want to chose a second number then press enter");        
            string input2 = Console.ReadLine();

            if (String.IsNullOrEmpty(input2))
            {
                int result = operation.Operations(input1);  //the result variable calls the method from the class passing in 2 parameters
                Console.WriteLine(result);
                Console.ReadLine();
                                
            }            
            else
            {
                int input2Convert = Convert.ToInt32(input2);
                int result1 = operation.Operations(input1, input2Convert);  //the result variable calls the method from the class passing in 2 parameters
                Console.WriteLine(result1);
            }
            Console.ReadLine();
        }
    }
}
