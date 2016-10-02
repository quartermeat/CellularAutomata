using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

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
        //map
        public static List<MapButton> ButtonMap { get; private set; }
        
        public Map()
        {
            ButtonMap = new List<MapButton>();

            Width = 50;
            Height = 50;
            Resolution = 15;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    MapButton newButton = new MapButton(null, new Point(j,i))
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

        public static MapButton GetMapButtonAt(Point location)
        {
            if (location.X < 0 || location.Y < 0)
            {
                return null;
            }
            
            foreach (MapButton mapButton in ButtonMap)
            {
                if (mapButton.MapLocation == location)
                {
                    return mapButton;
                }
            }

            return null;
        }
    }
}
