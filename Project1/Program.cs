using System;
using System.IO;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {

        int selection;
        string exit;
        int total = 0;
        int pCounter = 0;

        string name;
        string origin;
        int price;
        string position;
        int rank;
        bool picked;
                        
        string line;

            
            
            int counter = 0;

            List<Player> playerList = new List<Player>();
            List<Player> selectedPlayers = new List<Player>();

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\steantc\source\repos\Project1\playerList.txt");

            while ((line = file.ReadLine()) != null)    {
                string[] variables = line.Split(',');
                name = variables[0];
                origin = variables[1];
                price = Convert.ToInt32(variables[2]);
                position = variables[3];
                rank = Convert.ToInt32(variables[4]);
                picked = false;

                
                        Player aPlayer = new Player(counter, name, origin, price, position, rank, picked);
                        playerList.Add(aPlayer);

                counter++;
            }
            Console.WriteLine("Welcome to the NFL Draft Program! Exit at any time by pressing 'x'. Press any other key to continue");
            exit = Console.ReadLine();
            Console.WriteLine("you may choose up to 5 players and may not exceed 95M in total payouts");
            while (exit != "x")
            {

                playerList.ForEach(x => Console.WriteLine(x.ToString()));

                Console.WriteLine($"you have selected {pCounter} players and have spent ${total}");
                Console.WriteLine("Please enter number for player that you want on your roster");
                
                selection = Convert.ToInt32(Console.ReadLine());
                while (selection < 0 || selection > 39 || playerList[selection].picked == true)
                {
                    Console.WriteLine("Player not availaible or already selected. Please select another Player");
                    selection = Convert.ToInt32(Console.ReadLine());
                }

                

                total += playerList[selection].price;
                if (total > 95000000)
                {
                    Console.WriteLine("You've exceded the max amount of payouts. Please select another player");
                    total -= playerList[selection].price;
                    selection = Convert.ToInt32(Console.ReadLine());
                    if (selection < 0 || selection > 39 || playerList[selection].picked == true)
                    {
                        Console.WriteLine("Player not availaible. Please select another Player");
                        selection = Convert.ToInt32(Console.ReadLine());
                    }
                }
                else
                {
                    selectedPlayers.Add(playerList[selection]);
                    playerList[selection].picked = true;
                }

                Console.WriteLine("Existing Players");
                playerList.ForEach(x => Console.WriteLine(x.ToString()));

                Console.WriteLine("Selected Players");
                selectedPlayers.ForEach(x => Console.WriteLine(x.ToString()));

                pCounter++;

                if (pCounter == 5)
                {
                    Console.Clear();
                    Console.WriteLine("You have reached the maximum amount of players. Here is your roster");
                    selectedPlayers.ForEach(x => Console.WriteLine(x.ToString()));
                    Console.WriteLine("To exit program please press the 'x' key");
                    exit = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("to continue press any button. To exit press 'x'");
                    exit = Console.ReadLine();
                }

            }
            file.Close();
        }
    }
    class Player
    {
        public string name { get; set; }
        public string origin { get; set; }
        public int price { get; set; }
        public string position { get; set; }
        public int rank { get; set; }
        public int counter { get; set; }
        public bool picked { get; set; }

        public Player(int counter, string name, string origin, int price, string position, int rank, bool picked)
        {
            this.counter = counter;
            this.name = name;
            this.origin = origin;
            this.price = price;
            this.position = position;
            this.rank = rank;
            this.picked = picked;
        }

        public override string ToString()
        {
            return String.Format($"{counter} Name:{name}, Origin:{origin}, Price:{price}, Postition{position}, Rank:{rank}");
        }

    }
}
