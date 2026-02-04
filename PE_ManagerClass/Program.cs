namespace PE_ManagerClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //the fact that I pasted this in after writing all the code and it just worked first try
            // is genuinely miraculous

            // ----------------------------------------------------------------
            // Variables for the program
            Dragon guy1;                // Fighter #1
            Beholder guy2;              // Fighter #2
            int roundCounter = 1;       // Number of rounds

            // ----------------------------------------------------------------
            // Battle!

            // Instantiate both fighters
            guy1 = new Dragon("Dude 1", 100, Damage.Ice, Damage.Lightning);
            guy2 = new Beholder("Dude 2", 115, Damage.Psychic, Damage.Ice);

            // Print their beginning statistics
            Console.WriteLine("MEET THE CHAMPIONS:");
            Console.WriteLine(guy1);
            Console.WriteLine(guy2);

            // While both Monsters are alive, fight!
            while (guy1.Health > 0 && guy2.Health > 0)
            {
                // Visual divider for spacing and output
                Console.WriteLine("\n----------------------------------------");

                // Give reader context with the round number
                Console.WriteLine($"Round {roundCounter}... Fight!");
                roundCounter++;

                // Attack the other Monster, then print each one's health values.
                guy1.Attack(guy2);
                guy2.Attack(guy1);
                Console.WriteLine($"\n{guy1.Name} is at {guy1.Health} health.");
                Console.WriteLine($"{guy2.Name} is at {guy2.Health} health.");
            }

            // ----------------------------------------------------------------
            // Determine winner!

            // Visual divider for spacing and output
            Console.WriteLine("\n------------ WINNER ------------");

            // Tie
            if (guy1.Health <= 0 && guy2.Health <= 0)
            {
                Console.WriteLine("Both fighters have succumbed to the battle.");
            }
            // Dragon wins
            else if (guy1.Health > 0)
            {
                Console.WriteLine($"{guy1.Name} is victorius!");
            }
            // Beholder wins
            else
            {
                Console.WriteLine($"{guy2.Name} is victorius!");
            }
        }
    }

    // old main
    //static void Main(string[] args)
    //    {
    //        MonsterManager monsterMash = new MonsterManager("../../../dragonData.txt", "../../../beholderData.txt");
    //        monsterMash.ReadDragonData();
    //        monsterMash.ReadBeholderData();


    //        /* testing adding dragon and if member of list<monster> types retain their own sub types
    //        List<Monster> monsters = new List<Monster>();

    //        Dragon bob = new Dragon("bob", 100, Damage.Fire, Damage.Ice);

    //        monsters.Add(bob);

    //        if (monsters[0] is Dragon)
    //        {
    //            Console.WriteLine("yay");
    //        }
    //        */

    //        /* checking that readDragonData and readBeholderData works
    //        //foreach (Monster monster in monsterMash.Monsters)
    //        //{
    //        //    Console.WriteLine(monster.ToString());
    //        //}
    //        */

    //        //Test print random dragon

    //        Console.WriteLine(monsterMash.GetDragon().ToString());

    //        Console.WriteLine(monsterMash.GetDragonByType(Damage.Fire).ToString());

    //        Console.WriteLine(monsterMash.GetBeholder().ToString());

    //        Console.WriteLine(monsterMash.GetBeholderByType(Damage.Fire).ToString());

    //    }
    }
