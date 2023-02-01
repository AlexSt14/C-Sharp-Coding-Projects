using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        string[] textInput = new string[4];
        
        for (int index = 0; index < textInput.Length; index++)
        {
            Console.WriteLine("Add a string to the array");
            textInput[index] = Console.ReadLine();
        }
        for (int show = 0; show < textInput.Length; show++)
        {
            Console.WriteLine(textInput[show]);
        }

        //INFINITE LOOP, commented out otherwise we can't use the console app
        //while (textInput.Length > 0)
        //{
        //    Console.WriteLine(textInput[0]);
        //}

        for (int jj = 0; jj < 1; jj++)
        {
            Console.WriteLine(textInput[jj]);
        }

        for (int jj = 0; jj <= 1; jj++)
        {
            Console.WriteLine(textInput[jj]);
        }
        
        //Creating a list of strings and ask the user to input text to search for a string
        List<string> listText = new List<string>() { "Motorcycle", "Coding", "Swimming", "Mouse", "Phone", "Monitor" };
        Console.WriteLine("Search for a string in the array");
        string search = Console.ReadLine();
        bool mathcExists = false;  //to be able to output a text in case we DID NOT find
        for (int i = 0; i < listText.Count; i++)
        {
            if (listText[i] == search)
            {
                mathcExists = true;
                Console.WriteLine("The string you searched for is " + listText[i]);
                break;
            }
        }
        if (mathcExists == false)
        {
            Console.WriteLine("The string you searched for does not exist");
        }

        List<string> secondList = new List<string>() { "Alex", "Raluca", "Matthew", "Adrian", "Raluca" };
        Console.WriteLine("Search for a string in the array");
        string search2 = Console.ReadLine();
        bool matchExists2 = false;
        for (int e = 0; e < secondList.Count; e++)
        {
            if (secondList[e] == search2)
            {
                matchExists2 = true;
                Console.WriteLine("The indices from the array that corresponds with your search are " + e);                
            }
        }
        if (matchExists2 == false)
        {
            Console.WriteLine("The string that you searched for does not exist");
        }

        //Creating a list of strings that has at least two identical strings in the list
        List<string> thirdList = new List<string>() { "Ring", "Games", "Food", "Games", "Phones", "Games" };
        foreach (string str in thirdList)
        {
            Console.WriteLine(str);    
        }

        Console.ReadLine();
    }
}

