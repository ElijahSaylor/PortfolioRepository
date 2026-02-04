using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PE_ManagerClass
{
    internal class MonsterManager
    {
        

        List<Monster> monsters;
        string beholderData;
        string dragonData;
        List<Dragon> dragonList = new List<Dragon>();
        List<Beholder> beholderList = new List<Beholder>();

        public List<Monster> Monsters
        {
            get { return monsters; } 
        }

        public int DragonCount
        {
            get
            {
                int dragonCounter = 0;
                foreach (Monster x in monsters)
                {
                    if (x is Dragon)
                    {
                        dragonCounter++;
                    }

                }
                return dragonCounter;
            }
        }

        public int BeholderCount
        {
            get
            {
                int beholderCounter = 0;
                foreach (Monster x in monsters)
                {
                    if (x is Beholder)
                    {
                        beholderCounter++;
                    }

                }
                return beholderCounter;
            }
        }

        public MonsterManager(string dragonDataPath, string beholderDataPath)
        {
            monsters = new List<Monster>();
            dragonData = dragonDataPath;
            beholderData = beholderDataPath;
        }


        /// <summary>
        /// Reads Dragon save file data and adds each dragon to the list of monsters
        /// </summary>
        public void ReadDragonData()
        {
            StreamReader reader = new StreamReader(dragonData);

            string thisLine = reader.ReadLine();

            while (thisLine != null) 
            {
                try {

                string[] thisData = thisLine.Split('|');

                monsters.Add(new Dragon(thisData[0], //name
                    Random.Shared.Next(1, 101), // health
                    (Damage)Enum.Parse(typeof(Damage), thisData[1]), //damage type
                    (Damage)Random.Shared.Next(0,4))); // random resistance
                    }

                catch {
                    Console.WriteLine("Error reading dragon data!");
                }

                thisLine = reader.ReadLine()!;

            }

            reader.Close();

        }


        /// <summary>
        /// Reads Beholder save file data and adds each dragon to the list of monsters
        /// </summary>
        public void ReadBeholderData()
        {
            StreamReader reader = new StreamReader(beholderData);

            string thisLine = reader.ReadLine()!;

            while ( thisLine != null)
            {
                try
                {
                    string[] thisData = thisLine.Split('|');

                    monsters.Add(new Beholder(thisData[0], //name
                        Random.Shared.Next(1, 101), // health
                        (Damage)Random.Shared.Next(0, 4), //rand damage type
                        (Damage)Enum.Parse(typeof(Damage), thisData[1]))); // vulnerability
                    //(Damage)Enum.Parse(typeof(Damage), thisData[1])
                }

                catch
                {
                    Console.WriteLine("Error reading beholder data!");
                }

                thisLine = reader.ReadLine()!;

            }

            reader.Close();
        }


        /// <summary>
        /// Clears and repopulates list of all dragon enemies and returns a random one
        /// </summary>
        /// <returns></returns>
        public Dragon GetDragon()
        {
            if(dragonList != null) { dragonList.Clear(); }

            foreach(Monster monster in Monsters)
            {
                if(monster is Dragon)
                {
                    dragonList.Add(monster as Dragon);
                }
            }

            return dragonList[Random.Shared.Next(0,dragonList.Count)];

        }

        /// <summary>
        /// Creates list of all monsters which are dragons and have the specified damage type
        /// returns a random dragon from that list
        /// </summary>
        /// <param name="type"> damage type</param>
        /// <returns>random dragon</returns>
        public Dragon GetDragonByType(Damage type)
        {
            List<Dragon> typedDragonList = new List<Dragon>();

            foreach (Monster monster in Monsters) 
            {
                if (monster is Dragon && monster.damageType == type)
                {
                    typedDragonList.Add(monster as Dragon);
                }
            }

            return typedDragonList[Random.Shared.Next(0,typedDragonList.Count)];
        }

        /// <summary>
        /// Clears beholder list and repopulates list with count of all beholders. returns
        /// a random beholder from that list
        /// </summary>
        /// <returns>random beholder</returns>
        public Beholder GetBeholder()
        {
            if (beholderList != null) { beholderList.Clear(); }

            foreach (Monster monster in Monsters)
            {
                if (monster is Beholder)
                {
                    beholderList.Add(monster as Beholder);
                }
            }

            return beholderList[Random.Shared.Next(0, beholderList.Count)];
        }

        /// <summary>
        /// generates list of all beholders with specified damage type and returns a random one
        /// </summary>
        /// <param name="type">damage type enum</param>
        /// <returns>random beholder</returns>
        public Beholder GetBeholderByType(Damage type)
        {
            List<Beholder> typedBeholderList = new List<Beholder>();

            foreach (Monster monster in Monsters)
            {
                if (monster is Beholder && monster.damageType == type)
                {
                    typedBeholderList.Add(monster as Beholder);
                }
            }

            return typedBeholderList[Random.Shared.Next(0, typedBeholderList.Count)];
        }

    }
}
