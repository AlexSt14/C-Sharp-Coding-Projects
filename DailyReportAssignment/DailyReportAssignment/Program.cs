using System;

namespace DailyReportAssignment
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Pitman Training.");
            Console.WriteLine("Student Daily Report.");
            Console.WriteLine("What course are you in?");            
            string studentCourse = Console.ReadLine();
            Console.WriteLine("What page number?");
            string pageNumber = Console.ReadLine();
            short coursePageNumber = Convert.ToInt16(pageNumber);
            Console.WriteLine("Do you need help with anything? Please answer \"true\" or \"false\".");
            string helpAnswer = Console.ReadLine();
            bool needHelp = Convert.ToBoolean(helpAnswer);
            Console.WriteLine("Were there any positive experiences you'd like to share? Please provide specifics.");
            string positiveExperiences = Console.ReadLine();
            Console.WriteLine("Is there any other feedback you'd like to provide? Please be specific.");
            string feedback = Console.ReadLine();
            Console.WriteLine("How many hours did you study today?");
            string hoursStudied = Console.ReadLine();
            short studiedHours = Convert.ToInt16(hoursStudied);
            Console.WriteLine("Thank you for your responses. An instructor will respond shortly. Have a great day!");
            Console.ReadLine();
        }
    }
}
