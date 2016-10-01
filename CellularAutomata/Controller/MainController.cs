using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata.Controller
{
    //main controller class that makes the magic happen
    class MainController
    {
        //declare views here
        private MainWindow mainWindow;

        //declare model stuff here

        public MainController()
        {
            //intialize mainWindow
            mainWindow = new MainWindow();

            //show the window
            mainWindow.ShowDialog();
        }
    }
}
