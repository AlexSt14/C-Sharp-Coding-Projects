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
    }
}
