using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAssignment
{
    internal class Program
    {
        static void Main()
        {
            //Console.WriteLine("Hello, guess when was the first FIFA World Cup");
            //int number = Convert.ToInt32(Console.ReadLine());    //reading unput
            //bool answer = number == 1930;   //Assigning to what true should be

            //do   //do the switch as long as the bool is false (after switch, while answer is NOT true)
            //{
            //    switch (number)
            //    {
            //        case 1943:
            //            Console.WriteLine("You guessed 1943. Please try again!");
            //            Console.WriteLine("Guess when was the first FIFA World Cup");
            //            number = Convert.ToInt32(Console.ReadLine());
            //            break;
            //        case 1922:
            //            Console.WriteLine("You guessed 1922. Please try again!");
            //            Console.WriteLine("Guess when was the first FIFA World Cup");
            //            number = Convert.ToInt32(Console.ReadLine());
            //            break;
            //        case 1951:
            //            Console.WriteLine("You guessed 1951. Please try again!");
            //            Console.WriteLine("Guess when was the first FIFA World Cup");
            //            number = Convert.ToInt32(Console.ReadLine());
            //            break;
            //        case 1930:
            //            Console.WriteLine("That is correct!! The first FIFA World Cup was held on 1930!");
            //            answer = true;   //When guessed, we move answer to true to break the loop
            //            break;
            //        default:
            //            Console.WriteLine("That is wrong, please try again");
            //            Console.WriteLine("Guess when was the first FIFA World Cup");
            //            number = Convert.ToInt32(Console.ReadLine());
            //            break;

            //    }
            //}
            //while (!answer);   //DO the above switch WHILE answer is NOT true
                           
            //Console.Read();


            Console.WriteLine("Another loop with only while this time, what color am I thinking about right now?");
            string color = Console.ReadLine();

            bool colorChose = color == "red" || color == "Red" || color == "RED";   //It is the same flaw in the program, in case the color is guessed from the first try

            while (!colorChose)
            {
                switch (color)
                {
                    case "Blue":
                        Console.WriteLine("Blue is not the color I am thinking at, try again.");
                        Console.WriteLine("What color am I thinking at?");
                        color = Console.ReadLine();
                        break;
                    case "Black":
                        Console.WriteLine("Black is not the color I am thinking at either, try again.");
                        Console.WriteLine("What color am I thinking at?");
                        color = Console.ReadLine();
                        break;
                    case "red":
                        Console.WriteLine("You are correct! Red is the color I was thinking about!");
                        colorChose = true;
                        break;
                    case "Red":
                        Console.WriteLine("You are correct! Red is the color I was thinking about!");
                        colorChose = true;
                        break;
                    case "RED":
                        Console.WriteLine("You are correct! Red is the color I was thinking about!");
                        colorChose = true;
                        break;
                    default :
                        Console.WriteLine("You are wrong, try again.");
                        Console.WriteLine("What color am I thinking at?");
                        color = Console.ReadLine();
                        break;
                }
                
            }
            
            Console.Read();
            
        }
    }
}
