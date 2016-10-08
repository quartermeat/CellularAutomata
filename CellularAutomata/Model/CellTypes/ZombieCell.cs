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
            //zombies are green
            _cellColor = Color.Green;
            //zombies are slow
            _agility = 1;
            //zombie's are always zombieBit

        }

        public ZombieCell(ICell theUnfortunate) : base(theUnfortunate.HostButton)
        {
            //your green now unfortunate
            _cellColor = Color.Green;
            //and your slow
            _agility = 1;
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
                originalCells[randomIndex].ZombieBite = true;

            }
        }

        #region interface


        public new CellType CellType
        {
            get { return CellType.Zombie; }
        }
        #endregion
    }
}
