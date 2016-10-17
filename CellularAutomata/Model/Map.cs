using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using CellularAutomata.Model.Interfaces;

namespace CellularAutomata.Model
{
    //map should keep track of the state of the spaces on the gameboard as well as be used to track cells
    public class Map
    {
        //how many squares horizontally
        public static int Width;
        //how many squares vertically
        public static int Height;
        //how big are the squares
        public static int Resolution;
        //color of map at day
        public static Color MapNightColor;
        //color of map at night
        public static Color MapDayColor;
        //current color of map
        public static Color CurrentMapColor;
        
        
        //population loaded to the map
        public Population Population { get; private set; }
        //map
        public static List<MapButton> ButtonMap { get; private set; }

        public Map(Population loadedPopulation)
        {
            ButtonMap = new List<MapButton>();
            Population = loadedPopulation;

            Width = 50;
            Height = 50;
            Resolution = 15;

            MapNightColor = Color.DimGray;
            MapDayColor = Color.LightGray;

            CurrentMapColor = MapNightColor;
            

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    MapButton newButton = new MapButton(new Point(j, i))
                    {
                        Width = Resolution,
                        Height = Resolution,
                        Margin = new Padding(0)
                    };
                    ButtonMap.Add(newButton);
                }
            }

            foreach (MapButton button in ButtonMap)
            {
                button.SetNeighbors();
            }
        }

        //update neighbors
        public void UpdateNeighbors(ICell cell)
        {
            Population.UpdateNeighbors(cell);
        }

        //update all neighbors
        public void UpdateAllNeighbors()
        {
            //update all populations neighbors
            Population.UpdateAllNeighbors();
        }

        //get an array of empty buttons neighboring this cell
        protected List<MapButton> GetVacantNeighborHosts(ICell cell)
        {
            return Population.GetVacantNeighborHosts(cell);
        }

        //get an array of occupied buttons neighboring this cell
        protected List<MapButton> GetOccupiedNeighborHosts(ICell cell)
        {
            return Population.GetOccupiedNeighborHosts(cell);
        }

        //move cells randomly////////////////////////////////////////////////
        public void MoveToRandomVacantMapButton(ICell cell)
        {
            Population.MoveToRandomVacantMapButton(cell);
        }
        ///////////////////////////////////////////////////////////////////
        
        //add cell
        public void AddCell(ICell cell)
        {
            Population.AddCell(cell);
        }

        //remove cell
        public void RemoveCell(ICell cell)
        {
            Population.RemoveCell(cell);
        }

        //update the map/////////////////////////////////
        public void UpdateMap()
        {
            //make population do their thing on current map
            Population.Live(this);
            //sort population to make sure all changes affect the order
            Population.SortAll();
        }
        //////////////////////////////////////////////////

        //get a map button at specific location
        public static MapButton GetMapButtonAt(Point location)
        {
            if (location.X < 0 || location.Y < 0)
            {
                return null;
            }

            return ButtonMap.FirstOrDefault(mapButton => mapButton.MapLocation == location);
        }
    }
}
