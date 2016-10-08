using System;
using System.Collections.Generic;
using System.Drawing;

namespace CellularAutomata.Model
{
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