using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata.Model.CellTypes
{
    //an infected cell
    class InfectedCell : Cell
    {
        public InfectedCell(MapButton newHost) : base(newHost)
        {
            //random num generator
            Random random = new Random(Guid.NewGuid().GetHashCode());
            //change the color
            _cellColor = Color.CadetBlue;
            //random Agility between 1 and 2
            _agility = random.Next(1, 3);
            //change the type flag
            _cellType = CellType.Infected;
        }

        public InfectedCell(ICell theUnfortunate) : base(theUnfortunate.HostButton)
        {
            //remove 1 agility from the original
            _agility = theUnfortunate.Agility--;
            //change the color
            _cellColor = Color.CadetBlue;
            //change the type flag
            _cellType = CellType.Infected;
            
        }
    }
}
