using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Please choose a number to be divided by 2");
            int input = Convert.ToInt32(Console.ReadLine());
            ClassAssignment.Operations(input);          //calling in the class method while class is static, no need to instantiate the class, called the method which will divide the number by 2 and display the result

            int result = ClassAssignment.Operations2(2, input);     //calling in the class method while class is static, no need to instantiate the class
            Console.WriteLine(result);

            int result2 = ClassAssignment.Operations2("2");     //calling in the class method while class is static, no need to instantiate the class
            Console.WriteLine(result2);
            Console.ReadLine();
        }
    }
}
