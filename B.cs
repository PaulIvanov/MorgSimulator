using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{
    /******************************************
*  Class: B (Inherits from Morg Class)
* Date: 10/10/2015
* Overview: A Child class of the morg class. Has specific behaviors:
* FeedBehavior: Envelop() (eats only A morgs)
* MovementBehavior: Ooze()
*
* Parameters: It requires the simulations random engine seed the current MorgList of the simulation and the simulation as well
* 
* 
******************************************/
    public class B : Morg
    {
        public B( Simulation newHabitat)
            : base(newHabitat)
        {
           FeedBehavior = new Envelop();
           MovementBehavior = new Ooze();
        }

        /*
         * searchForPrey() does the special behavior for the B class in order to correctly search for prey
         * 
         **/
        public override void searchForPrey()
        {
            Console.WriteLine("Beginning Search For Prey B-Style \n");

            foreach(Morg possiblePrey in PreyList)
            {
                if (possiblePrey is A)
                {
                    PreyType = 0;
                    Prey = possiblePrey;
                    possiblePrey.registerObserver(this);
                    break;
                }
            }

            if (Prey == null)
            {
                Console.WriteLine("NO PREY FOUND YET");
            }
            else
                Console.WriteLine("I FOUND SOME PREY TO HUNT B-STYLE \n");
        }
        //END OF SEARCHFORPREY FUNCTION
    }
    //END OF B CLASS 
}
