using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class TwentyOneDealer : Dealer       //Created a separate dealer specific to twentyonegame which inherits from the Dealer parent class
    {
        private List<Card> _hand = new List<Card>();    //Instantiating the list of player's hand first
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }    //Creating a prop hand list of cards for the dealer as dealer will play as well, get and set will now reference the private list above
        public bool Stay { get; set; }      //Creating props for dealer
        public bool isBusted { get; set; }

    }
}
