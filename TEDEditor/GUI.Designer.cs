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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.elevation_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fLP_elevations = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayElevationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayElevationPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModifiedPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dismissToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.elevation_chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // elevation_chart
            // 
            chartArea5.Name = "ChartArea1";
            this.elevation_chart.ChartAreas.Add(chartArea5);
            this.elevation_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.elevation_chart.Legends.Add(legend5);
            this.elevation_chart.Location = new System.Drawing.Point(230, 24);
            this.elevation_chart.Name = "elevation_chart";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series17.Legend = "Legend1";
            series17.Name = "Elevation";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series18.Legend = "Legend1";
            series18.Name = "Elevation Points";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series19.Legend = "Legend1";
            series19.Name = "Modified";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series20.Legend = "Legend1";
            series20.Name = "Modified Points";
            this.elevation_chart.Series.Add(series17);
            this.elevation_chart.Series.Add(series18);
            this.elevation_chart.Series.Add(series19);
            this.elevation_chart.Series.Add(series20);
            this.elevation_chart.Size = new System.Drawing.Size(599, 301);
            this.elevation_chart.TabIndex = 2;
            this.elevation_chart.Text = "Elevation";
            this.elevation_chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.elevation_chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.elevation_chart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_MouseUp);
            // 
            // fLP_elevations
            // 
            this.fLP_elevations.AutoScroll = true;
            this.fLP_elevations.Dock = System.Windows.Forms.DockStyle.Left;
            this.fLP_elevations.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fLP_elevations.Location = new System.Drawing.Point(0, 24);
            this.fLP_elevations.Name = "fLP_elevations";
            this.fLP_elevations.Size = new System.Drawing.Size(230, 301);
            this.fLP_elevations.TabIndex = 1;
            this.fLP_elevations.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.dismissToolStripMenuItem,
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
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.displayToolStripMenuItem.Text = "Display Settings";
            // 
            // elevationToolStripMenuItem
            // 
            this.elevationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayElevationToolStripMenuItem,
            this.displayElevationPointsToolStripMenuItem});
            this.elevationToolStripMenuItem.Name = "elevationToolStripMenuItem";
            this.elevationToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
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
            this.modifiedToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
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
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // dismissToolStripMenuItem
            // 
            this.dismissToolStripMenuItem.Name = "dismissToolStripMenuItem";
            this.dismissToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.dismissToolStripMenuItem.Text = "Dismiss";
            this.dismissToolStripMenuItem.Click += new System.EventHandler(this.dismissToolStripMenuItem_Click);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart elevation_chart;
        private System.Windows.Forms.FlowLayoutPanel fLP_elevations;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayElevationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayElevationPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifiedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModifiedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModifiedPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dismissToolStripMenuItem;
    }
}