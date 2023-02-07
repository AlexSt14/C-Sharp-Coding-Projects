using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee<string> employee = new Employee<string>();         //Instantiating an employee object with type string as its generic parameter
            employee.things = new List<string>() { "Alex", "Daniel", "Matthew" };       //Firstly creating a list, then assigning some strings as the property value of things
            
            foreach (string thing in employee.things)       //looping through the list to show on screen what list contains
            {
                Console.WriteLine(thing);
            }

            Employee<int> employee1 = new Employee<int>();      //Instantiating an employee object with type int as its generic paramenter
            employee1.things = new List<int>() { 1, 5, 3978, 123, 25 };     //Firstly creting a list, then assigning some integers as the property value of things

            foreach (int thing in employee1.things)     //looping through the list to show on screen what list contains
            {
                Console.WriteLine(thing);
            }
            Console.ReadLine();
        }
    }
}
