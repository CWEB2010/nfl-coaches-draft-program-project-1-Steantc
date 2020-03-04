using System;
using System.IO;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
        int selection; //variable for selecting players
        string exit; //Exit from program variable
        int total = 0; //Total payouts
        int pCounter = 0; //The number of players selected

        string name; //Name for player object
        string origin; //Origin for player object
        int price; //Price for player object
        string position; //Postition for player object
        int rank; //Rank for player object
        bool picked; //Picked field player object

        string line; //Variable for reading lines from file
 
            int counter = 0; //counter for lines read from file

            List<Player> playerList = new List<Player>(); // Creates new list to store player objects
            List<Player> selectedPlayers = new List<Player>(); //Creates new list to store slected players

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\steantc\source\repos\Project1\playerList.txt"); //Brings in playerList.txt to be read by program

            while ((line = file.ReadLine()) != null)    { //keep reading from file until there are no lines
                string[] variables = line.Split(','); // splits the variables up by ','
                name = variables[0]; //Reads Name for Player object
                origin = variables[1]; //Reads Origin for player object
                price = Convert.ToInt32(variables[2]); //Reads Price for player object
                position = variables[3]; //Reads Position for player Object
                rank = Convert.ToInt32(variables[4]); //Reads Rank for player object
                picked = false; //adds picked flag to player object

                        Player aPlayer = new Player(counter, name, origin, price, position, rank, picked); // Passes variables and applies them to the player object
                        playerList.Add(aPlayer);

                counter++; //increaments counter
            }
            Console.WriteLine("Welcome to the NFL Draft Program! Exit at any time by pressing 'x'. Press 'enter' to continue");
            exit = Console.ReadLine(); //reads exit value
            Console.WriteLine("\nyou may choose up to 5 players and may not exceed 95M in total payouts");
            while (exit != "x") //While exit variable isn't 'x' keep program running
            {
                playerList.ForEach(x => Console.WriteLine(x.ToString())); //Displays playerlist to console

                Console.WriteLine($"\nyou have selected {pCounter} players and have spent ${total}"); //Lets user know how many players have been selected and how many payouts have been applied

                Console.WriteLine("\nSelected Players"); //Displays selected players
                selectedPlayers.ForEach(x => Console.WriteLine(x.ToString()));

                Console.WriteLine("\nPlease enter the number for player that you want on your roster and then press 'enter'");
                
                selection = Convert.ToInt32(Console.ReadLine()); //Converts selection to int value
                while (selection < 0 || selection > 39 || playerList[selection].picked == true) //checks to see if selected player number is in range and checks to see if they've been selected yet
                {
                    Console.WriteLine("\nPlayer not availaible or already selected. Please select another Player");
                    selection = Convert.ToInt32(Console.ReadLine()); //Converts selection to int value
                }

                total += playerList[selection].price; //adds new players price to total
                if (total > 95000000) //If total is above 95M the last player won't be added to the selected player list and the program will ask for another selection
                {
                    Console.WriteLine("\nYou've exceded the max amount of payouts. Please select another player or enter any unselected player to display roster");
                    total -= playerList[selection].price;
                    selection = Convert.ToInt32(Console.ReadLine()); //Converts selection to int value
                    if (selection < 0 || selection > 39 || playerList[selection].picked == true) //checks to see if selected player number is in range and checks to see if they've been selected yet
                    {
                        Console.WriteLine("\nPlayer not availaible. Please select another Player");
                        selection = Convert.ToInt32(Console.ReadLine()); //Converts selection to int value
                    }
                }
                else
                {
                    selectedPlayers.Add(playerList[selection]); //If player hasn't been selected, the total for all players hasn't exceeded 95M, and the total players havent exceeded 5 player will be added to selectedPlayer list
                    playerList[selection].picked = true;//Flags selected player as picked
                }

                Console.Clear(); //clears Console

                Console.WriteLine("\nSelected Players"); //Writes selectedPlayers list to console
                selectedPlayers.ForEach(x => Console.WriteLine(x.ToString()));

                pCounter++; //increaments pCounter

                if (pCounter == 5) //if max players or payouts have been achived display roster and prompt user to exit or restart
                {
                    Console.Clear();
                    Console.WriteLine("You have reached the maximum amount of players. Here is your roster\n");
                    selectedPlayers.ForEach(x => Console.WriteLine(x.ToString()));
                    Console.WriteLine("\nTo exit program please press the 'x' key. To restart press enter");
                    exit = Console.ReadLine();
                    selectedPlayers.Clear();
                    playerList.ForEach(x => x.picked = false); //these lines reset all variables conected with selecting players
                    pCounter = 0;
                    total = 0;
                }
                else //keep looping untill above statements have been achived
                {
                    Console.WriteLine("\nto continue press 'enter'. To exit press 'x'");
                    exit = Console.ReadLine();
                    Console.Clear();
                }
            }
            file.Close();
        }
    }
    class Player //class for making player object
    {
        public string name { get; set; }
        public string origin { get; set; }
        public int price { get; set; }
        public string position { get; set; }
        public int rank { get; set; }
        public int counter { get; set; }
        public bool picked { get; set; }

        public Player(int counter, string name, string origin, int price, string position, int rank, bool picked) //constructor for creating player object
        {
            this.counter = counter;
            this.name = name;
            this.origin = origin;
            this.price = price;
            this.position = position;
            this.rank = rank;
            this.picked = picked;
        }
        public override string ToString() //ToString for displying player info
        {
            return String.Format($"{counter} Name:{name}, Origin:{origin}, Price:{price}, Postition{position}, Rank:{rank}");
        }
    }
}
