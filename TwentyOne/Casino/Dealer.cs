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
            string card = string.Format(Deck.Cards.First().ToString() + "\n");      //the string card will be logged to a text file every time the dealer is dealing a card
            Console.WriteLine(card);    //will display that first card to the console
            using (StreamWriter file = new StreamWriter(@"F:\Web Developer\log.txt", true))     //using the "using" before, we make sure the memory gets cleaned up after we are done, creating a new streamwriter object, taking in the path where the text file is and takes another 
            {                                                                                   //argument "true" where it says "yes, I do want to append to the log file"
                file.Write(DateTime.Now);       //Logging the date and time of each card that the dealer has given to the player
                file.WriteLine(card);       //By using this, we will write the card string to the text file, the card string will be the card that the dealer is dealing
            }
                Deck.Cards.RemoveAt(0);     //Removing that card from the original deck as its now in the player's hand
        }
    }
}
