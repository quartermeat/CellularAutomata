using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CellularAutomata.Controller.Helpers;
using CellularAutomata.Model;
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
        private List<Cell> population;

        //simulation timer
        private readonly Timer timer;
        private int timerCounter;

        public MainController()
        {
            //right now model initalization needs to be done before the view, because the view uses the model

            //intialize model
            map = new Map();
            population = new List<Cell>();

            //setup timer
            timer = new Timer();
            timer.Interval = 1000; //1 sec
            timer.Tick += TimerTick;
            timerCounter = 0;

            //initialize view
            mainWindow = new MainWindow();
            mainWindow.SetupMap();

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
            //do cell tick stuff
            foreach (Cell cell in population)
            {
                //keep track of old host to draw it vacant
                MapButton oldHost = cell.HostButton;
                //move the cell
                cell.MoveToRandomVacantMapButton();
                //clear the old host button
                mainWindow.DrawTenantCell(oldHost);
                //draw new host
                mainWindow.DrawTenantCell(cell.HostButton);
            }

            //update cell's parameter

            //draw board again

        }

        //format time
        public string GetTimeString()
        {
            //create time span from our counter
            TimeSpan time = TimeSpan.FromSeconds(timerCounter);

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
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;

            var pressedButton = (MapButton)sender;

            //get the current button that was clicked

            if (mouseEventArgs != null && mouseEventArgs.Button == MouseButtons.Right)
            {
                //take cell out of population
                population.Remove(pressedButton.Tenant);
                //take cell off of space - update window
                pressedButton.Tenant = null;
                //update neighbors
                foreach (Cell cell in population)
                {
                    cell.UpdateNeighbors();
                }
                //update the window
                mainWindow.DrawTenantCell(pressedButton);
                //update labels
                mainWindow.UpdatePopulationCountLabel(population.Count);
                UpdateStatusBoxNeighborLabels(pressedButton);
            }
            else if (pressedButton.Tenant == null)//if there is not already a cell there
            {
                //make a new cell at location with the pressed button as host
                Cell newCell = new Cell(pressedButton.Location, pressedButton);
                //add a new cell to the population
                population.AddSorted(newCell);
                //add the cell to the button
                pressedButton.Tenant = newCell;
                //update neighbors
                foreach (Cell cell in population)
                {
                    cell.UpdateNeighbors();
                }
                //update window
                mainWindow.DrawTenantCell(pressedButton);
                //update labels
                mainWindow.UpdatePopulationCountLabel(population.Count);
                UpdateStatusBoxNeighborLabels(pressedButton);
                
            }
            else if (pressedButton.Tenant != null)
            {
                UpdateStatusBoxNeighborLabels(pressedButton);
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
                foreach (KeyValuePair<int, Cell> neighborCell in pressedButton.Tenant.Neighbors)
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
       
    }
}
