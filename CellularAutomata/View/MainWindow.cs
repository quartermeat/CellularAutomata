using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularAutomata.Model;

namespace CellularAutomata
{
    public partial class MainWindow : Form
    {
        private Dictionary<int, Button> buttonMap;

        public event EventHandler ButtonPressed;
        
        public MainWindow(Map map)
        {
            //do default designer stuff
            InitializeComponent();
            //do my powerful will
            CustomInitialization(map);
        }

        //do our custom intializations of the main window
        private void CustomInitialization(Map map)
        {
            //custom window attributes done outside of designer
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            mapPanel.Width = map.Width*map.Resolution;
            mapPanel.Height = map.Height*map.Resolution;
            //////////////////////////////////////////////////

            //create a map of buttons//////////////////////
            buttonMap = new Dictionary<int, Button>();

            int index = 0;
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Button newButton = new Button()
                    {
                        Width = map.Resolution,
                        Height = map.Resolution,
                        Margin = new Padding(0)
                    };
                    newButton.MouseDown += OnMouseClicked;
                    buttonMap.Add(index, newButton);
                    mapPanel.Controls.Add(newButton);
                    index++;
                }
            }
            /////////////////////////////////////////////////
        }

        public void OnMouseClicked(object sender, MouseEventArgs e)
        {
            Button pressedButton = sender as Button;

            foreach (KeyValuePair<int, Button> button in buttonMap)
            {
                if (button.Value.Equals(pressedButton))
                {
                    ButtonPressed(button, e);
                }

            }
        }
        
        public void SetupBoard(Map map)
        {
           

        }
    }
}
