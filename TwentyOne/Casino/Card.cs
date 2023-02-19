using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public struct Card      //struct is a value type while class is a reference type
    {        
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public override string ToString()       //Override the ToString method that is built in the dotNet
        {
            return String.Format("{0} of {1}", Face, Suit);     //Return the face and suit of the card in player's hands when the method is called
        }
    }
    public enum Suit        //using enums to create the cards that will be part of the deck
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    public enum Face        //using enums to create the cards that will be part of the deck
    {
        Two,
        Three,
        Four,
        Five,
        Six,   
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
