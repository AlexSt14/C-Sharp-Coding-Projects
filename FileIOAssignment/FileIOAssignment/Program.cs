using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIOAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose any number");
            string answer = Console.ReadLine();     
            using (StreamWriter logtoText = new StreamWriter(@"F:\Web Developer\logassignment.txt", false))     //Using the "using" in order to clear the memory after we are done with StreamWriter
            {                                                                                        //Creating a new StreamWriter object that takes as paramenter the location of the file(if it doesn't exist, it will create a new one) and a bool, if true, it will ADD to the file, if false, it will override the previous text
                logtoText.WriteLine(answer);        //Using the object to write the answer to the text file
            }
            string readText = File.ReadAllText(@"F:\Web Developer\logassignment.txt");      //Assigning to readText what is read from the file, taking in the location of the file
            Console.WriteLine("The number that has been read from the text file is " + readText);

            Console.Read();
        }
    }
}
