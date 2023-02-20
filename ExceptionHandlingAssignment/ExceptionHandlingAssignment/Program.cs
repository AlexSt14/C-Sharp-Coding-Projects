using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool correctAnswer = false;     //Creating a bool in order to keep the user in the loop           
            while (!correctAnswer)      
            {
                try
                {
                    Console.WriteLine("What is your age?");
                    int answer = int.Parse(Console.ReadLine());         //TryParse returns a bool in case the conversion to INT was unsuccessful, in case its successful then assings the conversion OUT to age variable
                    DateTime dateTime = DateTime.Now.AddYears(-answer);        //Creating a datetime object, takes the time NOW and subtracts the user input
                    if (answer == 0) throw new AgeZero();      //If user inputs 0, then throw the according exeption
                    if (answer < 0) throw new NegativeAge();    //If user inputs a negative number, then throw the according exception  
                    Console.WriteLine("Based on your input, the year you were born is " + dateTime.Year); 
                    correctAnswer = true;       //Assigns this to true in order to break the loop
                }
                catch (AgeZero)     //Catching the specific exception related to age 0
                {
                    Console.WriteLine("Please make sure the age you enter does not equal to zero.");
                }
                catch (NegativeAge)     //Catching the specific exception related to negative numbers
                {
                    Console.WriteLine("Please make sure the age you enter is not a negative number.");
                }
                catch (Exception)       //Catching any other type of exceptions
                {
                    Console.WriteLine("Ops, something went wrong, please contact the developer.");
                    Console.ReadLine();
                    return;
                }
            } 
            Console.ReadLine();
        }
    }
}
