using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomata.Model
{
    public class MapButton : Button
    {
        public Point Location;

        public Cell Tenant;

        public MapButton() : base()
        {
            
        }
    }
}
