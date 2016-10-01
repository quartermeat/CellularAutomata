namespace CellularAutomata.Model
{
    //map should keep track of the state of the spaces on the gameboard as well as be used to track cells
    public class Map
    {
        //how many squares horizontally
        public int Width;
        //how many squares vertically
        public int Height;
        //how big are the squares
        public int Resolution;

        public Map()
        {
            Width = 50;
            Height = 50;
            Resolution = 15;
        }
    }
}
