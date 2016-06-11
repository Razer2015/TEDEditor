namespace TEDEditor
{
    partial class GUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.elevation_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fLP_elevations = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_test = new System.Windows.Forms.Panel();
            this.lbl_entry_test = new System.Windows.Forms.Label();
            this.nUD_test = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayElevationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayElevationPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModifiedPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.elevation_chart)).BeginInit();
            this.fLP_elevations.SuspendLayout();
            this.panel_test.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_test)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // elevation_chart
            // 
            chartArea4.Name = "ChartArea1";
            this.elevation_chart.ChartAreas.Add(chartArea4);
            this.elevation_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.elevation_chart.Legends.Add(legend4);
            this.elevation_chart.Location = new System.Drawing.Point(230, 24);
            this.elevation_chart.Name = "elevation_chart";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series13.IsXValueIndexed = true;
            series13.Legend = "Legend1";
            series13.Name = "Elevation";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series14.Legend = "Legend1";
            series14.Name = "Elevation Points";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series15.Legend = "Legend1";
            series15.Name = "Modified";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series16.Legend = "Legend1";
            series16.Name = "Modified Points";
            this.elevation_chart.Series.Add(series13);
            this.elevation_chart.Series.Add(series14);
            this.elevation_chart.Series.Add(series15);
            this.elevation_chart.Series.Add(series16);
            this.elevation_chart.Size = new System.Drawing.Size(599, 301);
            this.elevation_chart.TabIndex = 2;
            this.elevation_chart.Text = "Elevation";
            // 
            // fLP_elevations
            // 
            this.fLP_elevations.AutoScroll = true;
            this.fLP_elevations.Controls.Add(this.panel_test);
            this.fLP_elevations.Dock = System.Windows.Forms.DockStyle.Left;
            this.fLP_elevations.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fLP_elevations.Location = new System.Drawing.Point(0, 24);
            this.fLP_elevations.Name = "fLP_elevations";
            this.fLP_elevations.Size = new System.Drawing.Size(230, 301);
            this.fLP_elevations.TabIndex = 1;
            this.fLP_elevations.WrapContents = false;
            // 
            // panel_test
            // 
            this.panel_test.Controls.Add(this.lbl_entry_test);
            this.panel_test.Controls.Add(this.nUD_test);
            this.panel_test.Location = new System.Drawing.Point(3, 3);
            this.panel_test.Name = "panel_test";
            this.panel_test.Size = new System.Drawing.Size(203, 24);
            this.panel_test.TabIndex = 1;
            // 
            // lbl_entry_test
            // 
            this.lbl_entry_test.Location = new System.Drawing.Point(1, 1);
            this.lbl_entry_test.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_entry_test.Name = "lbl_entry_test";
            this.lbl_entry_test.Size = new System.Drawing.Size(77, 20);
            this.lbl_entry_test.TabIndex = 2;
            this.lbl_entry_test.Text = "Entry: 9999";
            this.lbl_entry_test.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUD_test
            // 
            this.nUD_test.DecimalPlaces = 5;
            this.nUD_test.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_test.Location = new System.Drawing.Point(81, 2);
            this.nUD_test.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_test.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_test.Name = "nUD_test";
            this.nUD_test.Size = new System.Drawing.Size(120, 20);
            this.nUD_test.TabIndex = 3;
            this.nUD_test.Value = new decimal(new int[] {
            1558741,
            0,
            0,
            -2147221504});
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(829, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elevationToolStripMenuItem,
            this.modifiedToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // elevationToolStripMenuItem
            // 
            this.elevationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayElevationToolStripMenuItem,
            this.displayElevationPointsToolStripMenuItem});
            this.elevationToolStripMenuItem.Name = "elevationToolStripMenuItem";
            this.elevationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.elevationToolStripMenuItem.Text = "Elevation";
            // 
            // displayElevationToolStripMenuItem
            // 
            this.displayElevationToolStripMenuItem.Checked = true;
            this.displayElevationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayElevationToolStripMenuItem.Name = "displayElevationToolStripMenuItem";
            this.displayElevationToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.displayElevationToolStripMenuItem.Text = "Display Elevation";
            this.displayElevationToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // displayElevationPointsToolStripMenuItem
            // 
            this.displayElevationPointsToolStripMenuItem.Checked = true;
            this.displayElevationPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayElevationPointsToolStripMenuItem.Name = "displayElevationPointsToolStripMenuItem";
            this.displayElevationPointsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.displayElevationPointsToolStripMenuItem.Text = "Display Elevation Points";
            this.displayElevationPointsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // modifiedToolStripMenuItem
            // 
            this.modifiedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayModifiedToolStripMenuItem,
            this.displayModifiedPointsToolStripMenuItem});
            this.modifiedToolStripMenuItem.Name = "modifiedToolStripMenuItem";
            this.modifiedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modifiedToolStripMenuItem.Text = "Modified";
            // 
            // displayModifiedToolStripMenuItem
            // 
            this.displayModifiedToolStripMenuItem.Checked = true;
            this.displayModifiedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayModifiedToolStripMenuItem.Name = "displayModifiedToolStripMenuItem";
            this.displayModifiedToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.displayModifiedToolStripMenuItem.Text = "Display Modified";
            this.displayModifiedToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // displayModifiedPointsToolStripMenuItem
            // 
            this.displayModifiedPointsToolStripMenuItem.Checked = true;
            this.displayModifiedPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayModifiedPointsToolStripMenuItem.Name = "displayModifiedPointsToolStripMenuItem";
            this.displayModifiedPointsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.displayModifiedPointsToolStripMenuItem.Text = "Display Modified Points";
            this.displayModifiedPointsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 325);
            this.Controls.Add(this.elevation_chart);
            this.Controls.Add(this.fLP_elevations);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "GUI";
            ((System.ComponentModel.ISupportInitialize)(this.elevation_chart)).EndInit();
            this.fLP_elevations.ResumeLayout(false);
            this.panel_test.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_test)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart elevation_chart;
        private System.Windows.Forms.FlowLayoutPanel fLP_elevations;
        private System.Windows.Forms.Panel panel_test;
        private System.Windows.Forms.Label lbl_entry_test;
        private System.Windows.Forms.NumericUpDown nUD_test;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayElevationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayElevationPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifiedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModifiedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModifiedPointsToolStripMenuItem;
    }
}