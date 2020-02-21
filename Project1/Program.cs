using System;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
        string name;
        string origin;
        int price;
        string position;
        int rank;

            string playerName;


            
            string line;
            int counter = 0;

            List<Player> playerList = new List<Player>();
            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\steantc\source\repos\Project1\playerList.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] variables = line.Split(',');
                name = variables[0];
                origin = variables[1];
                price = Convert.ToInt32(variables[2]);
                position = variables[3];
                rank = Convert.ToInt32(variables[4]);

                
                        Player aPlayer = new Player(name, origin, price, position, rank);
                        playerList.Add(aPlayer);
                    
                //Player player = new Player(name, origin, price, position, rank);

                //playerVars[0](name, origin, price, position, rank);


                //System.Console.WriteLine("{0} {1}", origin, name);
                counter++;
                playerList.ForEach(x => Console.WriteLine(x.ToString()));
                //foreach (var x in playerList)
                //    Console.WriteLine(x);

            }

            file.Close();

            

            //Player aPlayer = new Player();
            




        }
    }
    class Player
    {
        public string name { get; set; }
        public string origin { get; set; }
        public int price { get; set; }
        public string position { get; set; }
        public int rank { get; set; }

        //public Player();
        //{
        //    //this.name = "name";
        //    //this.origin = "origin";
        //    //this.price = 00;
        //    //this.position = "position";
        //    //this.rank = 00;
        //    }

        public Player(string name, string origin, int price, string position, int rank)
        {
            this.name = name;
            this.origin = origin;
            this.price = price;
            this.position = position;
            this.rank = rank;
        }

        public override string ToString()
        {
            return String.Format($"Name:{name}, Origin:{origin}, Price:{price}, Postition{position}, Rank:{rank}");
        }

    }
}
