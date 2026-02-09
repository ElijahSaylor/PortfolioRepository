using System;
using System.Collections.Generic;
using System.Text;

namespace PE_Dictionaries
{
    internal class Player
    {
        string name;
        int score;

        public string Name
        {
            get { return name; } 
            //set { name = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Player(string name, int score)
        {
            this.name = name;
            Score = score;
        }

        public override string ToString() 
        {
            return $"Player {Name} has {score} points.";
        }
    }
}
