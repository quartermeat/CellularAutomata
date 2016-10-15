using System;
using System.Collections.Generic;
using System.Drawing;

namespace CellularAutomata.Model
{
    //the basic automata unit
    public class Cell : ICell
    {
        //directions/////////////
        private const int N = 0;
        private const int NE = 1;
        private const int E = 2;
        private const int SE = 3;
        private const int S = 4;
        private const int SW = 5;
        private const int W = 6;
        private const int NW = 7;
        
        //fields
        private Dictionary<int, Point> _parameter;
        protected Color _cellColor;
        private Point _location;
        private MapButton _hostButton;
        private Dictionary<int, ICell> _neighbors;
        protected int _agility;
        private int _moveOrder;
        protected CellType _cellType;
        
        //constructor: setup defaults
        public Cell(MapButton newHost)
        {
            //random num generator
            Random random = new Random(Guid.NewGuid().GetHashCode());
            //random Agility between 2 and 3
            _agility = random.Next(2, 4);
            //initialize neighbors
            _neighbors = new Dictionary<int, ICell>();
            //add newHost to this cell's host
            _hostButton = newHost;
            //add this cell to the host
            _hostButton.Tenant = this;
            //set cell type color
            _cellColor = Color.Blue;
            //set location based on the host button
            _location = newHost.MapLocation;
            //setup parameter
            _parameter = new Dictionary<int, Point>();
            //set parameter as all spaces within a distance of 1 space away
            SetParameter(1);
        }
        

        //reset move order
        public void ResetMoveOrder()
        {
            MoveOrder = Agility;
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
            get { return _cellType; }
            set
            {
                _cellType = value;
                _cellType = CellType;
            }
        }
      
        public Dictionary<int, Point> Parameter
        {
            get { return _parameter; }
            set
            {
                _parameter = value;
                _parameter = Parameter;
            }
        }

        public Color CellColor
        {
            get { return _cellColor; }
            set
            {
                _cellColor = value;
                _cellColor = CellColor;
            }
        }

        public Point Location
        {
            get { return _location; }
            set
            {
                _location = value;
                _location = Location;
            }
        }

        public MapButton HostButton
        {
            get { return _hostButton; }
            set
            {
                _hostButton = value;
                _hostButton = HostButton;
            }
        }
        
        public Dictionary<int, ICell> Neighbors
        {
            get { return _neighbors; }
            set
            {
                _neighbors = value;
                _neighbors = Neighbors;
            }
        }

        public int Agility
        {
            get { return _agility; }
            set
            {
                _agility = value;
                _agility = Agility;
            }
        }

        public int MoveOrder
        {
            get { return _moveOrder; }
            set
            {
                _moveOrder = value;
                _moveOrder = MoveOrder;
            }
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
                return MoveOrder.CompareTo(otherCell.MoveOrder);
            }
            else
            {
                return -1;
            }
        }
        
        #endregion
    }
}
