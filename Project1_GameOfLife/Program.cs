using System.ComponentModel.Design;

namespace Project1_GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            Game game = new Game();
            string saveFile = "";

            // 1. prompt user for input: random board, display board, load board, play (runs for set number of iterations,
            // or until nothing is alive), and quit.

        Menu:
            Console.Write("Greetings! Welcome to Elijah's game of life!\n" +
                "Here are your options:\n" +
                "1. Generate random board\n" +
                "2. Load board\n" +
                "3. Display board\n" +
                "4. Quit\n" +
                "Please enter your input as an integer: ");

        // Menu Input validation
            //while (userInput != "5")
            {
                userInput = Console.ReadLine()!;
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Generating a random game board...");
                        game.GenerateBoard();
                        game.DisplayBoard();

                        break;
                    case "2":
                        Console.Write("Please enter the name of the file you would like to save to (include extension!): ");
                        saveFile = Console.ReadLine()!;

                        try { 
                            game.LoadBoard("../../../" + saveFile);
                            Console.WriteLine("File Loaded!");
                            game.DisplayBoard();
                        }
                        catch { Console.WriteLine("Error loading file! Please check spelling and make sure the file" +
                            "is located in the same directory as the project solution file."); }
                        
                        //game.GenerateBoard(3, 5);
                        
                        break;
                    case "3":
                        game.DisplayBoard();
                        break;

                    case "4":
                        Console.WriteLine("Bye Bye!");
                        break;

                    default:
                        Console.Write("Error, invalid input! Please try again with a numeric integer: ");
                        break;
                }
            }
           

            while(userInput != "4")
            {
                Console.WriteLine("What would you like to do next?\n" +
                    "1. Advance the board\n" +
                    "2. Save the board\n" +
                    "3. Main Menu\n" +
                    "4. Quit");
                userInput = Console.ReadLine()!;

                switch (userInput) 
                {
                    case "1":
                        game.Advance();
                        game.DisplayBoard();
                        break;
                    case "2":
                        Console.Write("Please enter the name of the file you would like to save to (include extension!): ");
                        saveFile = Console.ReadLine()!;
                        game.SaveBoard("../../../" + saveFile);
                        Console.WriteLine("File Saved!");
                        break;
                    case "3":
                        goto Menu; //imsorrypleasedontbemadimsorrypleasedontbemadimsorrypleasedontbemadimsorrypleasedontbemadimsorrypleasedontbemadimsorrypleasedontbemadimsorrypleasedontbemadimsorrypleasedontbemad
                    case "4":
                        Console.WriteLine("Bye Bye!");
                        break;
                }
            }
        }
    }
}
