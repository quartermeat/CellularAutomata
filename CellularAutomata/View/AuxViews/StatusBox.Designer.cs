namespace CellularAutomata.View
{
    partial class StatusBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.neighborLocationLabel = new System.Windows.Forms.Label();
            this.selectedCellNeighborLocationLabelTitle = new System.Windows.Forms.Label();
            this.neighborCellCountLabel = new System.Windows.Forms.Label();
            this.neighborCountLableTitle = new System.Windows.Forms.Label();
            this.agilityLabelTitle = new System.Windows.Forms.Label();
            this.agilityLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // neighborLocationLabel
            // 
            this.neighborLocationLabel.AutoSize = true;
            this.neighborLocationLabel.Location = new System.Drawing.Point(200, 26);
            this.neighborLocationLabel.Name = "neighborLocationLabel";
            this.neighborLocationLabel.Size = new System.Drawing.Size(31, 13);
            this.neighborLocationLabel.TabIndex = 13;
            this.neighborLocationLabel.Text = "none";
            // 
            // selectedCellNeighborLocationLabelTitle
            // 
            this.selectedCellNeighborLocationLabelTitle.AutoSize = true;
            this.selectedCellNeighborLocationLabelTitle.Location = new System.Drawing.Point(12, 26);
            this.selectedCellNeighborLocationLabelTitle.Name = "selectedCellNeighborLocationLabelTitle";
            this.selectedCellNeighborLocationLabelTitle.Size = new System.Drawing.Size(182, 13);
            this.selectedCellNeighborLocationLabelTitle.TabIndex = 12;
            this.selectedCellNeighborLocationLabelTitle.Text = "Selected Button\'s neighbor locations:";
            // 
            // neighborCellCountLabel
            // 
            this.neighborCellCountLabel.AutoSize = true;
            this.neighborCellCountLabel.Location = new System.Drawing.Point(185, 9);
            this.neighborCellCountLabel.Name = "neighborCellCountLabel";
            this.neighborCellCountLabel.Size = new System.Drawing.Size(10, 17);
            this.neighborCellCountLabel.TabIndex = 11;
            this.neighborCellCountLabel.Text = "0";
            this.neighborCellCountLabel.UseCompatibleTextRendering = true;
            // 
            // neighborCountLableTitle
            // 
            this.neighborCountLableTitle.AutoSize = true;
            this.neighborCountLableTitle.Location = new System.Drawing.Point(12, 9);
            this.neighborCountLableTitle.Name = "neighborCountLableTitle";
            this.neighborCountLableTitle.Size = new System.Drawing.Size(167, 13);
            this.neighborCountLableTitle.TabIndex = 10;
            this.neighborCountLableTitle.Text = "Selected Button\'s neighbor count:";
            // 
            // agilityLabelTitle
            // 
            this.agilityLabelTitle.AutoSize = true;
            this.agilityLabelTitle.Location = new System.Drawing.Point(12, 48);
            this.agilityLabelTitle.Name = "agilityLabelTitle";
            this.agilityLabelTitle.Size = new System.Drawing.Size(144, 13);
            this.agilityLabelTitle.TabIndex = 14;
            this.agilityLabelTitle.Text = "Selected OriginalCell\'s Agility:";
            // 
            // agilityLabel
            // 
            this.agilityLabel.AutoSize = true;
            this.agilityLabel.Location = new System.Drawing.Point(162, 48);
            this.agilityLabel.Name = "agilityLabel";
            this.agilityLabel.Size = new System.Drawing.Size(13, 13);
            this.agilityLabel.TabIndex = 15;
            this.agilityLabel.Text = "0";
            // 
            // StatusBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 261);
            this.Controls.Add(this.agilityLabel);
            this.Controls.Add(this.agilityLabelTitle);
            this.Controls.Add(this.neighborLocationLabel);
            this.Controls.Add(this.selectedCellNeighborLocationLabelTitle);
            this.Controls.Add(this.neighborCellCountLabel);
            this.Controls.Add(this.neighborCountLableTitle);
            this.Name = "StatusBox";
            this.Text = "StatusBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label neighborLocationLabel;
        private System.Windows.Forms.Label selectedCellNeighborLocationLabelTitle;
        private System.Windows.Forms.Label neighborCellCountLabel;
        private System.Windows.Forms.Label neighborCountLableTitle;
        private System.Windows.Forms.Label agilityLabelTitle;
        private System.Windows.Forms.Label agilityLabel;
    }
}