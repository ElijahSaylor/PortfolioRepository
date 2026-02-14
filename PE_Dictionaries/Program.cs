using System.Diagnostics;

namespace PE_Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random Randy = new Random();

            Dictionary<string,Player> epicDictionary = new Dictionary<string,Player>();

            Player JoeBiden = new Player("Joe Biden", 7);
            Player JohnCena = new Player("Mitch McConnel", -1000000);

            epicDictionary.Add(JoeBiden.Name,JoeBiden);
            epicDictionary.Add(JohnCena.Name, JohnCena);

            Console.WriteLine(epicDictionary[JoeBiden.Name].Name);
            Console.WriteLine(epicDictionary[JohnCena.Name].Name);

            //while (true)
            //{
            //    Console.Write("Please enter the name of a player to search for or enter 'quit' to quit: ");
            //    string userInput = Console.ReadLine()!;

            //    switch (epicDictionary.ContainsKey(userInput))
            //    {
            //        case true:
            //            Console.WriteLine($"{userInput} was found!");
            //            Console.WriteLine(epicDictionary[userInput].ToString());
            //            break;

            //        default:
            //            Console.WriteLine($"{userInput} was not found.");
            //            break;
            //    }

            //    if(userInput == "quit")
            //    {
            //        break;
            //    }
            //}

            Stopwatch stopwatch = new Stopwatch();
            List<Player> playerList = new List<Player>();
            
            epicDictionary.Clear();


            int x = 0;
            while (x < 1000000)
            {
                int nameNumba = Randy.Next(0, 9999999);
                int scoreNumba = Randy.Next(0, 9999999);

                Player newPlayer = new Player("P" + nameNumba, scoreNumba);

                if (epicDictionary.ContainsKey(newPlayer.Name))
                {
                    continue;
                }

                epicDictionary.Add(newPlayer.Name,newPlayer);
                playerList.Add(newPlayer);

                x++;
                //Player thisPlayer = new Player("P");
            }

            Player player1 = playerList[0];
            Player fakePlayer = new Player("Bob Odenkirk", 111);

            stopwatch.Start();

            Console.WriteLine(epicDictionary[player1.Name].ToString());

            stopwatch.Stop();

            Console.WriteLine($"Searching for {player1.Name} in the dictionary");
            Console.WriteLine($"Time Elapsed: {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Reset();

            stopwatch.Start();

            if(epicDictionary.ContainsKey("Bob Odenkirk")) { }

            stopwatch.Stop();

            Console.WriteLine($"Searching for 'Bob Odenkirk'...");
            Console.WriteLine($"Bob Odenkirk not found after {stopwatch.Elapsed.TotalMilliseconds} seconds");

            stopwatch.Reset();

            Player first = playerList[0];

            stopwatch.Start();

            foreach(Player playa in playerList)
            {
                if(playa == first)
                {
                 
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"Searching the whole list for the first element took {stopwatch.Elapsed.TotalMilliseconds}");

            stopwatch.Reset();

            stopwatch.Start();

            foreach (Player playa in playerList)
            {
                if (playa == fakePlayer)
                {

                }
            }

            stopwatch.Stop();

            Console.WriteLine($"Searching the whole list for a fake player took {stopwatch.Elapsed.TotalMilliseconds}");
            
            //foreach(Player playa in playerList)
            //{
            //    Console.WriteLine(playa.ToString());
            //}
        }
    }
}
