using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CellularAutomata.Controller.Helpers;
using CellularAutomata.Model;

namespace CellularAutomata.View
{
    public partial class MainWindow : Form
    {
        public event EventHandler MapButtonPressed;
        public event EventHandler StartButtonPressed;
        public event EventHandler ShowStatusBoxMenuItemClicked;

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

        //draw population as it is
        public void DrawMap(Map map)
        {
            foreach (var currentCell in map.Population)
            {
                //clear the old host button
                DrawTenantCell(currentCell.LastHostButton);
                //draw new host
                DrawTenantCell(currentCell.HostButton);
            }
        }

        //update a single button
        public void DrawTenantCell(MapButton currentButton)
        {
            if (currentButton == null) return;
            currentButton.BackColor = currentButton.Tenant == null ? DefaultBackColor : currentButton.Tenant.CellColor;
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
            }

            return CellType.Original;
        }
    }
}
