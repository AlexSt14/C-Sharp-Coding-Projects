using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethod
{
    static class ClassAssignment
    {
        public static void Operations(int a)        //void method, no return value, to write on screen we need to add here the writeline command
        {
            int result = a / 2;
            Console.WriteLine(result);
        }
        public static int Operations2(int a, int b)     //method with output parameters
        {
            return a % b;
        }
        public static int Operations2(string a)     //overloaded method with a different operation
        {
            int result = Convert.ToInt32(a) * 200;            
            return result;
        }
    }
}
