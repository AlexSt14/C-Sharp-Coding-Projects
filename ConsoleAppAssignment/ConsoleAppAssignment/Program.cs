using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        //Console App Assignment Part 1
        string[] textInput = new string[4] { "Alex", "Raluca", "Denisa", "Matthew" };

        for (int index = 0; index < textInput.Length; index++)
        {
            Console.WriteLine("Concatenate a string to the existing string in the Array");
            string input = Console.ReadLine();
            textInput[index] = textInput[index] + ", " + input;
        }
        for (int show = 0; show < textInput.Length; show++)
        {
            Console.WriteLine(textInput[show]);
        }

        //Console App Assignment Part 2
        //Initially I had an infinite loop, while (textInput.Lenght > 0), fixed it with a foreach loop
        foreach (string s in textInput)
        {
            Console.WriteLine(s);
        }

        //Console App Assignment Part 3
        for (int jj = 0; jj < 1; jj++)
        {
            Console.WriteLine(textInput[jj]);
        }

        for (int jj = 0; jj <= 1; jj++)
        {
            Console.WriteLine(textInput[jj]);
        }

        //Console App Assignment Part 4
        //Creating a list of strings and ask the user to input text to search for a string
        List<string> listText = new List<string>() { "Motorcycle", "Coding", "Swimming", "Mouse", "Phone", "Monitor" };
        Console.WriteLine("Search for a string in the array");
        string search = Console.ReadLine();
        bool mathcExists = false;  //to be able to output a text in case we DID NOT find a match
        for (int i = 0; i < listText.Count; i++)
        {
            if (listText[i] == search)
            {
                mathcExists = true;
                Console.WriteLine("The index of the string you searched for is " + i);
                break;
            }
        }
        if (mathcExists == false)
        {
            Console.WriteLine("The string you searched for does not exist");
        }

        //Console App Assignment Part 5
        List<string> secondList = new List<string>() { "Alex", "Raluca", "Matthew", "Adrian", "Raluca" };
        Console.WriteLine("Search for a string in the array");
        string search2 = Console.ReadLine();
        bool matchExists2 = false;
        for (int e = 0; e < secondList.Count; e++)
        {
            if (secondList[e] == search2)
            {
                matchExists2 = true;
                Console.WriteLine("The indices from the list that corresponds with your search are " + e);
            }
        }
        if (matchExists2 == false)
        {
            Console.WriteLine("The string that you searched for does not exist");
        }

        //Console App Assignment Part 6
        //Creating a list of strings that has at least two identical strings in the list
        List<string> thirdList = new List<string>() { "Ring", "Games", "Food", "Games", "Phones", "Games" };
        List<string> compareList = new List<string>();

        foreach (string str in thirdList)
        {            
            if (compareList.Contains(str))
            {
                Console.WriteLine("String " + str + " has already appeared on the first list");
            }
            else
            {
                compareList.Add(str);
            }                     
        }
        
        
        Console.ReadLine();
    }
}

