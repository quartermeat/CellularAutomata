using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CellularAutomata.Model;

namespace CellularAutomata.Controller.Helpers
{
    public enum CellType
    {
        Original,
        Zombie
    }

    public enum CellState
    {
        Alive,
        Dead
    }
    
    public interface ICell : IComparable<ICell>
    {
        CellType CellType { get; }

        CellState CellState { get; }

        Dictionary<int, Point> Parameter { get; set; }

        Color CellColor { get; set; }

        Point Location { get; set; }

        MapButton HostButton { get; set; }

        Dictionary<int, ICell> Neighbors { get; set; }

        bool ZombieBite { get; set; }

        int Agility { get; set; }

        int OriginalAgility { get; set; }

        string ToString();


    }
}
