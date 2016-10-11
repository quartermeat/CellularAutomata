using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata.Model.Interfaces
{
    interface IPopulation
    {
        //members

        //methods
        void AddCell(ICell cell);

        void RemoveCell(ICell cell);

        void UpdateNeighbors(ICell cell);

        void UpdateAllNeighbors();

        List<MapButton> GetVacantNeighborHosts(ICell cell);

        List<MapButton> GetOccupiedNeighborHosts(ICell cell);

        void MoveToRandomVacantMapButton(ICell cell);

        void Live(ICell cell, Map map);
    }
}
