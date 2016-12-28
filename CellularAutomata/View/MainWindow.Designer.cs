namespace CellularAutomata.View
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mapPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showStatusBoxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedLabel = new System.Windows.Forms.Label();
            this.timerTrackBarTitle = new System.Windows.Forms.Label();
            this.timerTrackBar = new System.Windows.Forms.TrackBar();
            this.zombiePopulationCountLabel = new System.Windows.Forms.Label();
            this.zombiePopulationLabelTitle = new System.Windows.Forms.Label();
            this.cellTypeComboBox = new System.Windows.Forms.ComboBox();
            this.cellTypeComboBoxTitle = new System.Windows.Forms.Label();
            this.timerHourLabel = new System.Windows.Forms.Label();
            this.originalPopulationCountLabel = new System.Windows.Forms.Label();
            this.originalPopulationCountLabelTitle = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.graphicsButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Controls.Add(this.mapPanel);
            this.mainPanel.Controls.Add(this.controlPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(479, 558);
            this.mainPanel.TabIndex = 3;
            // 
            // mapPanel
            // 
            this.mapPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapPanel.Location = new System.Drawing.Point(3, 3);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(468, 439);
            this.mapPanel.TabIndex = 0;
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlPanel.ContextMenuStrip = this.contextMenuStrip;
            this.controlPanel.Controls.Add(this.graphicsButton);
            this.controlPanel.Controls.Add(this.speedLabel);
            this.controlPanel.Controls.Add(this.timerTrackBarTitle);
            this.controlPanel.Controls.Add(this.timerTrackBar);
            this.controlPanel.Controls.Add(this.zombiePopulationCountLabel);
            this.controlPanel.Controls.Add(this.zombiePopulationLabelTitle);
            this.controlPanel.Controls.Add(this.cellTypeComboBox);
            this.controlPanel.Controls.Add(this.cellTypeComboBoxTitle);
            this.controlPanel.Controls.Add(this.timerHourLabel);
            this.controlPanel.Controls.Add(this.originalPopulationCountLabel);
            this.controlPanel.Controls.Add(this.originalPopulationCountLabelTitle);
            this.controlPanel.Controls.Add(this.startButton);
            this.controlPanel.Location = new System.Drawing.Point(3, 448);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(468, 103);
            this.controlPanel.TabIndex = 2;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStatusBoxMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 26);
            // 
            // showStatusBoxMenuItem
            // 
            this.showStatusBoxMenuItem.Name = "showStatusBoxMenuItem";
            this.showStatusBoxMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showStatusBoxMenuItem.Text = "Show Status Box";
            this.showStatusBoxMenuItem.Click += new System.EventHandler(this.showStatusBoxMenuItem_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(344, 81);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(13, 13);
            this.speedLabel.TabIndex = 11;
            this.speedLabel.Text = "1";
            // 
            // timerTrackBarTitle
            // 
            this.timerTrackBarTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timerTrackBarTitle.AutoSize = true;
            this.timerTrackBarTitle.Location = new System.Drawing.Point(297, 81);
            this.timerTrackBarTitle.Name = "timerTrackBarTitle";
            this.timerTrackBarTitle.Size = new System.Drawing.Size(41, 13);
            this.timerTrackBarTitle.TabIndex = 10;
            this.timerTrackBarTitle.Text = "Speed:";
            // 
            // timerTrackBar
            // 
            this.timerTrackBar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timerTrackBar.LargeChange = 2;
            this.timerTrackBar.Location = new System.Drawing.Point(289, 42);
            this.timerTrackBar.Maximum = 8;
            this.timerTrackBar.Minimum = 1;
            this.timerTrackBar.Name = "timerTrackBar";
            this.timerTrackBar.Size = new System.Drawing.Size(79, 45);
            this.timerTrackBar.TabIndex = 8;
            this.timerTrackBar.TabStop = false;
            this.timerTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.timerTrackBar.Value = 1;
            this.timerTrackBar.Scroll += new System.EventHandler(this.timerTrackBar_Scroll);
            // 
            // zombiePopulationCountLabel
            // 
            this.zombiePopulationCountLabel.AutoSize = true;
            this.zombiePopulationCountLabel.Location = new System.Drawing.Point(138, 16);
            this.zombiePopulationCountLabel.Name = "zombiePopulationCountLabel";
            this.zombiePopulationCountLabel.Size = new System.Drawing.Size(13, 13);
            this.zombiePopulationCountLabel.TabIndex = 9;
            this.zombiePopulationCountLabel.Text = "0";
            // 
            // zombiePopulationLabelTitle
            // 
            this.zombiePopulationLabelTitle.AutoSize = true;
            this.zombiePopulationLabelTitle.Location = new System.Drawing.Point(3, 16);
            this.zombiePopulationLabelTitle.Name = "zombiePopulationLabelTitle";
            this.zombiePopulationLabelTitle.Size = new System.Drawing.Size(129, 13);
            this.zombiePopulationLabelTitle.TabIndex = 8;
            this.zombiePopulationLabelTitle.Text = "Zombie Population Count:";
            // 
            // cellTypeComboBox
            // 
            this.cellTypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cellTypeComboBox.FormattingEnabled = true;
            this.cellTypeComboBox.Location = new System.Drawing.Point(63, 42);
            this.cellTypeComboBox.Name = "cellTypeComboBox";
            this.cellTypeComboBox.Size = new System.Drawing.Size(84, 21);
            this.cellTypeComboBox.TabIndex = 7;
            // 
            // cellTypeComboBoxTitle
            // 
            this.cellTypeComboBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cellTypeComboBoxTitle.AutoSize = true;
            this.cellTypeComboBoxTitle.Location = new System.Drawing.Point(3, 45);
            this.cellTypeComboBoxTitle.Name = "cellTypeComboBoxTitle";
            this.cellTypeComboBoxTitle.Size = new System.Drawing.Size(54, 13);
            this.cellTypeComboBoxTitle.TabIndex = 6;
            this.cellTypeComboBoxTitle.Text = "Cell Type:";
            // 
            // timerHourLabel
            // 
            this.timerHourLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timerHourLabel.AutoSize = true;
            this.timerHourLabel.Location = new System.Drawing.Point(309, 26);
            this.timerHourLabel.Name = "timerHourLabel";
            this.timerHourLabel.Size = new System.Drawing.Size(48, 13);
            this.timerHourLabel.TabIndex = 5;
            this.timerHourLabel.Text = "0y 0d 0h";
            // 
            // originalPopulationCountLabel
            // 
            this.originalPopulationCountLabel.AutoSize = true;
            this.originalPopulationCountLabel.Location = new System.Drawing.Point(138, 3);
            this.originalPopulationCountLabel.Name = "originalPopulationCountLabel";
            this.originalPopulationCountLabel.Size = new System.Drawing.Size(13, 13);
            this.originalPopulationCountLabel.TabIndex = 3;
            this.originalPopulationCountLabel.Text = "0";
            // 
            // originalPopulationCountLabelTitle
            // 
            this.originalPopulationCountLabelTitle.AutoSize = true;
            this.originalPopulationCountLabelTitle.Location = new System.Drawing.Point(3, 3);
            this.originalPopulationCountLabelTitle.Name = "originalPopulationCountLabelTitle";
            this.originalPopulationCountLabelTitle.Size = new System.Drawing.Size(129, 13);
            this.originalPopulationCountLabelTitle.TabIndex = 2;
            this.originalPopulationCountLabelTitle.Text = "Original Population Count:";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(374, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(91, 97);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // graphicsButton
            // 
            this.graphicsButton.Location = new System.Drawing.Point(6, 77);
            this.graphicsButton.Name = "graphicsButton";
            this.graphicsButton.Size = new System.Drawing.Size(104, 23);
            this.graphicsButton.TabIndex = 12;
            this.graphicsButton.Text = "Go To Graphics";
            this.graphicsButton.UseVisualStyleBackColor = true;
            this.graphicsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(479, 558);
            this.Controls.Add(this.mainPanel);
            this.Name = "MainWindow";
            this.Text = "Cellular Automata";
            this.mainPanel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel mapPanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label originalPopulationCountLabel;
        private System.Windows.Forms.Label originalPopulationCountLabelTitle;
        private System.Windows.Forms.Label timerHourLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showStatusBoxMenuItem;
        private System.Windows.Forms.ComboBox cellTypeComboBox;
        private System.Windows.Forms.Label cellTypeComboBoxTitle;
        private System.Windows.Forms.Label zombiePopulationCountLabel;
        private System.Windows.Forms.Label zombiePopulationLabelTitle;
        private System.Windows.Forms.Label timerTrackBarTitle;
        private System.Windows.Forms.TrackBar timerTrackBar;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button graphicsButton;
    }
}

