using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public abstract class Game      //Parent class Game
    {
        private List<Player> _players = new List<Player>();     //Instantiating the list of players to make sure it is never null
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();      //Instantiating the dictionary to make sure it is never null
        //Below are props of the Game class
        public List<Player> Players { get { return _players; } set { _players = value; } }      //getting and setting the players into the private list above 
        public string Name { get; set; }
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }       //Creating a dictionary to keep track of bets from players, first parameter is the key, the second paramenter INT is the value (the bets), getting and setting the players and bets into the private dictionary above
        public abstract void Play();        //Abstract method that must be implemented by the class that inherits from Game

        public virtual void ListPlayers()       //A virtual method inside of an abstract class, it means that this method gets inherited by an inherited class but it has the ability to override it
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
