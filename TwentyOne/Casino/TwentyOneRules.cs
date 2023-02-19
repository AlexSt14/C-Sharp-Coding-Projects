using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne
{
    public class TwentyOneRules
    {
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()      //creating a dictionary with keys (faces) and values (numbers) of each cards in the game
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1
        };

        private static int[] GetAllPossibleHandValues(List<Card> Hand)       //Method to get all possible values out of a hand, this is useful especially when the player has a hand includin 1 or more Aces
        {
            int aceCount = Hand.Count(x => x.Face == Face.Ace);     //First thing we use a lambda expression to count how many aces does the player have in hand
            int[] result = new int[aceCount + 1];       //Second thing is creating an array result where the possible outcomes are dependent of how many aces the player has + 1 extra outcome
            int value = Hand.Sum(x => _cardValues[x.Face]);     //Using a lambda expression, taking each item from the Hand list, look it up in the dictionary using the face in order to take the value and sum it
            result[0] = value;      //Assign that value to the array
            if (result.Length == 1) return result;      //If the result lenght equals 1 then return result because if there are no aces, the is only one possible result
            for (int i = 1; i < result.Length; i++)     //For each extra result in the array we will do this loop to find out possible results where ace is not 1
            {
                value += (i * 10);      //We take the minimum value and add that to the number of aces (i) multiplied by 10
                result[i] = value;      //We then save that result into the corresponding index in the array
            }
            return result;
        }
        public static bool checkforBlackJack(List<Card> Hand)       //Method in order to check for BlackJack
        {
            int[] possibleValues = GetAllPossibleHandValues(Hand);    //creating an integer array of all possible values and assign to it
            int value = possibleValues.Max();       //Getting the largest value of the possibleValue array using a lambda expression
            if (value == 21) return true;       //If that max value equals 21 then the logic will return that player has blackjack
            else return false;
        }

        public static bool isBusted(List<Card> Hand)        //Method to check if someone busted
        {
            int value = GetAllPossibleHandValues(Hand).Min();       //Assigning to value the minimum value from all possible values and if its greater than 21 then return true
            if (value > 21) return true;
            else return false;
        }

        public static bool ShouldDealerStay(List<Card> Hand)        //Method to be called and check if dealer should stay
        {
            int[] possibleHandValues = GetAllPossibleHandValues(Hand);      //Get the posssible hand values of the hand
            foreach (int value in possibleHandValues)       //Rules for the dealer, going through the possible values, if the value is greater than 16 and value is less than 22 then dealer should stay
            {
                if (value > 16 && value < 22)
                {
                    return true;
                }
            }
            return false;      //Else then return false
        }

        public static bool? CompareHands(List<Card> PlayerHand, List<Card> DealerHand)      //Returns a bool dataype nullable, takes in as parameters two list of cards
        {
            int[] playerResults = GetAllPossibleHandValues(PlayerHand);     //Using the all possible hand values method we created earlier, we get all possible values and assign them to an array
            int[] dealerResults = GetAllPossibleHandValues(DealerHand);     //Same of the dealer's hand
            int playerscore = playerResults.Where(x => x < 22).Max();       //Using lambda expressions we take all those results and filter them where the items in results are lower than 22, creating a temporary list and getting the max of that list and assigns it to playerScore
            int dealerResult = dealerResults.Where(x => x < 22).Max();      //Using lambda expressions we take all those results and filter them where the items in results are lower than 22, creating a temporary list and getting the max of that list and assigns it to dealerScore

            if (playerscore > dealerResult) return true;        //Winning logic, if player hand is greater than dealer hand, the player won, returns true
            else if (playerscore < dealerResult) return false;      //If player hand is less than dealer hand, the player lost, return false
            else return null;       //If none of the above, then return null as bool

        }
    }
}
