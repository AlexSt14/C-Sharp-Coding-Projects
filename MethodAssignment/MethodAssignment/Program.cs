using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MethodAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MethodAssignment method = new MethodAssignment();   //Creating an object from class methodassignment, once the object is created I can call the method from the class
            Console.WriteLine("Please select a number");
            int input = Convert.ToInt32(Console.ReadLine());
            int resultMultiplication = method.Multiplication(input);    //calling the method and passing the parameter from the input
            Console.WriteLine("Your chosen number " + input + " multiplied by 5 is " + resultMultiplication);
            
            Console.WriteLine("Now lets try a division, choose a number to be divided by 3");
            int input2 = Convert.ToInt32(Console.ReadLine());           
            int resultDivision = method.Division(input2);     //calling a method and passing as parameter the input2
            Console.WriteLine("Your chosen number " + input2 + " divided by 3 is " + resultDivision);

            Console.WriteLine("Now lets try something different, choose 2 numbers and then type what operation do you want these 2 numbers to have.");
            Console.WriteLine("Now choose your first number");
            int input3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now choose your second number");
            int input4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now for the operation you can type: Multiplication, Division, Addition or Subtraction");
            string operation = Console.ReadLine();
            if (operation == "Multiplication")      //If what they type corresponds to one operation, that method will be called and parameters will be passed on to it
            {
                int result = method.Multiplication2(input3, input4);
                Console.WriteLine("You have chosen " + operation + " and numbers " + input3 + " and " + input4 + " and the result is " + result);
            }
            else if (operation == "Division") 
            {
                int result = method.Division2(input3, input4);
                Console.WriteLine("You have chosen " + operation + " and numbers " + input3 + " and " + input4 + " and the result is " + result);
            }
            else if (operation == "Addition")
            {
                int result = method.Addition2(input3, input4);
                Console.WriteLine("You have chosen " + operation + " and numbers " + input3 + " and " + input4 + " and the result is " + result);
            }
            else if (operation == "Subtraction")
            {
                int result = method.Subtraction2(input3, input4);
                Console.WriteLine("You have chosen " + operation + " and numbers " + input3 + " and " + input4 + " and the result is " + result);
            }
           
            

            Console.ReadLine();
        }
    }
}
