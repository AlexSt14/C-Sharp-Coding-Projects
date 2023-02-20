using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class FraudException : Exception             //CREATING this class as an exception just to be able to have my OWN exception that is specific to Fraud Exception, instead of catching the fraud exception under a different exception name
    {
        public FraudException() : base() { }        //Creating a constructor that inherits the exact same constructor from Exception
        public FraudException(string message) : base(message) { }       //Overloading the constructor that takes as parameter the error string message, inherits from the base exception which also takes as parameter the error message
    }
}
