using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTime_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;       //Creating a new datetime object that will display the date and time in that exact moment
            Console.WriteLine(dateTime);        //Printing that to the console
            Console.WriteLine("Choose a number");   
            double answer = Convert.ToDouble(Console.ReadLine());
            DateTime dateTime2 = dateTime.AddHours(answer);     //Creating a new DateTime object which is equal to the first one PLUS the hours that the user chose as a number            
            Console.WriteLine("In " + answer + " hours the time will be " + dateTime2);     //Printing to the console the result
            Console.ReadLine();
        }
    }
}
