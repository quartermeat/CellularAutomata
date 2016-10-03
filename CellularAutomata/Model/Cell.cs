﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
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

        public Dictionary<int, Point> Parameter;
        public Color CellColor;
        public Point Location;
        public MapButton HostButton;
        public Dictionary<int, Cell> Neighbors; 
        //public List<Cell> NeighborCells;

        //constructor: setup defaults
        public Cell(Point newLocation, MapButton newHost)
        {
            //initialize neighbors
            Neighbors = new Dictionary<int, Cell>();
            //setup its host
            HostButton = newHost;
            //setup defaults here
            CellColor = Color.Blue;
            Location = newLocation;
            //setup parameter
            Parameter = new Dictionary<int, Point>();
            SetParameter(1);
            //get neighbors in parameter
            UpdateNeighbors();
        }

        //this is where the magic happens baby!
        public void OnTick()
        {
            //random generator
            Random random = new Random();
            //random from all the directions North to NorthWest
            int direction = random.Next(0, 7);
            
            
        }

        //cell knows where it's parameter is
        public void SetParameter(int distance)
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

        public void UpdateNeighbors()
        {
            //get neighbor buttons and if they have an occupant, set them as a neighbor
            foreach (KeyValuePair<int, MapButton> neighborHost in HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant != null).Where(neighborHost => !Neighbors.ContainsKey(neighborHost.Key)))
            {
                //add this cell as a neighbor
                Neighbors.Add(neighborHost.Key, neighborHost.Value.Tenant);
            }
            foreach (
                KeyValuePair<int, MapButton> neighborHost in
                    HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant == null))
            {
                Neighbors.Remove(neighborHost.Key);
            }
        }
    }
}