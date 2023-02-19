using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player     //player class for twentyonegame
    {

        public Player(string name, int beginningBalance)        //constructor for the player class which takes in parameters of name and money that they come with
        {
            Hand = new List<Card>();
            Balance = beginningBalance;
            Name = name;
        }

        private List<Card> _hand = new List<Card>();    //Instantiating the new list of hand
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }    //Creating a prop hand list for the player as well, get and set will now reference to the private list above
        //creating props specific to twentyonegame 
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public bool Stay { get; set; }
        public bool Bet(int amount)     //The Bet method that takes in a parameter from the bet that the player makes
        {
            if (Balance - amount < 0)       //If balance minus amount is less than 0 then the bet returns false, not enough money
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                Console.WriteLine("Your current balance is {0}", Balance);      //In case the player does not have enough money, we will show them their balance before asking to bet again
                    return false;  
            }
            else    //Else if the balance after the bet is greater than 0 then we subtract the bet from the balance and return true
            {
                Balance -= amount;
                return true;
            }
        }
        //creating overloading methods for adding or removing players from the game in these are called
        public static Game operator +(Game game, Player player)     
        {
            game.Players.Add(player);
            return game;
        }
        public static Game operator -(Game game, Player player)
        {
            game.Players.Remove(player);
            return game;
        }
    }
}
