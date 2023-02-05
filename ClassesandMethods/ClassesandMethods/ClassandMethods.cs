using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesandMethods
{
    internal class ClassandMethods
    {
        public int Operation(int input1)
        {
            return input1 * 3;
        }
        public decimal Operation(decimal input1)
        {
            return input1 / 3;
        }
        public string Operation(string input2)      //method that takes an integer as parameter, converts to string, does math and returns back an integer
        {
            int a = Convert.ToInt32(input2);
            int b = a + 10;
            string c = b.ToString();
            return c;
        }
    }
}
