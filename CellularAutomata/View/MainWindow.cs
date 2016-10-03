using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CellularAutomata.Model;

namespace CellularAutomata.View
{
    public partial class MainWindow : Form
    {
        public event EventHandler MapButtonPressed;
        public event EventHandler StartButtonPressed;
        
        public MainWindow()
        {
            //do default designer stuff
            InitializeComponent();
        }

        //do our custom intializations of the main window
        public void SetupMap()
        {
            //custom window attributes done outside of designer
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            mapPanel.Width = Map.Width*Map.Resolution;
            mapPanel.Height = Map.Height*Map.Resolution;
            mapPanel.Margin = new Padding(0);
            //////////////////////////////////////////////////

            //add buttonMap to panel//////////////////////
            foreach (MapButton currentMapButton in Map.ButtonMap)
            {
                currentMapButton.MouseDown += OnMouseClicked;
                mapPanel.Controls.Add(currentMapButton);
            }

            startButton.Click += OnStartButtonPressed;
            startButton.BackColor = Color.Green;
        }

        //update timer label
        public void UpdateTimerLabel(string timeString)
        {
            //update label with that string
            timerLabel.Text = timeString;
        }

        //update neighbor count label
        public void UpdateNeighborCountLabel(int neighborCount)
        {
            neighborCellCountLabel.Text = neighborCount.ToString();
        }

        //update neighbor location label
        public void UpdateNeighborLocationLabel(string locationsString)
        {
            neighborLocationLabel.Text = locationsString;
        }

        //update population label
        public void UpdatePopulationCountLabel(int populationCount)
        {
            populationCountLabel.Text = populationCount.ToString();
        }

        //update start button
        public void UpdateStartButton(string buttonText, Color color)
        {
            startButton.Text = buttonText;
            startButton.BackColor = color;
        }

        //update neighbor label titles
        public void UpdateNeighborLabelTitles(string newText)
        {
            neighborCountLableTitle.Text = "Selected " + newText + "'s neighbor count:";
            selectedCellNeighborLocationLabelTitle.Text = "Selected " + newText + "'s neighbor locations:";
        }
        
        //draw population as it is
        public void DrawPopulation(List<Cell> population, Map map)
        {
            foreach (MapButton currentButton in Map.ButtonMap)
            {
                currentButton.BackColor = currentButton.Tenant == null ? DefaultBackColor : currentButton.Tenant.CellColor;
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

            foreach (MapButton currentMapButton in Map.ButtonMap.Where(button => button.Equals(pressedButton)))
            {
                if (MapButtonPressed != null) MapButtonPressed(currentMapButton, e);
            }
        }

        public void OnStartButtonPressed(object sender, EventArgs e)
        {
            if (StartButtonPressed != null) StartButtonPressed(sender, e);
        }
    }
}
