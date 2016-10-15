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

        int Agility { get; set; }

        int MoveOrder { get; set; }
        
        //methods
        void ResetMoveOrder();

        string ToString();
    }
}
