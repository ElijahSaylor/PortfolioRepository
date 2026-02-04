using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ManagerClass
{
    internal class Answers
    {

        // Why is Monster abstract?
        // So that no generic instances of a monster can be created while still forcing some common implementation
        // between monsters. it would make no sense to have a un-typed monster: a monsterless monster.

        // Briefly summarize:  What code does the Monster class have/is handling? 
        // Monster requires all instances to have a name, damage, and health, as well as the ability to take damage,
        // attack, and a toString method. It also creates a set of damage types.
        
        // Briefly summarize:  What code do the two child classes have/are handling? 
        // Dragon gets all implementation of Monster, but has the ability to have a damage type resistance.
        // Beholder is similar, except it has a damage vulnerability instead of a resistance.

        // Why are those classes handling the code that they contain?  (In other words, why was the project architecture designed this way?)
        // Why is the Random object a field of the Monster class and not a field of the child classes?
        // Objects should only contain code that they will actually use. It would not make sense to put the resistance
        // code into Monster() if only dragons would ever use it. Also, if the random() was in the child, the same seed 
        // millisecond could be used for each instance, meaning that they would produce the same values.

    }
}
