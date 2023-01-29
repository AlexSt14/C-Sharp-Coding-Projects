using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_QuoteApplication
{
    internal class Program
    {
        static void Main()
        {
            //Price-Quote application assignment
            
            Console.WriteLine("Welcome to Package Express. Please follow the Instructions below.");
            Console.WriteLine("Please enter the weight of the package");
            int weight = Convert.ToInt32(Console.ReadLine()); //taking input and converting to int
            if (weight > 50)   //if statement, if weight is greater than 50 then we do not ship
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            }
            else  // if weight is lesser than 50 then continue with this
            {
                Console.WriteLine("Please enter the width of the package");
                int width = Convert.ToInt32(Console.ReadLine()); // taking input and converting
                Console.WriteLine("Please enter the height of the package");
                int height = Convert.ToInt32(Console.ReadLine()); // taking input and converting
                Console.WriteLine("Please enter the lenght of the package");
                int lenght = Convert.ToInt32(Console.ReadLine()); // taking input and converting

                //USING Ternary operator instead of another IF statement!!
                decimal shipPrice = (height * width * lenght) * weight / 100;   // calculation of the shipping price
                string result = width + height + lenght > 50 ? "Package too big to be shipped via Package Express" : "Your estimated total for shipping this package is: " + "$" + shipPrice;
                Console.WriteLine(result);


                //Instead of this IF statement, we can use the ternary operator!!

                //if (width > 50 || height > 50 || lenght > 50)  //a second if statement for width, height and lenght, if ANY of these are true then we do not ship
                //{
                //    Console.WriteLine("Package too big to be shipped via Package Express");  
                //}
                //else  //else if all of them are 50 or below, continue with the program
                //{
                //    decimal shipPrice = (height * width * lenght) * weight / 100;   // calculation of the shipping price
                //    Console.WriteLine("Your estimated total for shipping this package is: " + "$"+shipPrice);
                //}                
            }
            Console.ReadLine();
            
        }
    }
}
