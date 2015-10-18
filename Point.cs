using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/******************************************
 * Class: Point
 * Date: 10/10/2015
 * Overview: implements a generic pair class for a x-y plane coordinate system.
 * 
 * Parameters: needs to be given two integers in its constructor 
 * 
 * 
 ******************************************/
namespace MorgSimulator
{
    public class Point
    {
        //variables for point class
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public Point(int x, int y)
        {
            Xpos = x;
            Ypos = y;
        }

    }


}
