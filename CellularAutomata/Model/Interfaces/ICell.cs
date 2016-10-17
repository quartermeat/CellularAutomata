using System;
using System.Collections.Generic;
using System.Drawing;
using CellularAutomata.Model.Enums.CellType;

namespace CellularAutomata.Model.Interfaces
{
    public interface ICell : IComparable<ICell>
    {
        //fields
        CellType CellType { get; set; }
        
        Dictionary<int, Point> Parameter { get; set; }

        Color CellColor { get; set; }

        Point Location { get; set; }

        bool ShouldLive { get; set; }

        MapButton HostButton { get; set; }

        Dictionary<int, ICell> Neighbors { get; set; }

        int MoveOrder { get; set; }

        //what makes a cell SPECIAL; besides it's type of course
        int Strength { get; set; }

        int Perception { get; set; }

        //gonna flesh this out now; will affect sleep and infected times
        int Endurance { get; set; }

        int Charisma { get; set; }

        int Intelligence { get; set; }

        //right now only determines move order, and is affected by neighbors
        int Agility { get; set; }

        int Luck { get; set; }

        //methods
        void ResetMoveOrder();

        string ToString();
    }
}
