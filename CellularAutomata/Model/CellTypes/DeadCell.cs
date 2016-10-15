using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata.Model.CellTypes
{
    //a dead cell

    internal class DeadCell : Cell
    {
        private bool _wasInfected;

        //constructor
        public DeadCell(MapButton newHost) : base(newHost)
        {
            //new dead body
            _wasInfected = false;
            //make sure we know it's a dead cell
            _cellType = CellType.Dead;
            //zombies are green
            _cellColor = Color.Black;
            //dead are slow
            _agility = 0;
        }

        public DeadCell(ICell theUnfortunate) : base(theUnfortunate.HostButton)
        {
            //if dead cell was from an infected type
            if (theUnfortunate.CellType == CellType.Infected)
            {
                //make sure we keep track of that fact
                _wasInfected = true;
            }

            //your black now unfortunate
            _cellColor = Color.Black;
            //and your slow
            _agility = 0;
            //make sure it is now a dead cell
            _cellType = CellType.Dead;
        }

        public bool WasInfected
        {
            get { return _wasInfected; }
            set
            {
                _wasInfected = value;
                _wasInfected = WasInfected;
            }
        }

    }
}
