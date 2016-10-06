using System;
using System.Collections.Generic;
using System.Drawing;

namespace CellularAutomata.Model.CellTypes
{
    class ZombieCell : Cell
    {

        public ZombieCell(Point newLocation, MapButton newHost) : base(newLocation, newHost)
        {
            //initialize new stuff
            CellType = CellType.Zombie;
            Agility = 0;
        }

        public ZombieCell(Cell theUnfortunate) : base(theUnfortunate.Location, theUnfortunate.HostButton)
        {
            //do turning stuff here
            theUnfortunate = this;
            
            CellType = CellType.Zombie;
            Agility = 0;
        }

        public void GoGetBrains()
        {
            //get empty neighbor hosts
            List<MapButton> occupiedNeighborHosts = GetOccupiedNeighborHosts();
            
            //if there are no neighbors
            if (occupiedNeighborHosts.Count == 0)
            {
                //move
                MoveToRandomVacantMapButton();
            }
            else
            {
                //get random index
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int randomIndex = random.Next(0, occupiedNeighborHosts.Count);

                //turn neighbor into zombie
                occupiedNeighborHosts[randomIndex].Tenant = new ZombieCell(occupiedNeighborHosts[randomIndex].Tenant);
            }
            
            
        }

        public override string ToString()
        {
            return "Zombie";
        }
    }
}
