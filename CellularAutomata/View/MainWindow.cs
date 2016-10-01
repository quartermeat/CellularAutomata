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
        private Dictionary<int, MapButton> buttonMap;

        public event EventHandler MapButtonPressed;
        public event EventHandler StartButtonPressed;
        
        public MainWindow(Map map)
        {
            //do default designer stuff
            InitializeComponent();
        }

        //do our custom intializations of the main window
        public void SetupMap(Map map)
        {
            //custom window attributes done outside of designer
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            mapPanel.Width = map.Width*map.Resolution;
            mapPanel.Height = map.Height*map.Resolution;
            mapPanel.Margin = new Padding(0);
            //////////////////////////////////////////////////

            //create a map of buttons//////////////////////
            buttonMap = new Dictionary<int, MapButton>();

            int index = 0;
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    MapButton newButton = new MapButton()
                    {
                        Width = map.Resolution,
                        Height = map.Resolution,
                        Margin = new Padding(0),
                        Location = new Point(j, i)

                    };
                    newButton.MouseDown += OnMouseClicked;
                    buttonMap.Add(index, newButton);
                    mapPanel.Controls.Add(newButton);
                    index++;
                }
            }
            /////////////////////////////////////////////////

            startButton.Click += OnStartButtonPressed;
        }

        //update timer label
        public void UpdateTimerLabel(string timeString)
        {
            //update label with that string
            timerLabel.Text = timeString;
        }

        //update population label
        public void UpdatePopulationCountLabel(int populationCount)
        {
            populationCountLabel.Text = populationCount.ToString();
        }

        //update start button
        public void UpdateStartButton(string buttonText)
        {
            startButton.Text = buttonText;
        }
        
        //draw population as it is
        public void DrawPopulation(List<Cell> population)
        {
            foreach (KeyValuePair<int, MapButton> currentButton in buttonMap)
            {
                if (currentButton.Value.Tenant == null)
                {
                    currentButton.Value.BackColor = DefaultBackColor;
                }
                else
                {
                    currentButton.Value.BackColor = currentButton.Value.Tenant.CellColor;
                }
            }
        }

        //update a single button
        public void DrawTenantCell(MapButton currentButton)
        {
            if (currentButton.Tenant == null)
            {
                currentButton.BackColor = DefaultBackColor;
            }
            else
            {
                currentButton.BackColor = currentButton.Tenant.CellColor;
            }
        }

        //handle button presses
        public void OnMouseClicked(object sender, MouseEventArgs e)
        {
            MapButton pressedButton = sender as MapButton;

            foreach (KeyValuePair<int, MapButton> button in buttonMap.Where(button => button.Value.Equals(pressedButton)))
            {
                if (MapButtonPressed != null) MapButtonPressed(button, e);
            }
        }

        public void OnStartButtonPressed(object sender, EventArgs e)
        {
            if (StartButtonPressed != null) StartButtonPressed(sender, e);
        }
    }
}
