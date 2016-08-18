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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.elevation_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fLP_elevations = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dismissToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayElevationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayElevationPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModifiedPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sINGLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bRUSHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNumericUpDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.elevation_chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // elevation_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.elevation_chart.ChartAreas.Add(chartArea2);
            this.elevation_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.elevation_chart.Legends.Add(legend2);
            this.elevation_chart.Location = new System.Drawing.Point(230, 24);
            this.elevation_chart.Name = "elevation_chart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Legend = "Legend1";
            series6.Name = "Elevation";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series7.Legend = "Legend1";
            series7.Name = "Elevation Points";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.Legend = "Legend1";
            series8.Name = "Modified";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series9.Legend = "Legend1";
            series9.Name = "Modified Points";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series10.IsVisibleInLegend = false;
            series10.Legend = "Legend1";
            series10.Name = "Selected";
            this.elevation_chart.Series.Add(series6);
            this.elevation_chart.Series.Add(series7);
            this.elevation_chart.Series.Add(series8);
            this.elevation_chart.Series.Add(series9);
            this.elevation_chart.Series.Add(series10);
            this.elevation_chart.Size = new System.Drawing.Size(694, 279);
            this.elevation_chart.TabIndex = 2;
            this.elevation_chart.Text = "Elevation";
            this.elevation_chart.Paint += new System.Windows.Forms.PaintEventHandler(this.elevation_chart_Paint);
            this.elevation_chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.elevation_chart_MouseClick);
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
            this.fLP_elevations.Size = new System.Drawing.Size(230, 279);
            this.fLP_elevations.TabIndex = 1;
            this.fLP_elevations.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.dismissToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.editorModeToolStripMenuItem,
            this.revertToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1210, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elevationToolStripMenuItem,
            this.modifiedToolStripMenuItem,
            this.generateNumericUpDownToolStripMenuItem});
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
            this.elevationToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
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
            this.modifiedToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
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
            // editorModeToolStripMenuItem
            // 
            this.editorModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sINGLEToolStripMenuItem,
            this.bRUSHToolStripMenuItem});
            this.editorModeToolStripMenuItem.Name = "editorModeToolStripMenuItem";
            this.editorModeToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.editorModeToolStripMenuItem.Text = "Editor Mode";
            // 
            // sINGLEToolStripMenuItem
            // 
            this.sINGLEToolStripMenuItem.Checked = true;
            this.sINGLEToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sINGLEToolStripMenuItem.Name = "sINGLEToolStripMenuItem";
            this.sINGLEToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.sINGLEToolStripMenuItem.Text = "SINGLE";
            this.sINGLEToolStripMenuItem.Click += new System.EventHandler(this.EditorModeToolStripMenuItem_Click);
            // 
            // bRUSHToolStripMenuItem
            // 
            this.bRUSHToolStripMenuItem.Enabled = false;
            this.bRUSHToolStripMenuItem.Name = "bRUSHToolStripMenuItem";
            this.bRUSHToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.bRUSHToolStripMenuItem.Text = "BRUSH";
            this.bRUSHToolStripMenuItem.Click += new System.EventHandler(this.EditorModeToolStripMenuItem_Click);
            // 
            // revertToolStripMenuItem
            // 
            this.revertToolStripMenuItem.Enabled = false;
            this.revertToolStripMenuItem.Name = "revertToolStripMenuItem";
            this.revertToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.revertToolStripMenuItem.Text = "Revert";
            this.revertToolStripMenuItem.Click += new System.EventHandler(this.revertToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(924, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(286, 279);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Point";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "X";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Y";
            this.columnHeader2.Width = 111;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 303);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1210, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "Idle...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // generateNumericUpDownToolStripMenuItem
            // 
            this.generateNumericUpDownToolStripMenuItem.Name = "generateNumericUpDownToolStripMenuItem";
            this.generateNumericUpDownToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.generateNumericUpDownToolStripMenuItem.Text = "Generate numericUpDown";
            this.generateNumericUpDownToolStripMenuItem.Click += new System.EventHandler(this.generateNumericUpDownToolStripMenuItem_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 325);
            this.Controls.Add(this.elevation_chart);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.fLP_elevations);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GUI_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.elevation_chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripMenuItem revertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem editorModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sINGLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bRUSHToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNumericUpDownToolStripMenuItem;
    }
}