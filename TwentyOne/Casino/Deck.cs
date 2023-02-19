using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        public Deck()   //This is a constructor
        {
            Cards = new List<Card>();

            for (int i = 0; i < 13; i++)        //Utilizing enums and creating a deck of cards based on that
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }
        }
        public List<Card> Cards { get; set; }       //This is property of the class
        public void Shuffle(int times = 1)  //creating an optional parameter "times" apart from the deck parameter, to be able to shuffle more times if a parameter is given
        {                
            for (int i = 0; i < times; i++)     //shuffle method for the deck of cards which takes in the times parameter to establish how many times will this loop go for
            {                
                List<Card> tempList = new List<Card>();     //creating a new list of cards which is temporary for this loop
                Random random = new Random();       //creating a random number

                while (Cards.Count > 0)     //this loop will go while there are cards in the Cards list
                {
                    int randomIndex = random.Next(0, Cards.Count);      //Assigning a random number to the index between 0 and the count of the Cards list
                    tempList.Add(Cards[randomIndex]);       //Using that number as an index to add the card at that index to the new list
                    Cards.RemoveAt(randomIndex);        //Using that number as an index to remove the card from the Card list
                }
                Cards = tempList;       //Once there are no more cards in the Cards list, we will assign the tempList to the Cards list
            }                 
        }
    }
}
