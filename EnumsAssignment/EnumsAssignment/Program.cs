using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EnumsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try         //Try and catch if user inputs anything else other than the days of the week
            {
                Console.WriteLine("Please enter the current day of the week:");
                daysoftheWeek input = (daysoftheWeek)Enum.Parse(typeof(daysoftheWeek), Console.ReadLine()); //Assigning to a variable of data type enum, parsing through the enum, first parameter is the enum name we search in, the second parameter is user input, which will parse through enum
            }
            catch
            {
                Console.WriteLine("Please enter an actual day of the week");        //If after parsing the enum, there is no match, then we catch that error and display this message
            }
            
            Console.ReadLine();
        }
        public enum daysoftheWeek       //creating an enum days of the week
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}
