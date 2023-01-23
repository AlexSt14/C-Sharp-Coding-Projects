using System;

namespace IncomeComparisonAssignment
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Anonymous Income Comparison Program");
            Console.WriteLine("Person 1, please enter your hourly rate:");
            int hourlyRate = Convert.ToInt32(Console.ReadLine());  //takes input and converts it to int
            Console.WriteLine("Person 1, please enter your hours worked per week:");
            int hoursWorked = Convert.ToInt32(Console.ReadLine());  //takes input and converts it to int
            Console.WriteLine("Person 2, please enter your hourly rate:");
            int hourlyRate2 = Convert.ToInt32(Console.ReadLine());  //takes input and converts it to int
            Console.WriteLine("Person 2, please enter your hours worked per week:");
            int hoursWorked2 = Convert.ToInt32(Console.ReadLine()); //takes input and converts it to int
            int annualSalary1 = hourlyRate * hoursWorked * 52; //52 weeks in a year
            int annualSalary2 = hourlyRate2 * hoursWorked2 * 52; //52 weeks in a year
            Console.WriteLine("Annual salary of Person 1: " + annualSalary1);
            Console.WriteLine("Annual salary of Person 2: " + annualSalary2);
            bool comparisonSalary = annualSalary1 > annualSalary2;
            Console.WriteLine("Person 1 makes more money than Person 2");
            Console.WriteLine(comparisonSalary);
            Console.ReadLine();
        }
    }
}
