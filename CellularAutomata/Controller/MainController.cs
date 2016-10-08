using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CellularAutomata.Controller.Helpers;
using CellularAutomata.Model;
using CellularAutomata.Model.CellTypes;
using CellularAutomata.View;

namespace CellularAutomata.Controller
{
    //main controller class that makes the magic happen
    class MainController
    {
        //declare views here
        private Map map;
        //declare model stuff here
        private MainWindow mainWindow;
        private StatusBox statusBox = new StatusBox();

        //simulation timer
        private readonly Timer timer;
        private int timerCounter;

        public MainController()
        {
            //right now model initalization needs to be done before the view, because the view uses the model

            //intialize model *this is setup this way so we can eventually load saved populations
            map = new Map(new Population());

            //setup timer
            timer = new Timer();
            timer.Interval = 250; //1/4 sec
            timer.Tick += TimerTick;
            timerCounter = 0;

            //initialize view
            mainWindow = new MainWindow();
            mainWindow.SetupMap();
            //setup combo box
            PopulateCellTypesComboBox();

            //set up event handling
            mainWindow.MapButtonPressed += OnMapButtonClicked;
            mainWindow.StartButtonPressed += OnStartButtonClicked;
            mainWindow.ShowStatusBoxMenuItemClicked += OnShowStatusBoxMenuItemClicked;

            //show the window
            mainWindow.ShowDialog();
        }

        //do stuff on the timer tick
        private void TimerTick(object cvsender, EventArgs e)
        {
            timerCounter++;
            mainWindow.UpdateTimerLabel(GetTimeString());

            //main game logic has to happen here
            //do cell tick stuff////////////////////////////
            map.UpdateMap();
            ///////////////////////////////////////////////
            //update the window
            mainWindow.DrawMap(map);
        }

        //format time
        public string GetTimeString()
        {
            //create time span from our counter (divide by 4 because each tick happens at 1/4 second
            TimeSpan time = TimeSpan.FromSeconds(timerCounter/4);

            //format that into a string
            string timeString = time.ToString(@"mm\:ss");

            //return it
            return timeString;
        }

        //handle start button clicked
        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            //if timer is going
            if (timer.Enabled)
            {
                //stop timer
                timer.Stop();
                //update Start button text
                mainWindow.UpdateStartButton("Start", Color.Green);
            }
            else
            {
                //start timer
                timer.Start();
                //update Start button text
                mainWindow.UpdateStartButton("Stop", Color.Red);
            }
        }

        //handle ShowStatusBox menu item selected
        private void OnShowStatusBoxMenuItemClicked(object sender, EventArgs e)
        {
            statusBox.Show();
        }

        //handle a button press
        private void OnMapButtonClicked(object sender, EventArgs e)
        {
            //get right click
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            
            //get the current button that was clicked
            MapButton mapButton = (MapButton)sender;
            
            if (mouseEventArgs != null && mouseEventArgs.Button == MouseButtons.Right)
            {
                //if cell is in button
                if (mapButton.Tenant != null)
                {
                    //take cell out of population
                    map.RemoveCell(mapButton.Tenant);
                    //update window
                    mainWindow.DrawTenantCell(mapButton);
                }
                
                //update neighbors
                foreach (var cell in map.Population)
                {
                    map.UpdateNeighbors(cell);
                }
                //update labels
                mainWindow.UpdateOriginalPopulationCountLabel(map.Population.OriginalCount);
                mainWindow.UpdateZombiePopulationCountLabel(map.Population.ZombieCount);
                UpdateStatusBoxNeighborLabels(mapButton);
            }
            else if (mapButton.Tenant == null)//if there is not already a cell there
            {
                CellType cellType = mainWindow.GetCellTypeComboxSelection();
                ICell newCell = null;
                
                if (cellType == CellType.Original)
                {
                    //make a new cell at location with the pressed button as host
                    newCell = new Cell(mapButton);
                }
                else if (cellType == CellType.Zombie)
                {
                    newCell = new ZombieCell(mapButton);
                }
                
                //add a new cell to the population
                map.AddCell(newCell);
                //update neighbors of all cells currently on map
                map.UpdateAllNeighbors();
                //update window
                mainWindow.DrawTenantCell(mapButton);
                
                //update labels
                mainWindow.UpdateOriginalPopulationCountLabel(map.Population.OriginalCount);
                mainWindow.UpdateZombiePopulationCountLabel(map.Population.ZombieCount);
                UpdateStatusBoxNeighborLabels(mapButton);
                
            }
            else if (mapButton.Tenant != null)
            {
                UpdateStatusBoxNeighborLabels(mapButton);
            }
        }

        //update neighbor location label
        public void UpdateStatusBoxNeighborLabels(MapButton pressedButton)
        {
            //neighbor location label
            string locationsString = "";
            
            //if there is a Cell in the button
            if (pressedButton.Tenant != null)
            {
                //neighbor count label
                statusBox.UpdateNeighborCountLabel(pressedButton.Tenant.Neighbors.Count);
                
                //could change this to linq, but this is easier for me to read, may change later for performance
                foreach (KeyValuePair<int, ICell> neighborCell in pressedButton.Tenant.Neighbors)
                {
                    locationsString += GetLocationsString(neighborCell.Key) + ", ";
                }
                statusBox.UpdateNeighborLocationLabel(locationsString);
                statusBox.UpdateNeighborLabelTitles("Cell");
                UpdateStatusBoxAgilityLabel(pressedButton.Tenant.Agility);
            }
            else//if there is no Cell in the button
            {
                int neighborCount = 0;
                foreach (KeyValuePair<int, MapButton> neighborButton in pressedButton.Neighbors.Where(neighborButton => neighborButton.Value.Tenant != null))
                {
                    neighborCount++;
                    locationsString += GetLocationsString(neighborButton.Key) + ", ";
                }
                //update window labels
                statusBox.UpdateNeighborLabelTitles("Button");
                statusBox.UpdateNeighborLocationLabel(locationsString);
                statusBox.UpdateNeighborCountLabel(neighborCount);
            }
            
        }//end UpdateStatusBoxNeighborLabels

        //get locations string
        public string GetLocationsString(int location)
        {
            string locationString = "";

            switch (location)
            {
                case 0:
                    {
                        locationString = "North";
                        break;
                    }
                case 1:
                    {
                        locationString = "NorthEast";
                        break;
                    }
                case 2:
                    {
                        locationString = "East";
                        break;
                    }
                case 3:
                    {
                        locationString = "SouthEast";
                        break;
                    }
                case 4:
                    {
                        locationString = "South";
                        break;
                    }
                case 5:
                    {
                        locationString = "SouthWest";
                        break;
                    }
                case 6:
                    {
                        locationString = "West";
                        break;
                    }
                case 7:
                    {
                        locationString = "NorthWest";
                        break;
                    }
            }

            return locationString;
        }

        //update agility label
        public void UpdateStatusBoxAgilityLabel(int agility)
        {
            statusBox.UpdateAgilityLabel(agility);
        }

        //populate cell type strings into cell type combo box
        public void PopulateCellTypesComboBox()
        {
            //populate cell type combobox
            List<string> cellTypeStrings = new List<string>();
            foreach (CellType cellType in EnumUtil.GetValues<CellType>())
            {
                cellTypeStrings.Add(cellType.ToString());
            }

            mainWindow.PopulateCellTypeComboBox(cellTypeStrings);
        }
       
    }
}
