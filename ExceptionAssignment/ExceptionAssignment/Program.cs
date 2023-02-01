using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> numbersList = new List<int>() { 106, 202, 58, 64, 38, 17 };
                Console.WriteLine("Pick a number");
                int numberInput = Convert.ToInt32(Console.ReadLine());
                foreach (int number in numbersList)
                {
                    int result = number / numberInput;
                    Console.WriteLine(result);
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Please do not pick 0.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please choose a whole number, not a string.");
            }
            Console.WriteLine("The program has now emerged from the Try/Catch block of code.");
            Console.ReadLine();
        }
    }
}
