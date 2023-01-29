using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAssignment
{
    internal class Program
    {
        static void Main()
        {
            //Concatenating three strings
            //string firstName = "Daniel ";
            //string middleName = "Alex ";
            //string lastName = "Sthali";

            //string fullName = firstName + middleName + lastName;
            //Console.WriteLine(fullName);
            //Console.Read();

            //Converting a string to uppercase
            string fullName = "Daniel Alex Sthali";
            Console.WriteLine(fullName.ToUpper());
            

            StringBuilder sb = new StringBuilder();
            sb.Append("A paragraph is a coherent block of text, such as a group of related sentences that develop a single topic or a coherent part of a larger topic. A blank line contains zero or more non-printing characters, such as space or tab, followed by a new line.");
            Console.WriteLine(sb);
            Console.Read();
        }
    }
}
