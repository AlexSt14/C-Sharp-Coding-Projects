using Casino;
using Casino.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Casino.TwentyOne
{
    public class TwentyOneGame : Game, IWalkAway        //twentyonegame object that inherits from the parent class Game and from the interface IWalkAway
    {
        public TwentyOneDealer Dealer { get; set; }     //prop for the dealer in twentyonegame
        
        public override void Play()     //the play method which is inherited from the parent class Game, this must be implemented in any game that inherits from Game class
        {
            Dealer = new TwentyOneDealer();     //creating a new twentyonedealer
            foreach (Player player in Players)      //foreach loop to reset all cards in the players hands and set the stay to false;
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>();     //giving the dealer a new hand each play
            Dealer.Stay = false;        
            Dealer.Deck = new Deck();       //giving the dealer a new deck each play
            Dealer.Deck.Shuffle();            
            foreach (Player player in Players)      //in order for all players to place a bet we will go through the list of all players
            {
                bool validAnswer = false;       //Creating a bool variable and assign it to false, will use this to handle exceptions in case a player would type 50 Dollars instead of 50, when placing a bet
                int bet = 0;
                while (!validAnswer)        //The while loop will always get hi first because validAnswer was set to false above the loop
                {
                    Console.WriteLine("Place your bet!");   
                    validAnswer = int.TryParse(Console.ReadLine(), out bet);        //int.TryParse is a method that returns a bool and checks if the conversion to int was successfull, after that, it will assign the int OUT to bet
                    if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");      //If validAnswer is still false, then we throw a message to the player to let them know about the error
                }
                if (bet < 0) throw new FraudException();        //Creating an IF exception for FraudException class specific to players that try and cheat the Casino, so they cannot bet on negative numbers, making them win money while losing the game
                bool successfullyBet = player.Bet(bet);     //creating a bool that will call the Bet method, passing in the parameter input from the player, if Player does not have enough amount, this will return false
                if (!successfullyBet) return;      //if the bool logic performed in the Bet Method is false, then close the method and return back to start                
                Bets[player] = bet;     //if the bool logic is true then we will add to the dictionary Bets the Key:Value pairs of each players bets, in order to keep track of the bets
            }
            for (int i = 0; i < 2; i++)     //the next step would be to deal to players the necessary cards, we do that through a foreach loop nested in a for loop, using the for loop first, for this to happen twice (2 cards per player)
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)      //for each player in the players list, we will deal a card
                {
                    Console.Write("{0}: ", player.Name);        //will write that to the console but will not automatically jump to a new line, the next code will continue on the same line
                    Dealer.Deal(player.Hand);       //calling in the deal method from the Dealer class, giving in as parameter the hand list of the player
                    if (i == 1)     //checking if right after the deal, any player has blackjack, i == 1 because this would be the second for loop (which is the end of the deal for that player)
                    {
                        bool blackJack = TwentyOneRules.checkforBlackJack(player.Hand);     //Creating a bool that calls the method to check for BlackJack
                        if (blackJack)      //If BlackJack is true, then perform below
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);    //Returning players name and bets winning
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);     //Adding the bet to player's balance
                            Console.WriteLine("{0}'s new balance is {1}", player.Name, player.Balance);       //Showing the balance to the console
                            Console.WriteLine("Do you want to play again?");
                            string answer = Console.ReadLine().ToLower();
                            if (answer == "yes" || answer == "yeah")       //Asking player if still wants to play after blackjack
                            {
                                player.isActivelyPlaying = true;
                                return;
                            }
                            else
                            {
                                player.isActivelyPlaying = false;
                                break;
                            }                             
                        }
                    }

                }
                Console.Write("Dealer: ");  
                Dealer.Deal(Dealer.Hand);       //Dealer is dealing his hand
                if (i == 1)     //need to check the dealer for BlackJack at the end of his deal that's why i == 1
                {
                    bool blackJack = TwentyOneRules.checkforBlackJack(Dealer.Hand);     //Calling BlackJack method to check if true
                    if (blackJack)      //If true, then below will hit
                    {
                        Console.WriteLine("Dealer has BlackJack! Evveryone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)       //Iterating through Dictionary calling it entry in the bets
                        {
                            Dealer.Balance += entry.Value;      //Adding the bets of all entry values to dealer's balance
                        }
                        foreach (Player player in Players)      //creating this loop in order to show the balance of each player and then ask the players if they want to continue playing after dealer got blackjack
                        {
                            Console.WriteLine("{0}'s new balance is {1}", player.Name, player.Balance);     
                            Console.WriteLine("Play again?");
                            string answer = Console.ReadLine().ToLower();
                            if (answer == "yes" || answer == "yeah")
                            {
                                player.isActivelyPlaying = true;
                                return;
                            }
                            else
                            {
                                player.isActivelyPlaying = false;
                                break;
                            }
                        }
                        return;
                    }
                }
            }
            foreach (Player player in Players)      //Go through each player and ask them 
            {
                while (!player.Stay)        //While player Stay is false
                {
                    Console.WriteLine("Your cards are: ");      
                    foreach (Card card in player.Hand)      //Method to show the player the cards that he has
                    {
                        Console.WriteLine("{0} ", card.ToString());     //calling the overrided method of Card class
                    }
                    Console.WriteLine("\n\nHit or stay?");
                    string answer = Console.ReadLine().ToLower();       //taking input of answer from the player
                    if (answer == "stay")       //If answer is stay the change the Stay bool to true
                    {
                        player.Stay = true;
                        break;      //Break the loop if this is hit
                    }
                    else if (answer == "hit")       //Else if answer is hit then dealer will deal another card to player's hand
                    {
                        Console.WriteLine("Dealing...");
                        Dealer.Deal(player.Hand);                        
                    }
                    bool busted = TwentyOneRules.isBusted(player.Hand);     //Everytime a player receives a card, we check if player is busted
                    bool blackJack = TwentyOneRules.checkforBlackJack(player.Hand);      //Everyime a player receives a card, we check if the player has BlackJack
                    if (busted)     //If busted is true then below gets hit
                    {
                        Dealer.Balance += Bets[player];     //Dealer receives the player's bet accessing that through the Bets dictionary
                        Console.WriteLine("{0} Busted! You lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance); 
                        Console.WriteLine("Do you want to play again?");
                        answer = Console.ReadLine().ToLower();      
                        if (answer == "yes" || answer == "yeah")    //If player answer is yes then the player bool isActivelyPlaying is true, else its going to be false
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                            return;
                        }
                    }
                    if (blackJack)      //If BlackJack is true, then perform below
                    {
                        Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);    //Returning players name and bets winning
                        player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);     //Adding the bet to player's balance
                        Console.WriteLine("{0}'s new balance is {1}", player.Name, player.Balance);       //Showing the balance to the console
                        Console.WriteLine("Do you want to play again?");
                        string answer1 = Console.ReadLine().ToLower();
                        if (answer1 == "yes" || answer1 == "yeah")       //Asking player if still wants to play after blackjack
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                            break;
                        }
                    }
                }
            }
            Dealer.isBusted = TwentyOneRules.isBusted(Dealer.Hand);     //After all players gets their hands, dealer needs to be checked if he busted
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);     //Calling the method of the dealershould stay, passing in the dealer's hand
            while (!Dealer.Stay && !Dealer.isBusted)        //While the stay and isbusted is false then the below is hit
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);       //Dealer deals another card to his hand
                Dealer.isBusted = TwentyOneRules.isBusted(Dealer.Hand);     //THe isbusted is checked again in order to see if the dealer busted with the new card
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);     //THe shoulddealerstay rule is checked again in order to see if the rule is meet for Stay
            }
            if (Dealer.Stay)       //If dealer is staying the below is hit
            {
                Console.WriteLine("Dealer is staying.");
                Console.WriteLine("\nDealer's hand is:");
                foreach (Card card in Dealer.Hand)      //Before showing who wins, we will show Dealer's hand as well just for clarity
                {
                    Console.WriteLine("{0}", card.ToString());      //Calling the ToString Override method that will display the Suit and Face of each card
                }
            }
            if (Dealer.isBusted)        //If dealer is busted then below is hit
            {
                Console.WriteLine("Dealer Busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)       //Iterating through the dictionary of bets and taking the entries
                {
                    Console.WriteLine("\n{0} won {1}!", entry.Key.Name, entry.Value);     //Write to the console by placeholder, the name and the bet value of each player
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);      //Using lambda expression, where produces a list where the name equals with the name in the Bets Dictionary, taking that First time in the list, taking its balance and adding to balance the Value of the bet multiplied by 2 (Giving his initial bet back plus the bet he won)
                    Dealer.Balance -= entry.Value;      //Subtracting the value from the dealer's balance                    
                }
                foreach (Player player in Players)      //After the dealer is busted, we go through each player again and show them their balance and ask them if they want to play agian, if not then the isActivelyPlaying becomes false and breaks the while loop from the main method
                {
                    Console.WriteLine("{0}'s balance is now {1}", player.Name, player.Balance);
                    Console.WriteLine("Play again?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes" || answer == "yeah") player.isActivelyPlaying = true;
                    else player.isActivelyPlaying = false;
                }
                return;     //If this get hits is because the dealer busted and so the game must end and while loop from the main program will check conditional statements again
            }
            foreach (Player player in Players)      //The foreach loop will check in case everyone stays and no one busted
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);     //By tipying bool? with questionmark the bool dataype changes to nullable bool, calling in the method to compare, giving as parameters the player's hand and the dealer's hand
                if (playerWon == null)      //If return is null, then it is a tie, no one won and each player gets his initial bet back to his balance
                {
                    Console.WriteLine("\nPush! No one wins.");
                    player.Balance += Bets[player];                    
                }
                else if (playerWon == true)     //If reutn is true then player wins and gets his bet back multiplied by two (because one is the initial bet that needs to be added back and the second one are the winnings, then subtracting that amount from dealer's balance
                {
                    Console.WriteLine("\n{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];                    
                }
                else        //Else means its false and that means the dealer wins, each bet of all players is added to the dealer's balance
                {
                    Console.WriteLine("\nDealer wins {0}", Bets[player]);
                    Dealer.Balance += Bets[player];
                }
                Console.WriteLine("Your new balance is {0}", player.Balance);     //showing their new balance before asking them if they want to play again
                Console.WriteLine("Play again?");       //Checking to see if players want to play again
                string answer = Console.ReadLine().ToLower();       
                if (answer == "yes" || answer == "yeah")        //If they type yes then isActivelyPlaying stay true and that keeps us in the while loop for the Play() method, else its false and the Play() method won't be called again
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
                }
            }
            

        }
        public void WalkAway(Player player)     //The WalkAway method which is inherited from the Interface IWalkAway, this must be implemented in any game that inherits from IWalkAway
        {
            throw new NotImplementedException();
        }
        public override void ListPlayers()      //inherited method from the parent Game class
        {
            Console.WriteLine("21 players:");
            base.ListPlayers();
        }
    }
}
