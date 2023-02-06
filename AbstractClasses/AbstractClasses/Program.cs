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

            //Operator OVERLOADING Assignment
            Employee employee1 = new Employee();
            Employee employee2 = new Employee(); 
            employee1.Id = 1234567;
            employee2.Id = 1234567;
            bool trueorFalse = employee1 == employee2;
            Console.WriteLine("Is employee1 ID equal to employee2 ID?" + trueorFalse);

            Console.ReadLine();
        }
    }
}
