namespace CellularAutomata.Controller
{
    //main controller class that makes the magic happen
    class MainController
    {
        //declare views here
        private MainWindow mainWindow;

        //declare model stuff here
        //private Cell myCell;

        public MainController()
        {
            //initialize view
            mainWindow = new MainWindow();

            //intialize model

            //show the window
            mainWindow.ShowDialog();
        }
    }
}
