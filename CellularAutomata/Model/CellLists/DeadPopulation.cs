using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata.Model.CellTypes;
using CellularAutomata.Model.Interfaces;

namespace CellularAutomata.Model
{
    public class DeadPopulation : List<ICell>, IPopulation
    {


        public DeadPopulation() : base()
        {
            //intialize here
        }

        public void AddCell(ICell cell)
        {
            cell.CellState = CellState.Dead;
            cell.CellType = CellType.Dead;
            cell.CellColor = Color.Black;
            UpdateNeighbors(cell);
        }

        public void RemoveCell(ICell cell)
        {
            //if cell is not already null -- may not be necessary, it got away from me, idk
            if (cell != null)
            {
                //remove cell
                Remove(cell);
                //update all neighbors since this cell is now gone
                foreach (KeyValuePair<int, ICell> currentCell in cell.Neighbors)
                {
                    UpdateNeighbors(currentCell.Value);
                }
            }
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
            //cells have been bitten by zombie
            if (cell.CellState == CellState.Infected)
            {
                //remove cell
                //but can't do this, because it is being called inside a foreach loop
                RemoveCell(cell);
                ////change type to zombie
                //_deadCells[i].CellType = CellType.Zombie;
                //create new cell from this cell
                ZombieCell zombieCell = new ZombieCell(cell);
                //make sure dead cell get's nulled
                cell = null;
                //add a new zombie to population
                //this needs to be changed
                ZombiePopulation.AddCell(cell);
            }
            else
            {
                this.RemoveAll(item => item == null);
            }
        }
    }
}
