using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{
    /******************************************
*  Class: C (Inherits from Morg Class)
* Date: 10/10/2015
* Overview: A Child class of the morg class. Has specific behaviors:
* FeedBehavior: Envelop() (eats A and B morgs)
* MovementBehavior: Paddle()
*
* Parameters: It requires the simulations random engine seed the current MorgList of the simulation and the simulation as well
* 
* 
******************************************/
    public class C : Morg
    {

        public C(Simulation newHabitat)
            : base(newHabitat)
        {
            FeedBehavior = new Envelop();
            MovementBehavior = new Paddle();
        }

        /*
         * searchForPrey() does the special behavior for the C class in order to correctly search for prey
         * 
         **/
        public override void searchForPrey()
        {
            Console.WriteLine("Beginning Search For Prey C-Style \n");

            foreach(Morg possiblePrey in PreyList)
            {
                if (possiblePrey is A)
                {
                    PreyType = 0;
                    Prey = possiblePrey;
                    possiblePrey.registerObserver(this);
                    break;
                }
                else if (possiblePrey is B)
                {
                    PreyType = 1;
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
                Console.WriteLine("I FOUND SOME PREY TO HUNT C-STYLE \n");
        }
        //END OF SEARCHFORPREY FUNCTION

    }
    //END OF C CLASS
}
