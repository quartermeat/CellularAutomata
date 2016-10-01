using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomata.Model
{
    //an automata unit that behaves according to state and behavior
    public class Cell
    {
        private const int N = 0;
        private const int NE = 1;
        private const int E = 2;
        private const int SE = 3;
        private const int S = 4;
        private const int SW = 5;
        private const int W = 6;
        private const int NW = 7;

        public Dictionary<int, Point> parameter;
        public Color CellColor;
        public Point Location;
        public MapButton HostButton;

        //constructor: setup defaults
        public Cell(Point newLocation)
        {
            //setup defaults here
            CellColor = Color.Blue;
            Location = newLocation;
        }

        private void SetParameter(int distance)
        {
            // Get North as a point and add it to the list
            Point north = Point.Add(Location, new Size(0, distance));
            parameter.Add(N, north);
            // Get NE as a point and add it to the list
            Point northEast = Point.Add(Location, new Size(distance, distance));
            parameter.Add(NE, northEast);
            // Get East as a point and add it to the list
            Point east = Point.Add(Location, new Size(distance, 0));
            parameter.Add(E, east);
            // Get SE as a point and add it to the list
            Point southEast = Point.Add(Location, new Size(distance, -distance));
            parameter.Add(SE, southEast);
            // Get South as a point and add it to the list
            Point south = Point.Add(Location, new Size(0, -distance));
            parameter.Add(S, south);
            // Get SW as a point and add it to the list
            Point southWest = Point.Add(Location, new Size(-distance, -distance));
            parameter.Add(SW, southWest);
            // Get West as a point and add it to the list
            Point west = Point.Add(Location, new Size(-distance, 0));
            parameter.Add(W, west);
            // Get NW as a point and add it to the list 
            Point northWest = Point.Add(Location, new Size(-distance, distance));
            parameter.Add(NW, northWest);
        }

    }
}
