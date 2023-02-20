using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Casino;
using Casino.TwentyOne;
using System.Data.SqlClient;
using System.Data;

namespace TwentyOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "Grand Hotel and Casino";     //Creating a constant as name of the Casino, this will never change       
            Console.WriteLine("Welcome to the {0}. Let's start by telling me your name.", casinoName);
            string playerName = Console.ReadLine();
            if (playerName.ToLower() == "admin")        //Creating a way to check the exceptions in console, if user says the name is admin, then the below gets hit
            {
                List<Exception_Entity> Exceptions = ReadExceptions();       //Creating a list with data type of the class Exception Entity, calling in the method that will read from the database
                foreach (var exception in Exceptions)       //foreach loop in order to show on console the exceptions that were read from the database
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | ");
                    Console.WriteLine();
                }
                Console.ReadLine();
                return;     //If user chose admin, the program will stop here with the exceptions showing on screen
            }

            bool validAnswer = false;       //In order to catch an exception if player tries to type "50 Pounds" etc, we create a bool first
            int bank = 0;       //Assign the bank to 0
            while (!validAnswer)        //This will always get hit first as validAnswer was already assigned to false
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);       //A bool that returns true or false depending if the int conversion was successfull, it then assigns the int OUT to bank variable
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");      //If for whatever reason validAnswer is still not true (conversion was unsuccessfull) then throw a message to the player to let them aware of it
            }
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);        //placeholder between {} with playerName
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")     //If player says yes, the below logic will happen, if no, it will skip
            {
                Player player = new Player(playerName, bank);     //Creating a new player object and passing the player name and money they bring to the game
                player.Id = Guid.NewGuid();         //A guid is a unique identifier, creating an identifier for each player joining
                using (StreamWriter file = new StreamWriter(@"D:\log.txt", true))     //using the "using" at the start, we make sure the memory gets cleaned up after we are done, creating a new streamwriter object, taking in the path where the text file is and takes another 
                {                                                                                   //argument "true" where it says "yes, I do want to append to the log file"
                    file.WriteLine(player.Id);       //Logging the date and time of each card that the dealer has given to the player                    
                }
                Game game = new TwentyOneGame();        //creating a new TwentyOneGame object through polymorphism
                game += player;     //Adding a player to the game object we just created
                player.isActivelyPlaying = true;    //bool variable which will exit the while loop
                while (player.isActivelyPlaying && player.Balance > 0)      //this loop will happen as long as the bool stays to true
                {
                    try         //Play method in try/catch blocks will handle any exceptions that will happen while playing the game
                    {
                        game.Play();        //the play method from the game object is called
                    }
                    catch (FraudException ex)      //Created a specific exception rule/class for players that would bet -100 and because of that, it would increase their balance, not decrease it, in case they lose
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDbWithException(ex);      //Calling the method that will updated the database with all exceptions including name and timestamp of that exception
                        Console.ReadLine();
                        return;     //When typing return into a VOID method, it will END the method (Which is the Main method) meaninig the program will close
                    }
                    catch (Exception ex)       //A more general catch of an exception in case any other bugs happen
                    {
                        Console.WriteLine("An error occurred. Please contact your System Administrator.");
                        UpdateDbWithException(ex);      //Calling the method that will updated the database with all exceptions including name and timestamp of that exception
                        Console.ReadLine();
                        return;     //When typing return into a VOID method, it will END the method (Which is the Main method) meaninig the program will close
                    }
                    
                }
                if (player.Balance == 0)        //If player's balance reaches 0 but they still say they want to continue playing, this will get hit letting them know about their balance
                {
                    Console.WriteLine("You do not have enough balance to continue playing, your current balance is {0}, please consider coming back another time.", player.Balance);
                }
                game -= player;     //if the bool variable switches to false then player wants to quit the game, we subtract the player object from the game 
                Console.WriteLine("Thank you for playing!");
            }
            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            
            Console.Read();
            
        }
        private static void UpdateDbWithException(Exception ex)     //Creating a method in order to connect to the database
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TwentyOneGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";     //connection string, right click on database, properties and then copy connection string
            string queryString = "INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) VALUES (@ExceptionType, @ExceptionMessage, @TimeStamp)";       //SQL command that needs to be inserted, VALUES are not entered in here because of SQL Injection, we won't take user input straight away, I am putting a placeholder
            using (SqlConnection connection = new SqlConnection(connectionString))      //Creating a new SQL Connection 
            {
                SqlCommand command = new SqlCommand(queryString, connection);       //Creating a SQL Command, passing in our query string as well as our connection
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);        //Adding a parameter, naming the data type, this way we can be protected by SQL Injection
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);     //Adding a parameter, naming the data type, this way we can be protected by SQL Injection
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);       //Adding a parameter, naming the data type, this way we can be protected by SQL Injection
                
                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();       //Adding the value
                command.Parameters["@ExceptionMessage"].Value = ex.Message;    //Adding the value
                command.Parameters["@TimeStamp"].Value = DateTime.Now;              

                connection.Open();      //Opening the connection
                command.ExecuteNonQuery();      //Executing the command, NON query because its not a SELECT statement
                connection.Close();     //CLosing the connection
            }
        }
        private static List<Exception_Entity> ReadExceptions()      //Method that will read from the database
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TwentyOneGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";     //Connection string to the database
            string queryString = @"SELECT Id, ExceptionType, ExceptionMessage, TimeStamp FROM Exceptions";      //Query string, what will we do in the database
            List<Exception_Entity> exceptions = new List<Exception_Entity>();       //Creating a LIST that will be returned back to the object that called the method
            using (SqlConnection connection = new SqlConnection(connectionString))      //Opening an SQL connection with USING in order to clear resources after we finished
            {
                SqlCommand command = new SqlCommand(queryString, connection);       //Creating a new SQL command, passing in the query string we will do in the Database and the connection we just created
                connection.Open();                                                  //Opening the connection
                SqlDataReader reader = command.ExecuteReader();                 //Creating a new sql data reader object that will execute reading, going through each record of the database
                while (reader.Read())       //Creating a while loop, while the reader is reading, the below loops
                {
                    Exception_Entity exception = new Exception_Entity();        //Creating a new object for each record
                    exception.Id = Convert.ToInt32(reader["Id"]);       //Mapping the property of the object to the column in the database
                    exception.ExceptionType = reader["ExceptionType"].ToString();       //mapping the property of the object to the column in the database
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();    //..
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    exceptions.Add(exception);      //Adding to the list we created above, each exception that is created
                }
                connection.Close();             //Closing the connection
            }
            return exceptions;      //Return back the list
        }
    }
}
