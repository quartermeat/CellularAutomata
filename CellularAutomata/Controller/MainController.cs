using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CellularAutomata.Model;
using CellularAutomata.Model.CellTypes;
using CellularAutomata.View;

namespace CellularAutomata.Controller
{
    //main controller class that makes the magic happen
    class MainController
    {
        //declare views here
        private readonly Map _map;
        //declare model stuff here
        private readonly MainWindow _mainWindow;
        private readonly StatusBox _statusBox = new StatusBox();

        //simulation timer
        private readonly Timer _timer;
        private int _timerCounter;
        private int _ticksInHour;
        private int _hours;
        private int _days;
        private int _years;
        private int _scale;

        public MainController()
        {
            //right now model initalization needs to be done before the view, because the view uses the model

            //intialize model *this is setup this way so we can eventually load saved populations
            _map = new Map(new Population());

            //setup timer
            _timerCounter = 0;
            _ticksInHour = 120;
            _scale = 1;//the higher the number, the faster time goes by
            _hours = 0;
            _days = 0;
            _years = 0;
            _timer = new Timer();
            _timer.Interval = 1000/_scale;
            _timer.Tick += TimerTick;

            //initialize view
            _mainWindow = new MainWindow();
            _mainWindow.SetupMap();
            //setup combo box
            PopulateCellTypesComboBox();

            //set up event handling
            _mainWindow.MapButtonPressed += OnMapButtonClicked;
            _mainWindow.StartButtonPressed += OnStartButtonClicked;
            _mainWindow.ShowStatusBoxMenuItemClicked += OnShowStatusBoxMenuItemClicked;
            _mainWindow.ChangedTimerTrackBar += OnChangedTimerTrackBar;

            //show the window
            _mainWindow.ShowDialog();
        }

        //do stuff on the timer tick
        private void TimerTick(object cvsender, EventArgs e)
        {
            //timer handling
            #region timerStuff
            //update counter
            _timerCounter++;
            //get hours from timerCounter
            _hours = _timerCounter % _ticksInHour;
            //if hours gets to 24
            if (_hours == 24)
            {
                //reset timer counter
                _timerCounter = 0;
                //increment days
                _days++;
                //if days gets to 365
                if (_days == 365)
                {
                    //increment years
                    _years++;
                    //reset days
                    _days = 0;
                }
            }
            //update timer label
            string timeString = _years + "y " + _days + "d " + _hours + "h";
            _mainWindow.UpdateTimerLabels(timeString);
            #endregion
            //main game logic has to happen here
            //do cell tick stuff////////////////////////////
            _map.UpdateMap();
            ///////////////////////////////////////////////
            //update the window
            _mainWindow.DrawMap(_map);
        }

        #region timerStuff
        //handle start button clicked
        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            //if timer is going
            if (_timer.Enabled)
            {
                //stop timer
                _timer.Stop();
                //update Start button text
                _mainWindow.UpdateStartButton("Start", Color.Green);
            }
            else
            {
                //start timer
                _timer.Start();
                //update Start button text
                _mainWindow.UpdateStartButton("Stop", Color.Red);
            }
        }

        //update timer speed
        public void OnChangedTimerTrackBar(object sender, EventArgs e)
        {
            _scale = _mainWindow.GetTimerTrackBarValue();
            _timer.Interval = 1000 / _scale;
        }
        #endregion

        //handle ShowStatusBox menu item selected
        private void OnShowStatusBoxMenuItemClicked(object sender, EventArgs e)
        {
            _statusBox.Show();
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
                    _map.RemoveCell(mapButton.Tenant);
                    //update window
                    _mainWindow.DrawTenantCell(mapButton);
                }
                
                //update neighbors
                foreach (var cell in _map.Population)
                {
                    _map.UpdateNeighbors(cell);
                }
                //update labels
                _mainWindow.UpdateOriginalPopulationCountLabel(_map.Population.OriginalCount);
                _mainWindow.UpdateZombiePopulationCountLabel(_map.Population.ZombieCount);
                UpdateStatusBoxNeighborLabels(mapButton);
            }
            else if (mapButton.Tenant == null)//if there is not already a cell there
            {
                CellType cellType = _mainWindow.GetCellTypeComboxSelection();
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
                _map.AddCell(newCell);
                //update neighbors of all cells currently on map
                _map.UpdateAllNeighbors();
                //update window
                _mainWindow.DrawTenantCell(mapButton);
                
                //update labels
                _mainWindow.UpdateOriginalPopulationCountLabel(_map.Population.OriginalCount);
                _mainWindow.UpdateZombiePopulationCountLabel(_map.Population.ZombieCount);
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
                _statusBox.UpdateNeighborCountLabel(pressedButton.Tenant.Neighbors.Count);
                
                //could change this to linq, but this is easier for me to read, may change later for performance
                foreach (KeyValuePair<int, ICell> neighborCell in pressedButton.Tenant.Neighbors)
                {
                    locationsString += GetLocationsString(neighborCell.Key) + ", ";
                }
                _statusBox.UpdateNeighborLocationLabel(locationsString);
                _statusBox.UpdateNeighborLabelTitles("Cell");
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
                _statusBox.UpdateNeighborLabelTitles("Button");
                _statusBox.UpdateNeighborLocationLabel(locationsString);
                _statusBox.UpdateNeighborCountLabel(neighborCount);
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
            _statusBox.UpdateAgilityLabel(agility);
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

            _mainWindow.PopulateCellTypeComboBox(cellTypeStrings);
        }
       
    }
}
