using System.Collections;
using System.Collections.Generic;
using CellularAutomata.Model.CellTypes;

namespace CellularAutomata.Model
{
    public class Population : List<ICell>
    {
        public int ZombieCount;
        public int OriginalCount;

        public Population()
            : base()
        {
            //initialize population here
        }

        //the magic logic////////////////////////////////////////
        public void Live(Map map)
        {
            foreach (var cell in this)
            {
                //move the cell
                if (cell.CellType == CellType.Original)
                {
                    //do original stuff
                    map.MoveToRandomVacantMapButton(cell);

                    //make sure they always have a fighting chance
                    cell.Agility = cell.OriginalAgility;
                    //then lower it accordingly
                    for (int i = 0; i < cell.Neighbors.Count; i++)
                    {
                        cell.Agility--;
                    }
                }
                else if (cell.CellType == CellType.Zombie)
                {
                    //do zombie stuff
                    ZombieCell zombieCell = cell as ZombieCell;
                    if (zombieCell != null) zombieCell.GoGetBrains(map);
                }

            }

            //sort the population based on agility
            Sort();
        }
        //////////////////////////////////////////////////////////

        //remove cell from population
        public void RemoveCell(ICell cellToRemove)
        {
            switch (cellToRemove.CellType)
            {
                case CellType.Original:
                    {
                        OriginalCount--;
                        break;
                    }
                case CellType.Zombie:
                    {
                        ZombieCount--;
                        break;
                    }
            }

            Remove(cellToRemove);
        }

        //add cell to population
        public void AddCell(ICell newCell)
        {
            switch (newCell.CellType)
            {
                case CellType.Original:
                    {
                        OriginalCount++;
                        break;
                    }
                case CellType.Zombie:
                    {
                        ZombieCount++;
                        break;
                    }
            }

            this.AddSorted(newCell);
        }
    }
}
