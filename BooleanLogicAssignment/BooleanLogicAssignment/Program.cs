using System;

namespace BooleanLogicAssignment
{
    internal class Program
    {
        static void Main()
        {
            
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Have you ever had a DUI violation? Please answer with True or False");
            bool violation = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("How many speeding tickets have you had?");
            int speedTicket = Convert.ToInt32(Console.ReadLine());

            bool qualify = age > 15 && violation == false && speedTicket < 3;
            Console.WriteLine("Do you qualify for car insurance?");
            Console.WriteLine(qualify);
            Console.ReadLine();

        }
    }
}
