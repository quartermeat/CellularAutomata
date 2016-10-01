using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CellularAutomata.Model;

namespace CellularAutomata.Controller
{
    //main controller class that makes the magic happen
    class MainController
    {
        //declare views here
        private Map map;
        //declare model stuff here
        private MainWindow mainWindow;
        private List<Cell> population;

        public MainController()
        {
            //right now model initalization needs to be done before the view, because the view uses the model

            //intialize model
            map = new Map();
            population = new List<Cell>();

            //initialize view
            mainWindow = new MainWindow(map);
            mainWindow.SetupMap(map);

            //set up event handling
            mainWindow.ButtonPressed += OnButtonClicked;

            //show the window
            mainWindow.ShowDialog();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;

            //get the current button that was clicked
            var pressedButton = (KeyValuePair<int, MapButton>)sender;


            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                //take cell out of population
                population.Remove(pressedButton.Value.Tenant);
                //take cell off of space - update window
                pressedButton.Value.Tenant = null;
                //update the window
                mainWindow.DrawTenantCell(pressedButton.Value);
                mainWindow.UpdatePopulationCountLabel(population.Count);

            }else if(pressedButton.Value.Tenant == null)//if there is not already a cell there
            {
                //make a new cell at location
                Cell newCell = new Cell(pressedButton.Value.Location);
                //add the button as the cell's host
                newCell.HostButton = pressedButton.Value;
                //add a new cell to the population
                population.Add(newCell);
                //add the cell to the button
                pressedButton.Value.Tenant = newCell;
                //update window
                mainWindow.DrawTenantCell(pressedButton.Value);
                mainWindow.UpdatePopulationCountLabel(population.Count);
            }
        }
    }
}
