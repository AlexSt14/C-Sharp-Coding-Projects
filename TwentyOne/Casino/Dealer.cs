using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer     //Dealer parent class
    {
        public string Name { get; set; }    //Props for dealer
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)       //Deal method that is called in play method of games, passing in as paramenter a list of cards Hand
        {
            Hand.Add(Deck.Cards.First());       //Adding to that list of cards Hand, the first card in the deck            
            Console.WriteLine(Deck.Cards.First().ToString() + "\n");    //will display that first card to the console            
            Deck.Cards.RemoveAt(0);     //Removing that card from the original deck as its now in the player's hand
        }
    }
}
