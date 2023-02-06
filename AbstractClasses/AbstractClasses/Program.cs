using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.firstName = "Sample";
            employee.lastName = "Student";
            employee.SayName();

            IQuittable quittable = new Employee();      //I did not need this time to create a second Employee object, I just created it to demonstrate using polymorphism to create an object and call the quit function on it
            quittable.Quit();
            Console.ReadLine();
        }
    }
}
