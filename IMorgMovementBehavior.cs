using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{
/******************************************
 * Interface Class: IMorgMovementBehavior
 * Date: 10/10/2015
 * Overview: implements the interface to allow the use of the strategy design pattern for the movement of the morg class.
 * 
 * Parameters: Needs a point given by concrete subject in order to calculate and update new movement 
     * It also needs the random seed from the object in order to calculate new position
 * 
 * 
 ******************************************/
    public interface IMorgMovementBehavior
    {
        Point moveBehavior(Point start , Random r);
    }


/******************************************
 * Class: Paddle
 * Date: 10/10/2015
 * Overview: implements a type of movement behavior that will be used for the morg simulator.
 * It will allow for the movement of 2 in any direction of the morg.
 * 
 * Parameters: Takes in a Point of the parent Morg
 * 
 * Return: A Point that is the calculated new Location
 * 
 ******************************************/
    public class Paddle : IMorgMovementBehavior
    {

        //Implementation of the paddle moveBehavior
        public Point moveBehavior(Point start, Random r)
        {
            
            int newX = r.Next(-2, 3);
            int newY = r.Next(-2, 3);

            //IN ORDER TO CREATE DYNAMIC PETRI DISH: NEED TO REMOVE MAGIC NUMBERS FOR MOD OPERATION AND PULL IN PETRI DISH SIZE 
            newX = ( (( (newX + start.Xpos) % 10) + 10) % 10 ); // in order to get positive integers I needed to double mod the sum. Didnt know
            newY = ( (( (newY + start.Ypos) % 10) + 10) % 10 ); // where to function out the code, so I left it in here for now.
            
            Point newPosition = new Point(newX, newY); 
            Console.WriteLine("I started at Point: " + start.Xpos + ", " + start.Ypos
            + " and paddled to Point: " + newPosition.Xpos + ", " + newPosition.Ypos);

            return newPosition;
        }
    }


    /******************************************
     * Class: Ooze
     * Date: 10/10/2015
     * Overview: implements a type of movement behavior that will be used for the morg simulator.
     * It will allow for the movement of 1 in any direction of the morg.
     * 
     * Parameters: Takes in a Point object for the location of the Morgs position. Also requires a random engine for the calculations
     * 
     * Return: Point that is the calculated new position.
     * 
     ******************************************/
    public class Ooze : IMorgMovementBehavior 
    {
        public Point moveBehavior(Point start, Random r)
        {
            int newX = r.Next(-1, 2);
            int newY = r.Next(-1, 2);

            //IN ORDER TO CREATE DYNAMIC PETRI DISH: NEED TO REMOVE MAGIC NUMBERS FOR MOD OPERATION AND PULL IN PETRI DISH SIZE 
            newX = ((((newX + start.Xpos) % 10) + 10) % 10); // in order to get positive integers I needed to double mod the sum. Didnt know
            newY = ((((newY + start.Ypos) % 10) + 10) % 10); // where to function out the code, so I left it in here for now.

            Point newPosition = new Point(newX, newY);
            Console.WriteLine("I started at Point: " + start.Xpos + ", " + start.Ypos
            + " and oozed to Point: " + newPosition.Xpos + ", " + newPosition.Ypos);

            return newPosition;
        }
    }
}
