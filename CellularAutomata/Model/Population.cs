using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using CellularAutomata.Model.CellTypes;

namespace CellularAutomata.Model
{
    public class Population : List<ICell>
    {
        public int ZombieCount;
        public int OriginalCount;
        public int DeadCount;

        private readonly List<ICell> _deadCells; 

        public Population()
            : base()
        {
            //initialize population here
            _deadCells = new List<ICell>();

        }

        //the magic logic////////////////////////////////////////
        public void Live(Map map)
        {
            foreach (var cell in this)
            {
                if (cell != null)
                {
                    //handle state
                    if (cell.CellState == CellState.Infected)
                    {
                        //turn the color
                        cell.CellColor = Color.Black;
                        //change the state
                        cell.CellState = CellState.Dead;
                        OriginalCount--;
                        //change the type
                        cell.CellType = CellType.Dead;
                    }
                    else if (cell.CellState == CellState.Alive)
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
                    else if (cell.CellState == CellState.Dead)
                    {
                        //add to the dead bodies list
                        _deadCells.Add(cell);
                    }

                }

            }//end foreach(cell)
            
        }//end Live
        //////////////////////////////////////////////////////////

        //handle dead cells
        public void HandleDeadCells()
        {
            for(int i = 0; i < _deadCells.Count; i++)
            {
                //cells have been bitten by zombie
                if (_deadCells[i].ZombieBite)
                {
                    //remove cell from population
                    RemoveCell(_deadCells[i]);
                    //change type to zombie
                    _deadCells[i].CellType = CellType.Zombie;
                    //create new cell from this cell
                    ZombieCell zombieCell = new ZombieCell(_deadCells[i]);
                    //make sure dead cell get's nulled
                    _deadCells[i] = null;
                    //add a new zombie to population
                    AddCell(zombieCell);
                }
                else
                {
                    //remove cell from population
                    RemoveCell(_deadCells[i]);
                    //make sure it get's nulled
                    _deadCells[i] = null;
                }
                
            }

            _deadCells.RemoveAll(item => item == null);
        }

        //get dead cells
        public List<ICell> GetDeadCells()
        {
            return _deadCells;
        }

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
                case CellType.Dead:
                    {
                        DeadCount--;
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
                case CellType.Dead:
                    {
                        DeadCount++;
                        break;
                    }
            }

            this.AddSorted(newCell);
        }
    }
}
