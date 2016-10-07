using System.Collections.Generic;
using CellularAutomata.Controller.Helpers;

namespace CellularAutomata.Model
{
    public class Population : List<ICell>
    {
        public Population() : base()
        {
            //initialize population here
        }

        public void DoStuff(Map map)
        {
            foreach (var cell in this)
            {
                //keep track of old host to draw it vacant
                //MapButton oldHost = cell.HostButton;
                //move the cell
                if (cell.CellType == CellType.Original)
                {
                    //do original stuff
                    MoveToRandomVacantMapButton(cell, map);
                }
                else if (cell.CellType == CellType.Zombie)
                {
                   //do zombie stuff
                }
            }
        }

        private void MoveToRandomVacantMapButton(ICell cell, Map map)
        {
            map.MoveToRandomVacantMapButton(cell);
        }
    }
}
