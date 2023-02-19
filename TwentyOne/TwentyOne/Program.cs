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
            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();
            Console.WriteLine("And how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);        //placeholder between {} with playerName
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")     //If player says yes, the below logic will happen, if no, it will skip
            {
                Player player = new Player(playerName, bank);     //Creating a new player object and passing the player name and money they bring to the game
                Game game = new TwentyOneGame();        //creating a new TwentyOneGame object through polymorphism
                game += player;     //Adding a player to the game object we just created
                player.isActivelyPlaying = true;    //bool variable which will exit the while loop
                while (player.isActivelyPlaying && player.Balance > 0)      //this loop will happen as long as the bool stays to true
                {
                    game.Play();        //the play method from the game object is called
                }
                if (player.Balance == 0)     //If player balance reaches 0 then right after the while loop breaks, we will display this message to let the player know that even if he types yes that he wants to play again, he doesn't have enough balance to continue
                {   
                    Console.WriteLine("You do not have enough money to play another round, please consider coming back another time.");
                }
                game -= player;     //if the bool variable switches to false then player wants to quit the game, we subtract the player object from the game 
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            
            Console.Read();
        }
    }
}
