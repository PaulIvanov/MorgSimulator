using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{/******************************************
 * Interface Class: IFeedBehavior
 * Date: 10/10/2015
 * Overview: implements the interface to allow the use of the strategy design pattern for the feeding of the morg classes.
 * 
 * Parameters: Needs a int datatype that refers to the type of prey which is being eaten
 * 
 * 
 ******************************************/
    public interface IFeedBehavior
    {
        void feed(int preyType);
    }
//END OF INTERFACE DECLARATION


 /******************************************
 * Class:Envelop 
 * Date: 10/10/2015
 * Overview: implements a type of feeding that "envelops" the other morgs.
 * 
 * 
 ******************************************/
    public class Envelop : IFeedBehavior 
    {
        public void feed(int preyType) 
        {
            if (preyType == 0)
            {
                Console.WriteLine("enveloping A");
            }
            else 
            {
                Console.WriteLine("enveloping B");
            }

        }
    }
    //END OF ENVELOP CLASS


/******************************************
* Class:Absorb
* Date: 10/10/2015
* Overview: implements a type of feeding that "Absorbs" the other morgs.
*  
* 
******************************************/
    public class Absorb : IFeedBehavior 
    {
        public void feed(int preyType)
        {
            if (preyType == 1)
            {
                Console.WriteLine("absorbed B");
            }
            else 
            {
                Console.WriteLine("absorbed C");
            }
            
        }
    }
    //END OF ABSORB CLASS
}
