using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CellularAutomata.Model.Enums.CellType;
using CellularAutomata.Model.Interfaces;

namespace CellularAutomata.Model.CellTypes
{
    //a zombie cell
    public class ZombieCell : Cell
    {
        public ZombieCell(MapButton newHost) : base(newHost)
        {
            //make sure we know it's a zombie cell
            _cellType = CellType.Zombie;
            //zombies are green
            _cellColor = Color.Green;
            //zombies are slow
            _agility = 1;
        }

        public ZombieCell(ICell theUnfortunate) : base(theUnfortunate.HostButton)
        {
            //your green now unfortunate
            _cellColor = Color.Green;
            //and your slow
            _agility = 1;
            //make sure it is now a zombie cell
            _cellType = CellType.Zombie;
            
        }
        
        public void GoGetBrains(Map map)
        {
            //get surrounding original cells.. they only eat original cells... for now
            List<ICell> originalCells = (from host in map.Population.GetOccupiedNeighborHosts(this) where host.Tenant.CellType == CellType.Original select host.Tenant).ToList();

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

                //bite unfortunate neighbor 
                Bite(originalCells[randomIndex], map);

            }
        }

        public void Bite(ICell victim, Map map)
        {
            //maybe add some conditionals here based on cell attributes


            //create a new infected cell from victim
            InfectedCell infectedCell = new InfectedCell(victim);

            //remove victim from original population 
            map.Population.OriginalPopulation.RemoveCell(victim);

            //victim should stop acting in it's current population
            //this is only necessary because this victim was not modified on it's turn in the loop
            victim.ShouldLive = false;
            
            //add infected cell to infected population
            map.Population.InfectedPopulation.AddCell(infectedCell);
        }

        #region interface
       
       
        #endregion
    }
}
