using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CellularAutomata.Controller.Helpers;

namespace CellularAutomata.Model
{
    //an automata unit that behaves according to state and behavior
    public class Cell : ICell
    {
        private const int N = 0;
        private const int NE = 1;
        private const int E = 2;
        private const int SE = 3;
        private const int S = 4;
        private const int SW = 5;
        private const int W = 6;
        private const int NW = 7;

        private Dictionary<int, Point> _parameter;
        private Color _cellColor;
        private Point _location;
        private MapButton _hostButton;
        private MapButton _lastHostButton;
        private Dictionary<int, ICell> _neighbors;
        private int _agility;
        
        //constructor: setup defaults
        public Cell(MapButton newHost)
        {
            //random num generator
            Random random = new Random(Guid.NewGuid().GetHashCode());

            //random Agility between 1 and 3
            _agility = random.Next(1, 4);
            //initialize neighbors
            _neighbors = new Dictionary<int, ICell>();
            //setup its hosts
            _hostButton = newHost;
            _lastHostButton = new MapButton(newHost.MapLocation);
            //setup defaults here
            _cellColor = Color.Blue;
            //set location based on the host button
            _location = newHost.MapLocation;
            //setup parameter
            _parameter = new Dictionary<int, Point>();
            SetParameter(1);
            
        }
        
        //cell knows where it's parameter is
        protected void SetParameter(int distance)
        {
            // Get North as a point and add it to the list
            Point north = Point.Add(Location, new Size(0, distance));
            Parameter.Add(N, north);
            // Get NE as a point and add it to the list
            Point northEast = Point.Add(Location, new Size(distance, distance));
            Parameter.Add(NE, northEast);
            // Get East as a point and add it to the list
            Point east = Point.Add(Location, new Size(distance, 0));
            Parameter.Add(E, east);
            // Get SE as a point and add it to the list
            Point southEast = Point.Add(Location, new Size(distance, -distance));
            Parameter.Add(SE, southEast);
            // Get South as a point and add it to the list
            Point south = Point.Add(Location, new Size(0, -distance));
            Parameter.Add(S, south);
            // Get SW as a point and add it to the list
            Point southWest = Point.Add(Location, new Size(-distance, -distance));
            Parameter.Add(SW, southWest);
            // Get West as a point and add it to the list
            Point west = Point.Add(Location, new Size(-distance, 0));
            Parameter.Add(W, west);
            // Get NW as a point and add it to the list 
            Point northWest = Point.Add(Location, new Size(-distance, distance));
            Parameter.Add(NW, northWest);
        }
        
        #region interface

        public CellType CellType
        {
            get { return CellType.Original; }
        }

        public Dictionary<int, Point> Parameter
        {
            get { return _parameter; }
            set { _parameter = Parameter; }
        }

        public Color CellColor
        {
            get { return _cellColor; }
            set { _cellColor = CellColor; }
        }

        public Point Location
        {
            get { return _location; }
            set { _location = Location; }
        }

        public MapButton HostButton
        {
            get { return _hostButton; }
            set { _hostButton = HostButton; }
        }

        public MapButton LastHostButton
        {
            get { return _lastHostButton; }
            set { _lastHostButton = LastHostButton; }
        }

        public Dictionary<int, ICell> Neighbors
        {
            get { return _neighbors; }
            set { _neighbors = Neighbors; }
        }

        public int Agility
        {
            get { return _agility; }
            set { _agility = Agility; }
        }
        
        //methods//////////////////////////////////
        public override string ToString()
        {
            return "Original";
        }

        //to keep cells sorted
        public int CompareTo(ICell otherCell)
        {
            if (otherCell != null)
            {
                return Agility.CompareTo(otherCell.Agility);
            }
            else
            {
                throw new ArgumentException("Object is not a Cell");
            }
        }
        
        #endregion
    }
}
