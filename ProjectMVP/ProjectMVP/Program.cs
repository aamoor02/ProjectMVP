using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVP
{
    class Program
    {
        static void Main(string[] args)
        {

            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "players.json");
            var choice = DisplayMenu();


            if (choice == 1)
            {
                var players = DeserializePlayers(fileName);
                foreach (var player in players)
                {
                    Console.WriteLine("The players name is" + " " + player.Name);
                    Console.WriteLine("The players team is" + " " + player.Team);
                    Console.WriteLine("The players points per game is" + " " + player.PointsPerGame);
                    Console.WriteLine("The players rebounds per game is" + " " + player.ReboundsPerGame);
                    Console.WriteLine("The players steals per game is" + " " + player.StealsPerGame);
                    Console.WriteLine("The players assist per game is" + " " + player.AssistsPerGame);
                    Console.WriteLine("The player won the MVP in the year" + " " + player.Year);

                }
            }
            else if (choice == 2)
            {


                var players = DeserializePlayers(fileName);
                //instantiate the new player object
                Player player = new Player();

                //prompt the user for the ID of the player
                Console.WriteLine("What is the ID of the Player?");
                player.ID = Convert.ToInt32(Console.ReadLine());

                //prompt the user for the name of the player
                Console.Write("What is the full name of the player? : ");
                //read the input from the console as the player's name
                player.Name = Console.ReadLine();

                //prompt the user for the team name
                Console.Write("What was the player's team the year they won the MVP? ");
                //read the input from the console as the team name
                player.Team = Console.ReadLine();

                //prompt the user for the points per game
                Console.Write("What was the player's points per game the year they won the MVP? ");
                //read the input from the console as the team name
                player.PointsPerGame = Convert.ToDouble(Console.ReadLine());

                //prompt the user for the rebounds per game
                Console.Write("What was the player's rebounds per game the year they won the MVP? ");
                //read the input from the console as the team name
                player.ReboundsPerGame = Convert.ToDouble(Console.ReadLine());

                //prompt the user for the assist per game
                Console.Write("What was the player's assist per game the year they won the MVP? ");
                //read the input from the console as the team name
                player.AssistsPerGame = Convert.ToDouble(Console.ReadLine());

                //prompt the user for the steals per game
                Console.Write("What was the player's steals per game the year they won the MVP? ");
                //read the input from the console as the team name
                player.StealsPerGame = Convert.ToDouble(Console.ReadLine());

                //prompt the user for the year 
                Console.Write("What was the year they won the MVP? ");
                //read the input from the console as the team name
                player.Year = Convert.ToInt32(Console.ReadLine());

                players.Add(player);
                AddPlayer(players, "players.json");






            }
            else if (choice == 3)
            {
                Console.WriteLine("What is the ID of the player you want to delete?");
                var id = Convert.ToInt32(Console.ReadLine());
                var updatedList = DeletePlayer(id, fileName);
                AddPlayer(updatedList, fileName);




            }
            else if (choice == 4)
            {
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You did not make a valid selection");
                Console.WriteLine("Please try again");



            }

        }


        //This method will return a list of players
        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            //instantiate a new Json Serializer object
            var serializer = new JsonSerializer();

            //wrapping this code in a using statement will tell the compiler to cleanup the object when finished
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                //assings the result of the deserialization to players
                players = serializer.Deserialize<List<Player>>(jsonReader);
            }

            return players;
        }

        //This method will allow the user to adda new player to the file
        public static void AddPlayer(List<Player> players, string fileName)
        {

            var serializer = new JsonSerializer();

            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);

            }

        }

        //Displays the inital menu upon startup
        public static int DisplayMenu()
        {
            int choice = 0;
            do
            {

                Console.WriteLine("Welcome to MVP. This Program will list the 5 most recent NBA Most Valuable Player");
                Console.WriteLine("You can also update the list with any MVP for any years past");
                Console.WriteLine("Let's get started!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. View the list?");
                Console.WriteLine("2. Add a player to the list?");
                Console.WriteLine("3. Delete a Player");
                Console.WriteLine("4. Exit the program.");
                choice = Convert.ToInt32(Console.ReadLine());
                return choice;
            }
            while (choice != 4);


        }

        //Will allow the user to delete a player from the list
        public static List<Player> DeletePlayer(int id, string fileName)
        {

            var list = new List<Player>();
            var players = DeserializePlayers(fileName);
            foreach (var player in players)
            {
                if (id != player.ID)
                {
                    list.Add(player);
                }




            }
            return list;






        }

    }
}