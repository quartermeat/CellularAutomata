using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CellularAutomata.Model;
using CellularAutomata.Model.Enums.CellType;

namespace CellularAutomata.View
{
    public partial class MainWindow : Form
    {
        public event EventHandler MapButtonPressed;
        public event EventHandler StartButtonPressed;
        public event EventHandler ShowStatusBoxMenuItemClicked;
        public event EventHandler ChangedTimerTrackBar;
    
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
            mapPanel.Width = Map.Width * Map.Resolution;
            mapPanel.Height = Map.Height * Map.Resolution;
            mapPanel.Margin = new Padding(0);
            //////////////////////////////////////////////////

            //add buttonMap to panel//////////////////////
            foreach (MapButton currentMapButton in Map.ButtonMap)
            {
                currentMapButton.FlatStyle = FlatStyle.Flat;
                currentMapButton.FlatAppearance.BorderSize = 1;
                currentMapButton.FlatAppearance.BorderColor = Map.CurrentMapColor;
                currentMapButton.BackColor = Map.CurrentMapColor;
                currentMapButton.TabStop = false;
                currentMapButton.MouseDown += OnMouseClicked;
                mapPanel.Controls.Add(currentMapButton);
            }

            startButton.Click += OnStartButtonPressed;
            startButton.BackColor = Color.Green;
        }

        //update timer label
        public void UpdateTimerLabels(string timeString)
        {
            //update label with that string
            timerHourLabel.Text = timeString;
        }

        //update count labels
        public void UpdateCountLabels(Population population)
        {
            originalPopulationCountLabel.Text = population.GetOriginalCells().Count.ToString();
            zombiePopulationCountLabel.Text = population.GetZombieCells().Count.ToString();
        }

        //update start button
        public void UpdateStartButton(string buttonText, Color color)
        {
            startButton.Text = buttonText;
            startButton.BackColor = color;
        }

        //draw population as it is
        public void DrawMap(Map map, bool isDayLight)
        {
            //if the map is not the right color for the time of day... draw empty buttons aswell
            if (isDayLight && Map.CurrentMapColor == Map.MapNightColor)
            {
                DrawEmptyMapSpaces(true);

            }
            else if (!isDayLight && Map.CurrentMapColor == Map.MapDayColor)
            {
                DrawEmptyMapSpaces(false);
            }

            //draw all cells
            foreach (var currentCell in map.Population.GetOriginalCells())
            {
                //draw new host
                DrawTenantCell(currentCell.HostButton);
            }
            foreach (var currentCell in map.Population.GetZombieCells())
            {
                //draw new host
                DrawTenantCell(currentCell.HostButton);
            }
            foreach (var currentCell in map.Population.GetDeadCells())
            {
                //draw new host
                DrawTenantCell(currentCell.HostButton);
            }
            foreach (var currentCell in map.Population.GetInfectedCells())
            {
                DrawTenantCell(currentCell.HostButton);
            }

        }

        //draw all empty map buttons
        private void DrawEmptyMapSpaces(bool isDayLight)
        {
            //change the color of the map depending what time of day it is
            Map.CurrentMapColor = isDayLight ? Map.MapDayColor : Map.MapNightColor;

            //update the color
            foreach (MapButton mapButton in Map.ButtonMap.Where(mapButton => mapButton.Tenant == null))
            {
                mapButton.BackColor = Map.CurrentMapColor;
                mapButton.FlatAppearance.BorderColor = Map.CurrentMapColor;
            }
        }

        //update a single button
        public void DrawTenantCell(MapButton currentButton)
        {
            if (currentButton == null) return;
            if (currentButton.Tenant != null)
            {
                currentButton.BackColor = currentButton.Tenant.CellColor;
                currentButton.FlatAppearance.BorderColor = Map.CurrentMapColor;    
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

        //update start button
        public void OnStartButtonPressed(object sender, EventArgs e)
        {
            if (StartButtonPressed != null) StartButtonPressed(sender, e);
        }

        //handle context status box menu item selection
        private void showStatusBoxMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowStatusBoxMenuItemClicked != null) ShowStatusBoxMenuItemClicked(sender, e);
        }

        //populate combo box with cell types
        public void PopulateCellTypeComboBox(List<string> cellTypeList)
        {
            cellTypeComboBox.DataSource = cellTypeList;
        }

        //get CellTypeComboBox selection
        public CellType GetCellTypeComboxSelection()
        {
            switch (cellTypeComboBox.SelectedItem.ToString())
            {
                case "Original":
                    {
                        return CellType.Original;
                    }
                case "Zombie":
                    {
                        return CellType.Zombie;
                    }
                case "Dead":
                    {
                        return CellType.Dead;
                    }
                case "Infected":
                    {
                        return CellType.Infected;
                    }
            }

            return CellType.Original;
        }

        //handle scrolling of timer track bar
        private void timerTrackBar_Scroll(object sender, EventArgs e)
        {
            speedLabel.Text = timerTrackBar.Value.ToString();
            if (ChangedTimerTrackBar != null) ChangedTimerTrackBar(sender, e);
        }

        //get timer track bar setting
        public int GetTimerTrackBarValue()
        {
            return timerTrackBar.Value;
        }
    }
}
