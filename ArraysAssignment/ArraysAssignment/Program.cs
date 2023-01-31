using System;
using System.Collections.Generic;

namespace ArraysAssignment
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Please select an index for strings");
            string[] stringArray1 = { "Hello", "World!", "Daniel", "Sthali" };  //creating a string array
            int indexString = Convert.ToInt32(Console.ReadLine());  //converting the input
            Console.WriteLine("Please select an index for integers");
            int[] intArray1 = { -234, 2678, 55, 433 };      //creating an int array
            int indexInt = Convert.ToInt32(Console.ReadLine());     //converting the input

            string result = indexString > 3 || indexInt > 3 ? "That index does not exist, please select an index between 0 and 3" : stringArray1[indexString] + "\n" + intArray1[indexInt];     //ternary operator to optimize code in less lines, conditional statement for result
            Console.WriteLine(result);
            

            Console.WriteLine("Please select an index for strings");
            List<string> stringList = new List<string> { "Hello", "there", "soldier", "Motorcycle" };   //creating a string list
            int listIndex = Convert.ToInt32(Console.ReadLine());        //converting the input
            string result2 = listIndex > 3 ? "That index does not exist, please select an index between 0 and 3" : stringList[listIndex];       //ternary operator to optimize code with less lines, conditional statement for result
            Console.WriteLine(result2);
            
            Console.Read();
        }
    }
}
