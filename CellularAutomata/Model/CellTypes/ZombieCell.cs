using System;
using System.Collections.Generic;
using System.Drawing;

namespace CellularAutomata.Model.CellTypes
{
    //a zombie cell
    class ZombieCell : Cell, ICell
    {
        public ZombieCell(MapButton newHost) : base(newHost)
        {
            //make sure we know it's a zombie cell
            _cellType = CellType.Zombie;
            //zombies are green
            _cellColor = Color.Green;
            //zombies are slow
            _agility = 1;
            
        }

        public ZombieCell(ICell theUnfortunate) : base(theUnfortunate.HostButton)
        {
            //your green now unfortunate
            _cellColor = Color.Green;
            //and your slow
            _agility = 1;
            //reanimate the dead
            _cellState = CellState.Alive;
            //make sure it is now a zombie cell
            _cellType = CellType.Zombie;
            
        }

        public void GoGetBrains(Map map)
        {
            List<ICell> zombieCells = new List<ICell>();
            List<ICell> originalCells = new List<ICell>();

            foreach (MapButton host in map.GetOccupiedNeighborHosts(this))
            {
                if (host.Tenant.CellType == CellType.Zombie)
                {
                    zombieCells.Add(host.Tenant);
                }
                else if (host.Tenant.CellType == CellType.Original)
                {
                    originalCells.Add(host.Tenant);
                }
            }

            //if there are no neighbors
            if (originalCells.Count == 0)
            {
                //move
                map.MoveToRandomVacantMapButton(this);
            }
            else
            {
                //get random index
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int randomIndex = random.Next(0, originalCells.Count);

                //bite unfortunate neighbor 
                Bite(originalCells[randomIndex]);

            }
        }

        private static void Bite(ICell victim)
        {
            victim.ZombieBite = true;
            victim.CellState = CellState.Infected;
        }

        #region interface
       
       
        #endregion
    }
}
