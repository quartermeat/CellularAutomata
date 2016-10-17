using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CellularAutomata.Model.Interfaces;

namespace CellularAutomata.Model
{
    public class MapButton : Button
    {
        private const int N = 0;
        private const int NE = 1;
        private const int E = 2;
        private const int SE = 3;
        private const int S = 4;
        private const int SW = 5;
        private const int W = 6;
        private const int NW = 7;

        public Point MapLocation { get; set; }

        public ICell Tenant { get; set; }

        public Dictionary<int, MapButton> Neighbors { get; private set; }

        public Dictionary<int, Point> Parameter { get; private set; }
        
        
        public MapButton(Point mapLocation) : base()
        {
            MapLocation = mapLocation;
            //setup neighbors
            Neighbors = new Dictionary<int, MapButton>();
        }

        //cell knows where it's parameter is
        public void SetParameter(int distance)
        {
            // Get North as a point and add it to the list
            Point north = Point.Add(MapLocation, new Size(0, -distance));
            Parameter.Add(N, north);
            // Get NE as a point and add it to the list
            Point northEast = Point.Add(MapLocation, new Size(distance, -distance));
            Parameter.Add(NE, northEast);
            // Get East as a point and add it to the list
            Point east = Point.Add(MapLocation, new Size(distance, 0));
            Parameter.Add(E, east);
            // Get SE as a point and add it to the list
            Point southEast = Point.Add(MapLocation, new Size(distance, distance));
            Parameter.Add(SE, southEast);
            // Get South as a point and add it to the list
            Point south = Point.Add(MapLocation, new Size(0, distance));
            Parameter.Add(S, south);
            // Get SW as a point and add it to the list
            Point southWest = Point.Add(MapLocation, new Size(-distance, distance));
            Parameter.Add(SW, southWest);
            // Get West as a point and add it to the list
            Point west = Point.Add(MapLocation, new Size(-distance, 0));
            Parameter.Add(W, west);
            // Get NW as a point and add it to the list 
            Point northWest = Point.Add(MapLocation, new Size(-distance, -distance));
            Parameter.Add(NW, northWest);
        }

        public void SetNeighbors()
        {
            //setup parameter
            Parameter = new Dictionary<int, Point>();
            SetParameter(1);
            
            foreach (KeyValuePair<int, Point> location in Parameter)
            {
                MapButton mapButton = Map.GetMapButtonAt(location.Value);
                
                if (mapButton != null)
                {
                    Neighbors.Add(location.Key, mapButton);
                }
                
            }
        }

    }
}
