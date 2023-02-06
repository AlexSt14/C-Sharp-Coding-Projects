using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    public class Employee : Person, IQuittable
    {        
        public void Quit()
        {
            Console.WriteLine("This method will quit the application");
        }
        public override void SayName()
        {          
            Console.WriteLine(firstName + " " + lastName);
        }
        public int Id { get; set; }

        //overloading the == operator
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            return employee1.Id == employee2.Id;
        }
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return !(employee1.Id == employee2.Id);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
