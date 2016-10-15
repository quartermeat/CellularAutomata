using System.Collections.Generic;
using System.Linq;
using CellularAutomata.Model.CellTypes;
using CellularAutomata.Model.Interfaces;

namespace CellularAutomata.Model.CellLists
{
    public class DeadPopulation : List<ICell>, IPopulation
    {
        public DeadPopulation()
            : base()
        {
            //intialize here

        }

        //add a cell to this population
        public void AddCell(ICell cell)
        {
            DeadCell deadCell = new DeadCell(cell);
            Add(deadCell);
            UpdateNeighbors(deadCell);
        }

        //add a cell to this population
        public void RemoveCell(ICell cell)
        {
            //remove cell
            Remove(cell);
            //update all neighbors since this cell is now gone
            foreach (KeyValuePair<int, ICell> currentCell in cell.Neighbors)
            {
                UpdateNeighbors(currentCell.Value);
            }
            //remove self from current Host
            cell.HostButton.BackColor = Map.MapColor;
            cell.HostButton.Tenant = null;
            
        }

        //update neighbors
        public void UpdateNeighbors(ICell cell)
        {
            //get neighbor buttons and if they have an occupant, set them as a neighbor
            foreach (KeyValuePair<int, MapButton> neighborHost in cell.HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant != null).Where(neighborHost => !cell.Neighbors.ContainsKey(neighborHost.Key)))
            {
                //add this cell as a neighbor
                cell.Neighbors.Add(neighborHost.Key, neighborHost.Value.Tenant);
            }
            foreach (
                KeyValuePair<int, MapButton> neighborHost in
                    cell.HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant == null))
            {
                cell.Neighbors.Remove(neighborHost.Key);
            }
        }

        //get an array of empty buttons neighboring this cell
        public List<MapButton> GetVacantNeighborHosts(ICell cell)
        {
            return cell.HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant == null).Select(neighborHost => neighborHost.Value).ToList();
        }

        //get an array of occupied buttons neighboring this cell
        public List<MapButton> GetOccupiedNeighborHosts(ICell cell)
        {
            return cell.HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant != null).Select(neighborHost => neighborHost.Value).ToList();
        }

        //update all neighbors
        public void UpdateAllNeighbors()
        {
            //update neighbors of all cells currently on map
            foreach (ICell cell in this)
            {
                UpdateNeighbors(cell);
            }
        }

        //move cells randomly////////////////////////////////////////////////
        public void MoveToRandomVacantMapButton(ICell cell)
        {
            //dead cell doesn't move... right now
        }

        public void Live(ICell cell, Map map)
        {
            //dead cells only live if they were infected
            DeadCell deadCell = cell as DeadCell;
            if (deadCell != null && deadCell.WasInfected)
            {
                RemoveCell(deadCell);
                map.Population.ZombiePopulation.AddCell(deadCell);
            }
            else
            {
                //let the body lie there... for now
            }

        }
    }
}
