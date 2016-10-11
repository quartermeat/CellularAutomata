using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata.Model.Interfaces;

namespace CellularAutomata.Model.CellLists
{
    public class InfectedPopulation : List<ICell>, IPopulation
    {
        public void AddCell(ICell cell)
        {
            cell.CellState = CellState.Infected;
            this.AddSorted(cell);
        }

        public void RemoveCell(ICell cell)
        {
            throw new NotImplementedException();
        }

        public void UpdateNeighbors(ICell cell)
        {
            throw new NotImplementedException();
        }

        public void UpdateAllNeighbors()
        {
            throw new NotImplementedException();
        }

        public List<MapButton> GetVacantNeighborHosts(ICell cell)
        {
            throw new NotImplementedException();
        }

        public List<MapButton> GetOccupiedNeighborHosts(ICell cell)
        {
            throw new NotImplementedException();
        }

        public void MoveToRandomVacantMapButton(ICell cell)
        {
            throw new NotImplementedException();
        }

        public void Live(ICell cell, Map map)
        {
            //get random index
            Random random = new Random(Guid.NewGuid().GetHashCode());
            //flip of a coin
            int randomIndex = random.Next(0, 2);

        }
    }
}
