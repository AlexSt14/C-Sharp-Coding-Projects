using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingAssignment
{
    public class NegativeAge : Exception        //Creating a class exception in order to have a more specifc type of exception, inheriting from Exception
    {
        public NegativeAge() : base() { }       //Creating a constructor, inheriting from the base constructor from Exception
        public NegativeAge(string message) : base( message) { }     //Overloading the constructor, inheriting from the base constructor from Exception, taking in as parameter the message of the error
    }
}
