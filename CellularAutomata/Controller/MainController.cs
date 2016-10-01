using System;
using System.Windows.Forms;
using CellularAutomata.Model;

namespace CellularAutomata.Controller
{
    //main controller class that makes the magic happen
    class MainController
    {
        //declare views here
        private MainWindow mainWindow;

        //declare model stuff here
        private Map map;

        public MainController()
        {
            //right now model initalization needs to be done before the view, because the view uses the model

            //intialize model
            map = new Map();

            //initialize view
            mainWindow = new MainWindow(map);
            //mainWindow.SetupBoard(map);

            //set up event handling
            mainWindow.ButtonPressed += OnButtonClicked;

            //show the window
            mainWindow.ShowDialog();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("you've clicked here");
        }
    }
}
