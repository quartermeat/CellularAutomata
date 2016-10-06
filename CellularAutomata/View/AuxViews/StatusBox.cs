using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomata.View
{
    public partial class StatusBox : Form
    {
        public StatusBox()
        {
            InitializeComponent();
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

        //update neighbor label titles
        public void UpdateNeighborLabelTitles(string newText)
        {
            neighborCountLableTitle.Text = "Selected " + newText + "'s neighbor count:";
            selectedCellNeighborLocationLabelTitle.Text = "Selected " + newText + "'s neighbor locations:";
        }

        //update agility label
        public void UpdateAgilityLabel(int newAgility)
        {
            agilityLabel.Text = newAgility.ToString();
        }

        //hide the box instead of closing so it can just be reopened without creating a new one
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
