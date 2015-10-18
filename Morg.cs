using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{
    /******************************************
 * Class: Morg
 * Date: 10/10/2015
 * Overview: Abstract class that is the base for all the morgs in the simulation. Has the ability to walk around and eat in the Petri Dish object
 * 
 * Parameters: Needs a random seed for the object to properly work.
 * 
 * 
 ******************************************/
    public abstract class Morg : IMorgObserver
    {
        //--------------------------------Variables-------------------------------------------------
        public Random Rand { get; set; }
        public Point Position { get; set; }

        //all of the morgs that observe the instance of this morg are in this list
        public List<IMorgObserver> Observers { get; set; }
        
        //this is the prey/type that the morg will be tracking
        public Morg Prey { get; set; }
        public int PreyType { get; set; }
        
        
       
        public List<Morg> PreyList{ get; set; }

        //need this in order to kep track of compatible prey objects
        private Simulation Habitat;
        protected IMorgMovementBehavior MovementBehavior;
        protected IFeedBehavior FeedBehavior;



        //------------------------Functions-------------------------------------

        /*
         * Constructor creates a new morg object
         * Requires: A random seed engine, a list<Morgs> and a Simulation to keep track of
         * 
        **/
        public Morg(Simulation newHabitat)
        {
            Rand = newHabitat.Rand;
            Observers = new List<IMorgObserver>();
           

            //initializes the possible preyList with the current Population List of the Simulation
            Habitat = newHabitat;
            PreyList = Habitat.Morgs;

            // it will look for prey using SearchforPrey()
            Prey = null; 

            int xStart = Rand.Next(0, 9);
            int yStart = Rand.Next(0, 9);

            Position = new Point(xStart, yStart);

        }


        /*
         * updatePosition changes the current PreyPosition to the new position of the prey 
         * Requires: used by the observer class to update all the observers when they change position
         * 
        **/
       public void updatePosition() 
        {
           //seems awfully redudant
            Prey = Prey;
        }



       /*
       * searchForPrey is a virtual function that gets implemented differently in each Child Class 
       * 
       * 
      **/
       public abstract void searchForPrey();

      /*
      * removePrey removes the current morg from the observer list of the freshly eaten morg and then deletes it from all the populations list 
      * It also nullifies all of the prey attributes to allow for the morg to begin looking for new prey
      * 
     **/
       public void removePrey() 
       {
           Prey.removeObserver(this);
           Prey = null;
           PreyType = 0;
       }



      /*
      * updateList updates the new Morg Population list everytime it is edited. It then checks to make sure the prey it is currently hunting is still available
      * 
     **/
        public void updateList(List<Morg> newMorgList) 
        {
            PreyList = newMorgList; 

            if(!PreyList.Contains(Prey) && Prey != null)
            {
                removePrey();
            }
        }



       /*
       * registerObserver is the function to subsribe another morg to begin tracking the position of this morg
       * Requires a IMorgObserver Object to allow following
       * 
      **/
        public void registerObserver(IMorgObserver nMorg)
        {
            Observers.Add(nMorg);
        }



        /*
         * removeObserver is the function to unsubsribe another morg to stop tracking the position of this morg. It is called when an object either dies or is removed
         * Requires a IMorgObserver Object to remove
         * 
        **/
        public void removeObserver(IMorgObserver oMorg)
        {
            Observers.Remove(oMorg);
        }



        /*
        * moveBehavior is the function that implements all of the movements in a cycle. It makes sure to see if the morg is hunting, and decides whether
         * a certain position jump is needed. It the updates it's observer list and searches for prey at the end if prey == null
         * 
        * Returns a bool to allow the simulation to know whether or not it needs to change its states on the petriDish object 
        * 
        **/
        public bool moveBehavior() 
        {
            if (Prey == null)
            {
                Point newPosition = MovementBehavior.moveBehavior(Position, Rand);

                Position = newPosition;
                foreach (IMorgObserver o in Observers)
                {
                    o.updatePosition();
                }
            }
            else 
            {
                Position = Prey.Position;
                feedBehavior();
                //if it has eaten something it will return true and allow for the the list to resize before continueing loop. 
                return true;

            }

            searchForPrey();
            return false;

        }



        /*
        * feedBehavior calls the chosen feedbehavior strategy
        * 
        **/
        public void feedBehavior()
        {
            FeedBehavior.feed(PreyType);
        }

    }
    //END OF MORG CLASS



    /******************************************
 * Interface: IMorgObserver
 * Date: 10/10/2015
 * Overview: implements an Interface for the Morg prey and position states
 * 
 ******************************************/
    public interface IMorgObserver
    {
        void updatePosition();
    }
}
