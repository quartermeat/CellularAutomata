using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using CellularAutomata.Controller.Helpers;

namespace CellularAutomata.Model.CellTypes
{
    class ZombieCell : Cell, ICell
    {
        public ZombieCell(MapButton newHost) : base(newHost)
        {
            CellColor = Color.Green;
            //Agility = 0;
        }

        public ZombieCell(ICell theUnfortunate) : base(theUnfortunate.HostButton)
        {
            CellColor = Color.Green;
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

                //turn cell into zombie cell here
               
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
