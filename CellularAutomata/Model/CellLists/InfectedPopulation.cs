using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata.Model.CellTypes;
using CellularAutomata.Model.Interfaces;

namespace CellularAutomata.Model.CellLists
{
    public class InfectedPopulation : List<ICell>, IPopulation
    {
        public void AddCell(ICell cell)
        {
            InfectedCell infectedCell = new InfectedCell(cell);
            this.AddSorted(infectedCell);
            UpdateNeighbors(infectedCell);
        }

        public void RemoveCell(ICell cell)
        {
            //remove cell from population
            Remove(cell);
            //update map button
            cell.HostButton.BackColor = Map.MapColor;
            cell.HostButton.Tenant = null;
            //update all neighbors since this cell is now gone
            foreach (KeyValuePair<int, ICell> currentCell in cell.Neighbors)
            {
                UpdateNeighbors(currentCell.Value);
            }
            
        }

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

        public void UpdateAllNeighbors()
        {
            //update neighbors of all cells currently on map
            foreach (ICell cell in this)
            {
                UpdateNeighbors(cell);
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

        //move cells randomly////////////////////////////////////////////////
        public void MoveToRandomVacantMapButton(ICell cell)
        {
            //get empty neighbor hosts
            List<MapButton> vacantNeighborHosts = GetVacantNeighborHosts(cell);
            //get random index
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int randomIndex = random.Next(0, vacantNeighborHosts.Count);
            //remove self from current Host
            cell.HostButton.BackColor = Map.MapColor;
            cell.HostButton.Tenant = null;
            //place this self into new host
            vacantNeighborHosts[randomIndex].Tenant = cell;
            //update _hostButton to the new spot
            cell.HostButton = vacantNeighborHosts[randomIndex];
            //update neighbors
            UpdateNeighbors(cell);
        }

        public void Live(ICell cell, Map map)
        {
            //remove cell from infected
            RemoveCell(cell);
            InfectedCell infectedCell = new InfectedCell(cell);
            //add a new dead to population
            map.Population.DeadPopulation.AddCell(infectedCell);
        }
    }
}
