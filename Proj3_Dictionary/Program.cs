namespace SaylorE_Proj3_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This is me thinking out loud
            // Dictionaries are basically fancy jagged arrays
            // Key -> hash function -> result/count = index -> add to the list at that index



            // Project setup
            CustomDictionary<string, string> testDictionary =
            new CustomDictionary<string, string>(5);

            string userInput = "";

            // Call the Menu once
            Menu();

            // Allow user to continually choose options
            while (userInput != "DONE")
            {
                try
                {
                    userInput = UserChoice();
                    ExecuteChoice(userInput, testDictionary);
                    Console.WriteLine();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
            }
        }


        /// <summary>
        /// Prints the menu
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine("Choose from the following options:");
            Console.WriteLine("  'Done'   - Quits the program");
            Console.WriteLine("  'Count'  - Number of dictionary entries");
            Console.WriteLine("  'Load'   - Load factor ratio");
            Console.WriteLine("  'Add'    - Adds a dictionary entry");
            Console.WriteLine("  'Get'    - Retrieves an entry");
            Console.WriteLine("  'Set'    - Resets an entry");
            Console.WriteLine("  'Remove' - Deletes a dictionary entry");
            Console.WriteLine("  'Clear'  - Empties the dictionary");
            Console.WriteLine("  'Debug'  - Prints debugging data");
            Console.WriteLine("  'Menu'   - Reprint the menu");
        }


        /// <summary>
        /// Retrieves the user's choice
        /// </summary>
        /// <returns>String of user's choice</returns>
        public static string UserChoice()
        {
            Console.Write("Enter your choice: ");
            return Console.ReadLine().Trim().ToUpper();
        }


        /// <summary>
        /// Rus the appropriate code for all of the user's options.
        /// </summary>
        /// <param name="option">User's option as a strint</param>
        /// <param name="dictObj">Custom dictionary object</param>
        public static void ExecuteChoice(string option, CustomDictionary<string, string> dictObj)
        {
            string key;
            string val;

            switch (option)
            {
                case "DONE":
                    Console.WriteLine("Thanks for playing!");
                    break;

                case "COUNT":
                    Console.WriteLine("There are {0} entries in the dictionary.", dictObj.Count);
                    break;

                case "LOAD":
                    Console.WriteLine($"Load factor is {dictObj.LoadFactor}.");
                    //Console.WriteLine("Load factor is {0}.", dictObj.LoadFactor);
                    break;

                case "ADD":
                    Console.WriteLine("Adding a new entry.");
                    Console.Write("  Enter the key: ");
                    key = Console.ReadLine().Trim();
                    Console.Write("  Enter the value: ");
                    val = Console.ReadLine().Trim();
                    dictObj.Add(key, val);
                    break;

                case "GET":
                    Console.WriteLine("Getting a value.");
                    Console.Write("  Enter the key: ");
                    key = Console.ReadLine().Trim();
                    Console.WriteLine("Value at key {0} is {1}", key, dictObj[key]);
                    break;

                case "SET":
                    Console.WriteLine("Setting a value.");
                    Console.Write("  Enter the key: ");
                    key = Console.ReadLine().Trim();
                    Console.Write("  Enter the value: ");
                    val = Console.ReadLine().Trim();
                    dictObj[key] = val;
                    break;

                case "REMOVE":
                    Console.WriteLine("Removing an entry.");
                    Console.Write("  Enter the key: ");
                    key = Console.ReadLine().Trim();
                    bool removalSuccess = dictObj.Remove(key);
                    Console.WriteLine("Was that pair removed? " + removalSuccess);
                    break;

                case "DEBUG":
                    dictObj.PrintDebug();
                    break;

                case "MENU":
                    Menu();
                    break;

                case "CLEAR":
                    dictObj.Clear();
                    break;
            }
        }
    }
}
