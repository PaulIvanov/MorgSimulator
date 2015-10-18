using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //random engine seeded with time
            Random r = new Random();
            
            //hard-coded in petri-dish size for now. TODO: create a function that allows for choice of petri dish size. 
            int petriDishSize = 10;
            Console.WriteLine("Building Simulation1 \n");
            Simulation morgSim = new Simulation(r, petriDishSize);
            Console.WriteLine("Simulation1 Build Success \n");


            //simulation that introduces 3 morgs at once and allows the simulation to run until one morg is left
            Console.WriteLine("------------------Beginning Cycles of Simulation 1------------------------ \n");
            //possibly have a function that does purely display while the runSimulation function does logic of changing all of the states in one cycle
            A alice = new A(morgSim);
            B bernice = new B(morgSim);
            C cathy = new C(morgSim);

            morgSim.AddAMorg(alice);
            morgSim.AddAMorg(bernice);
            morgSim.AddAMorg(cathy);

            morgSim.RunSimulationOneCycle();
            morgSim.RunSimulationOneCycle();
            morgSim.RunSimulationOneCycle();
            morgSim.RunSimulationOneCycle();
            morgSim.RunSimulationOneCycle();
            
            Console.WriteLine("-----------------------End of Simulation 1-------------------------------- \n");



            //Simulation that slowly introduces morgs into and allows for hunting to occur. It then introduces a morg at the end to live and prosper
            Console.WriteLine("----------------------Beginning Simulation 2------------------------------ \n");

            Console.WriteLine("Building Simulation 2 \n");
            Simulation morgSim2 = new Simulation(r, petriDishSize);
            Console.WriteLine("Simulation 2 Build Success \n");

            Console.WriteLine("------------------Beginning Cycles of Simulation 2------------------------ \n");

            A Alex = new A(morgSim2);
            B Bernie = new B(morgSim2);
            C Carl = new C(morgSim2);

            morgSim2.AddAMorg(Alex);
            
            
            //lets Alex roam
            morgSim2.RunSimulationOneCycle();
            morgSim2.RunSimulationOneCycle();

            //introduce Bernie
            morgSim2.AddAMorg(Bernie);

            //Lets the hunting begin
            morgSim2.RunSimulationOneCycle();

            //Introduce Carl
            morgSim2.AddAMorg(Carl);

            C Cathy = new C(morgSim2);
            // Allows the simulation to run for a little longer to allow eating to happen
            morgSim2.RunSimulationOneCycle();
            
            //introduce Cathy
            morgSim2.AddAMorg(Cathy);
            morgSim2.RunSimulationOneCycle();
            morgSim2.RunSimulationOneCycle();

        }
    }
}
