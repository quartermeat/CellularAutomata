using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using CellularAutomata.Model.CellLists;
using CellularAutomata.Model.CellTypes;

namespace CellularAutomata.Model
{
    public class Population
    {
        public OriginalPopulation OriginalPopulation;
        public ZombiePopulation ZombiePopulation;
        public DeadPopulation DeadPopulation;
        public InfectedPopulation InfectedPopulation;

        public Population()
            : base()
        {
            //initialize population here
            OriginalPopulation = new OriginalPopulation();
            ZombiePopulation = new ZombiePopulation();
            DeadPopulation = new DeadPopulation();
            InfectedPopulation = new InfectedPopulation();
        }

        //the magic logic////////////////////////////////////////
        public void Live(Map map)
        {
            //using ToList() to loop through a COPY of each population.  This let's me change the population within the loop

            List<ICell> lifePool = new List<ICell>();
            lifePool.AddRange(OriginalPopulation);
            lifePool.AddRange(ZombiePopulation);
            lifePool.AddRange(InfectedPopulation);
            lifePool.AddRange(DeadPopulation);
            lifePool.Sort();

            //handle original cells
            foreach (ICell cell in lifePool.ToList())
            {
                switch (cell.CellType)
                {
                    case CellType.Original:
                        {
                            OriginalPopulation.Live(cell, map);
                            break;
                        }
                    case CellType.Infected:
                        {
                            InfectedPopulation.Live(cell, map);
                            break;
                        }
                    case CellType.Dead:
                        {
                            DeadPopulation.Live(cell, map);
                            break;
                        }
                    case CellType.Zombie:
                        {
                            ZombiePopulation.Live(cell, map);
                            break;
                        }
                }//end switch

            }

        }//end Live
        //////////////////////////////////////////////////////////

        //move cells randomly////////////////////////////////////////////////
        public void MoveToRandomVacantMapButton(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Original:
                    {
                        OriginalPopulation.MoveToRandomVacantMapButton(cell);
                        break;
                    }
                case CellType.Zombie:
                    {
                        ZombiePopulation.MoveToRandomVacantMapButton(cell);
                        break;
                    }
                case CellType.Dead:
                    {
                        DeadPopulation.MoveToRandomVacantMapButton(cell);
                        break;
                    }
                case CellType.Infected:
                    {
                        InfectedPopulation.MoveToRandomVacantMapButton(cell);
                        break;
                    }
            }
        }

        //get dead cells
        public List<ICell> GetDeadCells()
        {
            return DeadPopulation;
        }

        //get zombie cells
        public List<ICell> GetZombieCells()
        {
            return ZombiePopulation;
        }

        //get original cells
        public List<ICell> GetOriginalCells()
        {
            return OriginalPopulation;
        }

        //get infected cells
        public List<ICell> GetInfectedCells()
        {
            return InfectedPopulation;
        }

        //update all neighbors
        public void UpdateAllNeighbors()
        {
            //update all populations neighbors
            OriginalPopulation.UpdateAllNeighbors();
            ZombiePopulation.UpdateAllNeighbors();
            DeadPopulation.UpdateAllNeighbors();
            InfectedPopulation.UpdateAllNeighbors();
        }

        //get an array of empty buttons neighboring this cell
        public List<MapButton> GetVacantNeighborHosts(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Dead:
                    {
                        return DeadPopulation.GetVacantNeighborHosts(cell);
                    }
                case CellType.Original:
                    {
                        return OriginalPopulation.GetVacantNeighborHosts(cell);
                    }
                case CellType.Zombie:
                    {
                        return ZombiePopulation.GetVacantNeighborHosts(cell);
                    }
                case CellType.Infected:
                    {
                        return InfectedPopulation.GetOccupiedNeighborHosts(cell);
                    }
            }

            return null;
        }

        //get an array of occupied buttons neighboring this cell
        public List<MapButton> GetOccupiedNeighborHosts(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Dead:
                    {
                        return DeadPopulation.GetOccupiedNeighborHosts(cell);
                    }
                case CellType.Original:
                    {
                        return OriginalPopulation.GetOccupiedNeighborHosts(cell);
                    }
                case CellType.Zombie:
                    {
                        return ZombiePopulation.GetOccupiedNeighborHosts(cell);
                    }
                case CellType.Infected:
                    {
                        return InfectedPopulation.GetOccupiedNeighborHosts(cell);
                    }
            }

            return null;
        }

        //update neighbors
        public void UpdateNeighbors(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Dead:
                    {
                        DeadPopulation.UpdateNeighbors(cell);
                        break;
                    }
                case CellType.Original:
                    {
                        OriginalPopulation.UpdateNeighbors(cell);
                        break;
                    }
                case CellType.Zombie:
                    {
                        ZombiePopulation.UpdateNeighbors(cell);
                        break;
                    }
                case CellType.Infected:
                    {
                        InfectedPopulation.UpdateNeighbors(cell);
                        break;
                    }
            }
        }

        //add cell to population
        public void AddCell(ICell newCell)
        {
            switch (newCell.CellType)
            {
                case CellType.Original:
                    {
                        OriginalPopulation.AddCell(newCell);
                        break;
                    }
                case CellType.Zombie:
                    {
                        ZombiePopulation.AddCell(newCell);
                        break;
                    }
                case CellType.Dead:
                    {
                        DeadPopulation.AddCell(newCell);
                        break;
                    }
                case CellType.Infected:
                    {
                        InfectedPopulation.AddCell(newCell);
                        break;
                    }
            }
        }

        //remove cell from population
        public void RemoveCell(ICell cellToRemove)
        {
            switch (cellToRemove.CellType)
            {
                case CellType.Original:
                    {
                        OriginalPopulation.RemoveCell(cellToRemove);
                        break;
                    }
                case CellType.Zombie:
                    {
                        ZombiePopulation.RemoveCell(cellToRemove);
                        break;
                    }
                case CellType.Dead:
                    {
                        DeadPopulation.RemoveCell(cellToRemove);
                        break;
                    }
                case CellType.Infected:
                    {
                        InfectedPopulation.RemoveCell(cellToRemove);
                        break;
                    }
            }
        }

        public void SortAll()
        {
            ZombiePopulation.Sort();
            OriginalPopulation.Sort();
            DeadPopulation.Sort();
            InfectedPopulation.Sort();
        }
    }
}
