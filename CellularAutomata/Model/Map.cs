﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CellularAutomata.Controller.Helpers;

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
        protected internal List<MapButton> GetVacantNeighborHosts(ICell cell)
        {
            List<MapButton> vacantNeighborHosts = new List<MapButton>();

            foreach (
                KeyValuePair<int, MapButton> neighborHost in
                    cell.HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant == null))
            {
                vacantNeighborHosts.Add(neighborHost.Value);
            }

            return vacantNeighborHosts;
        }

        //get an array of occupied buttons neighboring this cell
        protected internal List<MapButton> GetOccupiedNeighborHosts(ICell cell)
        {
            

            List<MapButton> occupiedNeighborHosts = new List<MapButton>();

            foreach (
                KeyValuePair<int, MapButton> neighborHost in
                    cell.HostButton.Neighbors.Where(neighborHost => neighborHost.Value.Tenant != null))
            {
                occupiedNeighborHosts.Add(neighborHost.Value);
            }

            return occupiedNeighborHosts;
        }

        //this is where the magic happens baby!
        public void MoveToRandomVacantMapButton(ICell cell)
        {
            //get empty neighbor hosts
            List<MapButton> vacantNeighborHosts = GetVacantNeighborHosts(cell);
            //get random index
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int randomIndex = random.Next(0, vacantNeighborHosts.Count);
            //make current _hostButton the _lastHostButton
            cell.LastHostButton = cell.HostButton;
            //remove self from current Host
            cell.HostButton.Tenant = null;
            //cell.LastHostButton.Tenant = null;
            //place this self into new host
            vacantNeighborHosts[randomIndex].Tenant = cell;
            //update _hostButton to the new spot
            cell.HostButton = vacantNeighborHosts[randomIndex];
        }
        
        //add cell
        public void AddCell(ICell cell)
        {
            cell.HostButton.Tenant = cell;
            Population.AddSorted(cell);
        }

        //remove cell
        public void RemoveCell(ICell cell)
        {
            Population.Remove(cell);
        }

        //update the map
        public void UpdateMap()
        {
            Population.DoStuff(this);
        }

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
