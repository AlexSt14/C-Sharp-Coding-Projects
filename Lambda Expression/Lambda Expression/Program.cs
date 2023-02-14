using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Employees> employees = new List<Employees>()       //instantiating the employees object
            
            {
                new Employees(){Id = 1, firstName = "Alex", lastName = "Sthali"},       //Creating new objects
                new Employees(){Id = 2, firstName = "Matthew", lastName = "James"},
                new Employees(){Id = 3, firstName = "Raluca", lastName = "Turc"},
                new Employees(){Id = 4, firstName = "Timea", lastName = "Beke"},
                new Employees(){Id = 5, firstName = "Joe", lastName = "Swain"},
                new Employees(){Id = 6, firstName = "Richard", lastName = "Evans"},
                new Employees(){Id = 7, firstName = "Adrian", lastName = "Zaharia"},
                new Employees(){Id = 8, firstName = "Joe", lastName = "Jasmin"},
                new Employees(){Id = 9, firstName = "Chantelle", lastName = "Evans"},
                new Employees(){Id = 10, firstName = "Joe", lastName = "Martin"}
            };
            List<Employees> tempList = employees.Where(x => x.firstName == "Joe").ToList();     //Lambda expression, creating a temp list where employees firstName equals to "Joe" and add that object to the new list
            foreach (Employees emp in tempList)     //foreach loop to display first and last names from the new tempList on screen
            {
                Console.WriteLine(emp.firstName + " " + emp.lastName);
            }            
            Console.ReadLine();
            
        }
    }
}
