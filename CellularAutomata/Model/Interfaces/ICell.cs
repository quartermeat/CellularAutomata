using System;
using System.Collections.Generic;
using System.Drawing;

namespace CellularAutomata.Model
{
    public interface ICell : IComparable<ICell>
    {
        //fields
        CellType CellType { get; set; }
        
        Dictionary<int, Point> Parameter { get; set; }

        Color CellColor { get; set; }

        Point Location { get; set; }

        MapButton HostButton { get; set; }

        Dictionary<int, ICell> Neighbors { get; set; }
        
        //methods
        int Agility { get; set; }

        int OriginalAgility { get; set; }

        string ToString();


    }
}
