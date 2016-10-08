using System;
using System.Collections.Generic;
using System.Drawing;
using CellularAutomata.Model;

namespace CellularAutomata.Controller.Helpers
{
    public enum CellType
    {
        Original,
        Zombie
    }
    
    public interface ICell : IComparable<ICell>
    {
        CellType CellType { get; }
        
        Dictionary<int, Point> Parameter { get; set; }

        Color CellColor { get; set; }

        Point Location { get; set; }

        MapButton HostButton { get; set; }

        MapButton LastHostButton { get; set; }

        Dictionary<int, ICell> Neighbors { get; set; }

        int Agility { get; set; }

        string ToString();


    }
}
