using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalFeatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string name = "Daniel Alex Sthali";       //Creating a constant as my name will never change
            var myCity = "Chorley";     //Creating a variable using var instead of typing the exact data type
            Console.WriteLine("My name is {0} and I live in {1}.", name, myCity);
            Console.WriteLine("What is your name?");
            string answer = Console.ReadLine();
            Console.WriteLine("And where do you live?");
            string answer2 = Console.ReadLine();            
            
            AdditionalFeaturesAssignment personDetails = new AdditionalFeaturesAssignment(answer, answer2);      //Instantiating an object and passing in as parameters the answer from the user

            Console.WriteLine("Your name is {0} and you live in {1}", personDetails.myName, personDetails.myCity);      //Writing back to the console the answers

            Console.ReadLine();

        }
    }
}
