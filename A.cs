using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{
    /******************************************
 *  Class: A (Inherits from Morg Class)
 * Date: 10/10/2015
 * Overview: A Child class of the morg class. Has specific behaviors:
 * FeedBehavior: Absorb() (Feeds on B and C morgs)
 * MovementBehavior: Paddle()
 *
 * Parameters: It requires the simulations random engine seed the current MorgList of the simulation and the simulation as well
 * 
 * 
 ******************************************/
    public class A : Morg
    {
        public A(Simulation newHabitat)
            : base(newHabitat)
        {
            FeedBehavior = new Absorb();
            MovementBehavior = new Paddle();
        }

        /*
         * searchForPrey() does the special behavior for the A class in order to correctly search for prey
         * 
         **/
        public override void searchForPrey()
        {
            Console.WriteLine("Beginning Search For Prey A-Style \n");
       
            foreach (Morg possiblePrey in PreyList) 
            {
                if (possiblePrey is  B) 
                {
                    PreyType = 1;
                    Prey = possiblePrey;
                    possiblePrey.registerObserver(this);

                    break;
                }
                else if (possiblePrey is C)
                {
                    PreyType = 2;
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
                Console.WriteLine("I FOUND SOME PREY TO HUNT A-STYLE \n");
        }
        //END OF searchForPrey FUNCTION

    }
    //END OF A CLASS
}
