using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{
 /******************************************
 * Class: Simulation
 * Date: 10/10/2015
 * Overview: implements the simulation engine for the morgs to live in.
 * 
 * Parameters: Requires a random number engine for certain operations within the engine
 * Requires an integer to set the size of the Petri Dish 
 * 
 * 
 ******************************************/
    public class Simulation
    {
        public List<Morg> Morgs;
        public bool[,] PetriDish;

        //will be the seed that will be used for the whole simulation
        public Random Rand;


        /*
         * Simulation Constructor that creates an instance of the object
         * Requires: A random engine and an int for the PetriDishSize
         * 
         **/
        public Simulation(Random r, int PetriDishSize)
        {
            PetriDish = new bool[(PetriDishSize), (PetriDishSize)];
            Rand = r;
            Morgs = new List<Morg>();

        }


        /*
         * AddaMorg adds a morg to the simulation's petriDish list
         * 
         **/
        public void AddAMorg(Morg newMorg)
        {
            Console.WriteLine("Adding a new Morg to the Simulation of type: " + newMorg);
            Morgs.Add(newMorg);

            foreach (Morg o in Morgs)
            {
                o.updateList(Morgs);
            }
        }


        /*
         * RemoveAMorg removes a morg to the simulation's petriDish list
         * 
         **/
        public void RemoveAMorg(Morg deadMorg)
        {
            Morgs.Remove(deadMorg);

            foreach (Morg o in Morgs)
            {
                o.updateList(Morgs);
            }

        }


        /*
         * RunSimulationOneCycle calls the behaviors for each morg in its simulation
         * 
         **/
        public void RunSimulationOneCycle()
        {
            for (int i = Morgs.Count - 1; i >= 0; i--)
            {
                Console.WriteLine("-----------------Beginning of Morg movement-------");

                //set the old position of the morg to false
                PetriDish[Morgs.ElementAt(i).Position.Xpos, Morgs.ElementAt(i).Position.Ypos] = false;

                //call movebehavior function to do all the work of the cycle for the morg
                bool preyHunted = Morgs.ElementAt(i).moveBehavior();

                

                if (preyHunted == true)
                {
                    //calls simulation function that removes morg from list and tells all morgs of removal
                    PetriDish[Morgs.ElementAt(i-1).Position.Xpos, Morgs.ElementAt(i-1).Position.Ypos] = true;
                    RemoveAMorg(Morgs.ElementAt(i-1).Prey);
                    i--;
                }
                else
                    PetriDish[Morgs.ElementAt(i).Position.Xpos, Morgs.ElementAt(i).Position.Ypos] = true;

            }
            Console.WriteLine("-----------------------------------End of Morg Cycle------------------------- \n");
        }
    }
}
    //END OF SIMULATION CLASS

