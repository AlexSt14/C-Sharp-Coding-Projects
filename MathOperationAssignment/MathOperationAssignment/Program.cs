using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationAssignment
{
    internal class Program
    {
        static void Main()
        {
            ////Task 1 to multiply a number by 50
            //Console.WriteLine("Please enter any number:");
            //string task1 = Console.ReadLine();
            //int total = 50 * Convert.ToInt32(task1);
            //Console.WriteLine("Your number multiplied by 50 is " + total);
            //Console.ReadLine();

            ////Task 2 to add 25 to a number
            //Console.WriteLine("Please enter any number;");
            //string task2 = Console.ReadLine();
            //int total2 = 25 + Convert.ToInt32(task2);
            //Console.WriteLine("Your number with an addition of 25 is " + total2);
            //Console.ReadLine();

            //Task 3 to divide it by 12.5, this time I tried to do the same operation with less lines of code
            //Console.WriteLine("Please enter any number:");
            //double total3 = Convert.ToDouble(Console.ReadLine()) / 12.5;
            //Console.WriteLine("Your chosen number divided by 12.5 is " + total3);
            //Console.ReadLine();

            //Task 4 check if its greater than 50
            //Console.WriteLine("Please enter any number:");
            //int answer4 = Convert.ToInt32(Console.ReadLine());
            //int testifTrue = 50;
            //bool total4 = answer4 > testifTrue;
            //Console.WriteLine("Is your chosen number greater than 50? " + total4);
            //Console.ReadLine();

            //Task 5 take input, divide it by 7 and prints the remainder
            Console.WriteLine("Please enter any number:");
            int answer5 = Convert.ToInt32(Console.ReadLine());
            int remainder = answer5 % 7;
            Console.WriteLine("The remainder of your chosen number divided by 7 is " + remainder);
            Console.ReadLine();
        }
    }
}
