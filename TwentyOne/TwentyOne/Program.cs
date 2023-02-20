using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Casino;
using Casino.TwentyOne;



namespace TwentyOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "Grand Hotel and Casino";     //Creating a constant as name of the Casino, this will never change       
            Console.WriteLine("Welcome to the {0}. Let's start by telling me your name.", casinoName);
            string playerName = Console.ReadLine();

            bool validAnswer = false;       //In order to catch an exception if player tries to type "50 Pounds" etc, we create a bool first
            int bank = 0;       //Assign the bank to 0
            while (!validAnswer)        //This will always get hit first as validAnswer was already assigned to false
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);       //A bool that returns true or false depending if the int conversion was successfull, it then assigns the int OUT to bank variable
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");      //If for whatever reason validAnswer is still not true (conversion was unsuccessfull) then throw a message to the player to let them aware of it
            }
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);        //placeholder between {} with playerName
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")     //If player says yes, the below logic will happen, if no, it will skip
            {
                Player player = new Player(playerName, bank);     //Creating a new player object and passing the player name and money they bring to the game
                player.Id = Guid.NewGuid();         //A guid is a unique identifier, creating an identifier for each player joining                
                Game game = new TwentyOneGame();        //creating a new TwentyOneGame object through polymorphism
                game += player;     //Adding a player to the game object we just created
                player.isActivelyPlaying = true;    //bool variable which will exit the while loop
                while (player.isActivelyPlaying && player.Balance > 0)      //this loop will happen as long as the bool stays to true
                {
                    try         //Play method in try/catch blocks will handle any exceptions that will happen while playing the game
                    {
                        game.Play();        //the play method from the game object is called
                    }
                    catch (FraudException)      //Created a specific exception rule/class for players that would bet -100 and because of that, it would increase their balance, not decrease it, in case they lose
                    {
                        Console.WriteLine("Security! Kick this person out!");
                        Console.ReadLine();
                        return;     //When typing return into a VOID method, it will END the method (Which is the Main method) meaninig the program will close
                    }
                    catch (Exception)       //A more general catch of an exception in case any other bugs happen
                    {
                        Console.WriteLine("An error occurred. Please contact your System Administrator.");
                        Console.ReadLine();
                        return;     //When typing return into a VOID method, it will END the method (Which is the Main method) meaninig the program will close
                    }
                    
                }
                if (player.Balance == 0)        //If player's balance reaches 0 but they still say they want to continue playing, this will get hit letting them know about their balance
                {
                    Console.WriteLine("You do not have enough balance to continue playing, your current balance is {0}, please consider coming back another time.", player.Balance);
                }
                game -= player;     //if the bool variable switches to false then player wants to quit the game, we subtract the player object from the game 
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            
            Console.Read();
        }
    }
}
