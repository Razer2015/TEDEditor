using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TEDEditor
{
    public partial class GUI : Form
    {
        public enum EditType
        {
            SINGLE,
            BRUSH
        }

        Editor editor;

        // RETURNS
        public DialogResult Result { get; set; }
        public Vertex[] Field1 { get; set; }
        public String SavePath { get; set; }

        // 
        String elevation_name = "";
        String elevation_point_name = "";
        String modified_name = "";
        String modified_point_name = "";

        public Vertex[] orig_heights;
        public Vertex[] mod_heights;

        private EditType editType = EditType.SINGLE;

        // Brush Mode
        private int x = 0;
        private int y = 0;

        // Revert and Redo
        private History prevHistory;
        private List<History> revert = new List<History>();
        private List<History> redo = new List<History>();

        // Used for NumericUpDown
        private bool Loaded = false;

        // Used for zooming event
        private int zoom_depth = 0;

        //used for mouse over chart events
        private bool isDraggingPoint = false;
        private int draggedPointIndex = -1;
        private bool isDraggingBrush = false;

        //Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public GUI()
        {
            InitializeComponent();
        }

        public GUI(Vertex[] heights)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.elevation_chart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            //this.elevation_chart.ChartAreas[0].AxisX.Interval = 1;

            this.elevation_chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            this.elevation_chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            // set selection color to transparent so that range selection is not drawn
            this.elevation_chart.ChartAreas[0].CursorX.LineColor = System.Drawing.Color.Transparent;
            //this.elevation_chart.ChartAreas[0].CursorX.SelectionColor = System.Drawing.Color.Transparent;

            elevation_name = this.elevation_chart.Series[0].Name;
            elevation_point_name = this.elevation_chart.Series[1].Name;
            modified_name = this.elevation_chart.Series[2].Name;
            modified_point_name = this.elevation_chart.Series[3].Name;

            elevation_chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            elevation_chart.MouseWheel += new System.Windows.Forms.MouseEventHandler(chData_MouseWheel);
            //elevation_chart.AlignDataPointsByAxisLabel();

            this.orig_heights = DeepCopy<Vertex[]>(heights);
            this.mod_heights = DeepCopy<Vertex[]>(heights);

            fLP_elevation(this.orig_heights);
            Populate_ListView(this.orig_heights);
            Visualize(this.orig_heights);
            Visualize_mod(this.mod_heights);
        }

        #region ToolStripMenuItems

        #region File
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Result = DialogResult.OK;
            Field1 = this.mod_heights;
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "GT6TED File | *.ted";
            dialog.DefaultExt = "ted";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                SavePath = dialog.FileName;
                Result = DialogResult.OK;
                Field1 = this.mod_heights;
                this.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            Field1 = this.orig_heights;
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Edit
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Revert();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Redo();
        }
        #endregion

        #region View
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = (ToolStripMenuItem)sender;
            TSMI.Checked = !TSMI.Checked;

            elevation_chart.Series[elevation_name].Enabled = displayElevationToolStripMenuItem.Checked;
            elevation_chart.Series[elevation_point_name].Enabled = displayElevationPointsToolStripMenuItem.Checked;
            elevation_chart.Series[modified_name].Enabled = displayModifiedToolStripMenuItem.Checked;
            elevation_chart.Series[modified_point_name].Enabled = displayModifiedPointsToolStripMenuItem.Checked;
        }

        private void generateNumericUpDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateNumericUpDownToolStripMenuItem.Checked = !generateNumericUpDownToolStripMenuItem.Checked;
        }
        #endregion

        #region EditorMode
        private void EditorModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = (ToolStripMenuItem)sender;

            // RESET
            sINGLEToolStripMenuItem.Checked = false;
            bRUSHToolStripMenuItem.Checked = false;

            // SET
            if (TSMI == sINGLEToolStripMenuItem)
                sINGLEToolStripMenuItem.Checked = true;
            else if (TSMI == bRUSHToolStripMenuItem)
                bRUSHToolStripMenuItem.Checked = true;

            if (sINGLEToolStripMenuItem.Checked)
            {
                this.elevation_chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                this.elevation_chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                editType = EditType.SINGLE;
            }
            else if (bRUSHToolStripMenuItem.Checked)
            {
                this.elevation_chart.ChartAreas[0].CursorX.IsUserEnabled = false;
                this.elevation_chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
                editType = EditType.BRUSH;
            }
        } 
        #endregion

        #endregion

        private void Populate_ListView(Vertex[] heights)
        {
            for (int i = 0; i < heights.Length; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(heights[i].Y.ToString());
                item.SubItems.Add(heights[i].Z.ToString());
                listView1.Items.Add(item);
            }
                

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void nUD_ValueChanged(object sender, EventArgs e)
        {
            int entry = Convert.ToInt32(((NumericUpDown)sender).Name.Remove(0, 4));
            revert.Add(new History() { Index = entry, X = this.mod_heights[entry].Y, Y = this.mod_heights[entry].Z });
            if (redo.Count > 0)
                redo = new List<History>();

            CheckHistoryStatus();

            this.mod_heights[entry].Z = Convert.ToDouble(((NumericUpDown)sender).Value);

            this.elevation_chart.Series[2].Points[entry].YValues[0] = this.mod_heights[entry].Z;
            this.elevation_chart.Series[3].Points[entry].YValues[0] = this.mod_heights[entry].Z;

            // reset all data point attributes
            foreach (DataPoint point in this.elevation_chart.Series[3].Points)
            {
                this.dataPointResetAppearance(point);
            }
            foreach (DataPoint point in this.elevation_chart.Series[2].Points)
            {
                this.dataPointResetAppearance(point);
            }
        }

        private void fLP_elevation(Vertex[] heights)
        {
            // Clear the control first
            this.fLP_elevations.Controls.Clear();

            if (heights.Length > 1000)
            {
                Loaded = false;
                return;
            }

            // Make new control
            for (int i = 0; i < heights.Length; i++)
            {
                System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                System.Windows.Forms.Label lbl_entry = new System.Windows.Forms.Label();
                System.Windows.Forms.NumericUpDown nUD = new System.Windows.Forms.NumericUpDown();

                panel.Controls.Add(lbl_entry);
                panel.Controls.Add(nUD);
                panel.Location = new System.Drawing.Point(3, 3);
                panel.Name = "panel_" + i;
                panel.Size = new System.Drawing.Size(203, 24);
                panel.TabIndex = 1;

                lbl_entry.Location = new System.Drawing.Point(1, 1);
                lbl_entry.Margin = new System.Windows.Forms.Padding(0);
                lbl_entry.Name = "lbl_entry_" + i;
                lbl_entry.Size = new System.Drawing.Size(77, 20);
                lbl_entry.TabIndex = 2;
                lbl_entry.Text = "Entry: " + i;
                lbl_entry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                nUD.Location = new System.Drawing.Point(81, 2);
                nUD.Name = "nUD_" + i;
                nUD.Size = new System.Drawing.Size(120, 20);
                nUD.Increment = (decimal)0.01;
                nUD.DecimalPlaces = 5;
                nUD.Maximum = 10000;
                nUD.Minimum = -10000;
                nUD.Value = (decimal)heights[i].Z;
                nUD.ValueChanged += new System.EventHandler(nUD_ValueChanged);
                nUD.TabIndex = 3;

                this.fLP_elevations.Controls.Add(panel);
            }

            Loaded = true;
        }

        /// <summary>
        /// Get the maximum and minimum height values
        /// double[0] = Maximum X
        /// double[1] = Maximum Y
        /// double[2] = Minimum X
        /// double[3] = Minimum Y
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        private double[] getMinMax(Vertex[] heights)
        {
            double[] minMax = new double[4];
            for (int i = 0; i < heights.Length; i++)
            {
                if (i == 0 || heights[i].Y > minMax[0])
                    minMax[0] = heights[i].Y;
                if (i == 0 || heights[i].Z > minMax[1])
                    minMax[1] = heights[i].Z;
                if (i == 0 || heights[i].Y < minMax[2])
                    minMax[2] = heights[i].Y;
                if (i == 0 || heights[i].Z < minMax[3])
                    minMax[3] = heights[i].Z;
            }
            return (minMax);
        }

        public void Visualize(Vertex[] heights)
        {
            // Clear
            elevation_chart.Series[elevation_name].Points.Clear();
            elevation_chart.Series[elevation_point_name].Points.Clear();

            // Set Max and Min
            //double[] MinMax = getMinMax(heights);
            //elevation_chart.ChartAreas[0].AxisX.Maximum = heights.Max(y => y.Y);
            //elevation_chart.ChartAreas[0].AxisX.Minimum = heights.Min(y => y.Y);

            // Populate
            for (int i = 0; i < heights.Length; i++)
            {
                elevation_chart.Series[elevation_name].Points.AddXY(heights[i].Y, heights[i].Z);
                elevation_chart.Series[elevation_point_name].Points.AddXY(heights[i].Y, heights[i].Z);

                //elevation_chart.Series[elevation_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
                //elevation_chart.Series[elevation_point_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
            }
            elevation_chart.Series[elevation_name].ChartType = SeriesChartType.FastLine;
            elevation_chart.Series[elevation_name].Color = Color.Blue;

            elevation_chart.Series[elevation_point_name].ChartType = SeriesChartType.FastPoint;
            elevation_chart.Series[elevation_point_name].Color = Color.DarkBlue;

            elevation_chart.Series[elevation_name].Enabled = displayElevationToolStripMenuItem.Checked;
            elevation_chart.Series[elevation_point_name].Enabled = displayElevationPointsToolStripMenuItem.Checked;
        }

        public void Visualize_mod(Vertex[] heights)
        {
            // Clear
            elevation_chart.Series[modified_name].Points.Clear();
            elevation_chart.Series[modified_point_name].Points.Clear();

            // Populate
            for (int i = 0; i < heights.Length; i++)
            {
                elevation_chart.Series[modified_name].Points.AddXY(heights[i].Y, heights[i].Z);
                elevation_chart.Series[modified_point_name].Points.AddXY(heights[i].Y, heights[i].Z);

                //elevation_chart.Series[modified_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
                //elevation_chart.Series[modified_point_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
            }
            elevation_chart.Series[modified_name].ChartType = SeriesChartType.FastLine;
            elevation_chart.Series[modified_name].Color = Color.Red;

            elevation_chart.Series[modified_point_name].ChartType = SeriesChartType.FastPoint;
            elevation_chart.Series[modified_point_name].Color = Color.DarkRed;

            elevation_chart.Series[modified_name].Enabled = displayModifiedToolStripMenuItem.Checked;
            elevation_chart.Series[modified_point_name].Enabled = displayModifiedPointsToolStripMenuItem.Checked;
        }

        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    zoom_depth--;
                    if(zoom_depth < 1)
                    {
                        elevation_chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                        elevation_chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                        zoom_depth = 0;
                    }
                    else
                    {
                        double xMin = elevation_chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                        double xMax = elevation_chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                        double yMin = elevation_chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                        double yMax = elevation_chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                        double posXStart = elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) * 4;
                        double posXFinish = elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) * 4;
                        double posYStart = elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) * 4;
                        double posYFinish = elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) * 4;

                        elevation_chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                        elevation_chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                    }
                }

                if (e.Delta > 0)
                {
                    zoom_depth++;

                    double xMin = elevation_chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = elevation_chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = elevation_chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = elevation_chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    double posYStart = elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    elevation_chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    elevation_chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        public static T DeepCopy<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }

        #region REVERT & REDO

        private void CheckHistoryStatus()
        {
            if (revert.Count > 0)
                undoToolStripMenuItem.Enabled = true;
            else
                undoToolStripMenuItem.Enabled = false;

            if (redo.Count > 0)
                redoToolStripMenuItem1.Enabled = true;
            else
                redoToolStripMenuItem1.Enabled = false;
        }

        private void Revert()
        {
            if (revert.Count > 0)
            {
                Double value = revert[revert.Count - 1].Y;
                int Index = revert[revert.Count - 1].Index;

                redo.Add(new History()
                {
                    Index = Index,
                    X = this.elevation_chart.Series[3].Points[Index].XValue,
                    Y = this.elevation_chart.Series[3].Points[Index].YValues[0]
                });

                this.elevation_chart.Series[2].Points[Index].YValues[0] = value;
                this.elevation_chart.Series[3].Points[Index].YValues[0] = value;
                listView1.Items[Index].SubItems[2].Text = value.ToString();
                if (Loaded)
                {
                    Panel PANEL = (Panel)fLP_elevations.Controls["panel_" + this.draggedPointIndex];
                    if (PANEL != null)
                    {
                        NumericUpDown NUD = (NumericUpDown)PANEL.Controls["nUD_" + this.draggedPointIndex];
                        if (NUD != null)
                        {
                            NUD.ValueChanged -= new System.EventHandler(nUD_ValueChanged);
                            NUD.Value = (decimal)value;
                            NUD.ValueChanged += new System.EventHandler(nUD_ValueChanged);
                        }
                    }
                }

                revert.RemoveAt(revert.Count - 1);

                // reset all data point attributes
                foreach (DataPoint point in this.elevation_chart.Series[3].Points)
                {
                    this.dataPointResetAppearance(point);
                }
                foreach (DataPoint point in this.elevation_chart.Series[2].Points)
                {
                    this.dataPointResetAppearance(point);
                }
            }

            CheckHistoryStatus();
        }

        private void Redo()
        {
            if (redo.Count > 0)
            {
                Double value = redo[redo.Count - 1].Y;
                int Index = redo[redo.Count - 1].Index;

                revert.Add(new History()
                {
                    Index = Index,
                    X = this.elevation_chart.Series[3].Points[Index].XValue,
                    Y = this.elevation_chart.Series[3].Points[Index].YValues[0]
                });

                this.elevation_chart.Series[2].Points[Index].YValues[0] = value;
                this.elevation_chart.Series[3].Points[Index].YValues[0] = value;
                listView1.Items[Index].SubItems[2].Text = value.ToString();
                if (Loaded)
                {
                    Panel PANEL = (Panel)fLP_elevations.Controls["panel_" + this.draggedPointIndex];
                    if (PANEL != null)
                    {
                        NumericUpDown NUD = (NumericUpDown)PANEL.Controls["nUD_" + this.draggedPointIndex];
                        if (NUD != null)
                        {
                            NUD.ValueChanged -= new System.EventHandler(nUD_ValueChanged);
                            NUD.Value = (decimal)value;
                            NUD.ValueChanged += new System.EventHandler(nUD_ValueChanged);
                        }
                    }
                }

                redo.RemoveAt(redo.Count - 1);

                // reset all data point attributes
                foreach (DataPoint point in this.elevation_chart.Series[3].Points)
                {
                    this.dataPointResetAppearance(point);
                }
                foreach (DataPoint point in this.elevation_chart.Series[2].Points)
                {
                    this.dataPointResetAppearance(point);
                }
            }

            CheckHistoryStatus();
        }

        private void GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (revert.Count > 0)
                    Revert();
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                if (redo.Count > 0)
                    Redo();
            }
        }

        #endregion

        /////////////////////////////////////

        #region chart mouse event handling

        private void elevation_chart_MouseClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Mouse: {0} | {1}",
        this.elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X),
        this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));

            Console.WriteLine("Heights: {0} | {1}",
    this.mod_heights[1].Y,
    this.mod_heights[1].Z); 
#endif

            HitTestResult result = this.elevation_chart.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint && result.Series == this.elevation_chart.Series[modified_point_name])
            {
                // A point is selected.
#if DEBUG
                Console.WriteLine("Selected Point: {0}", result.PointIndex); 
#endif
                toolStripStatusLabel1.Text = String.Format("Selected Point: {0} | X: {1} | Y: {2}",
                    result.PointIndex,
                    this.elevation_chart.Series[3].Points[result.PointIndex].XValue,
                    this.elevation_chart.Series[3].Points[result.PointIndex].YValues[0]);

                // Select in a listView
                if (Control.ModifierKeys == Keys.Shift)
                {
                    if (listView1.SelectedItems.Count < 1)
                    {
                        this.listView1.SelectedItems.Clear();
                        this.listView1.Items[result.PointIndex].Selected = true;
                    }
                    else
                    {
                        int highestIndex = this.listView1.SelectedItems[this.listView1.SelectedItems.Count - 1].Index;
                        int lowestIndex = result.PointIndex;
                        if (lowestIndex > highestIndex)
                            highestIndex = highestIndex.Swap(ref lowestIndex);
                        for(int i = lowestIndex; i < (highestIndex + 1);i++)
                            this.listView1.Items[i].Selected = true;
                    }
                }
                else
                {
                    this.listView1.SelectedItems.Clear();
                    this.listView1.Items[result.PointIndex].Selected = true;
                }
                this.listView1.Select();
                this.listView1.TopItem = this.listView1.SelectedItems[0];
            }
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if(editType == EditType.SINGLE)
            {
                //call HitTest
                HitTestResult result = this.elevation_chart.HitTest(e.X, e.Y);

                //// reset all data point attributes
                //foreach (DataPoint point in this.elevation_chart.Series[3].Points)
                //{
                //    this.dataPointResetAppearance(point);
                //}
                //foreach (DataPoint point in this.elevation_chart.Series[2].Points)
                //{
                //    this.dataPointResetAppearance(point);
                //}

                ////if mouse is over a data point
                //if (result.ChartElementType == ChartElementType.DataPoint)
                //{
                //    //find mouse-over data point
                //    DataPoint point = this.elevation_chart.Series[3].Points[result.PointIndex];

                //    //change appearance of that data point 
                //    this.dataPointSetMouseOverAppearance(point);
                //}

                //additionally, if mouse is dragging a data point
                if (this.isDraggingPoint)
                {
                    //change appearance of the graph
                    this.elevation_chart.Series[2].Color = Color.BlueViolet;
                    //change appearance of the graph
                    this.elevation_chart.Series[3].Color = Color.DarkViolet;

                    //change mouse position values to Y values
                    this.elevation_chart.Series[2].Points[this.draggedPointIndex].YValues[0] = this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                    //change mouse position values to Y values
                    this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0] = this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                    //change numericupdown Y
                    double value = this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0];
                    if (Loaded)
                    {
                        Panel PANEL = (Panel)fLP_elevations.Controls["panel_" + this.draggedPointIndex];
                        if (PANEL != null)
                        {
                            NumericUpDown NUD = (NumericUpDown)PANEL.Controls["nUD_" + this.draggedPointIndex];
                            if (NUD != null)
                                NUD.Value = (decimal)value;
                        }
                    }

                    //update the values for the table to display
                    this.mod_heights[this.draggedPointIndex].Z = value;

                    tooltip.Show(String.Format("X: {0}\nY: {1}", this.elevation_chart.Series[3].Points[this.draggedPointIndex].XValue, (decimal)value),
                        this.elevation_chart, e.Location.X, e.Location.Y - 30);
                }
            }
            else if (editType == EditType.BRUSH)
            {
                x = e.X;
                y = e.Y;

                elevation_chart.Invalidate();

                if (isDraggingBrush)
                {
                    // Check if point is inside circle
                    for(int i = 0; i < this.mod_heights.Length; i++)
                    {
                        //if (ContainsPoint(this.elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X), 
                        //    this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y),
                        //    this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(0) - this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(25), 
                        //    this.mod_heights[i].Y,
                        //    this.mod_heights[i].Z))
                        //    Console.WriteLine("Contains Point");

                        double radius = (GetAxisValuesFromMouse(x + 25, y + 25)[0] - GetAxisValuesFromMouse(x, y)[0]);
                        //Console.WriteLine("{0} | {1}",
                        //    this.elevation_chart.ChartAreas[0].AxisX.ValueToPixelPosition(this.mod_heights[i].Y),
                        //    this.elevation_chart.ChartAreas[0].AxisY.ValueToPixelPosition(this.mod_heights[i].Z));

                        //this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y) - this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y + 26)

                        //if (ContainsPoint(
                        //    i + 1,
                        //    this.mod_heights[i].Z,
                        //    this.elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X + 25) - this.elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X),
                        //    this.elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X),
                        //    this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y)))
                        //{
                        //    Console.Clear();
                        //    Console.WriteLine("Contains Point");
                        //}

                        if (IsWithinCircle(
                            i + 1,
                            this.mod_heights[i].Z,
                            this.elevation_chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X),
                            this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y),
                            this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y) - this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y + 25)))
                        {
                            Console.Clear();
                            Console.WriteLine("Contains Point");
                        }
                    }

                    //int[] X = new int[] { x + 25, x - 25, x, x };    // RIGHT, LEFT, BOTTOM, TOP
                    //int[] Y = new int[] { y, y, y + 25, y - 25 };    // RIGHT, LEFT, BOTTOM, TOP

                    //for (int i = 0; i < X.Length; i++)
                    //{
                    //    HitTestResult result = this.elevation_chart.HitTest(X[i], Y[i]);
                    //    if (result.ChartElementType == ChartElementType.DataPoint && result.Series == this.elevation_chart.Series[3])
                    //    {
                    //        Console.WriteLine("Hit Detected: {0}", (i == 0) ? "RIGHT" : (i == 1) ? "LEFT" : (i == 2) ? "BOTTOM" : (i == 3) ? "TOP" : "UNKNOWN");
                    //    }
                    //}

                    //HitTestResult result = this.elevation_chart.HitTest(e.X, e.Y);
                    //if (result.ChartElementType == ChartElementType.DataPoint)
                    //{
                    //    Console.WriteLine("Hit Detected");
                    //}
                }
            }
        }

        private double[] GetAxisValuesFromMouse(int x, int y)
        {
            var chartArea = this.elevation_chart.ChartAreas[0];
            var xValue = chartArea.AxisX.PixelPositionToValue(x);
            var yValue = chartArea.AxisY.PixelPositionToValue(y);
            return new double[] { xValue, yValue };
        }

        bool IsWithinCircle(double centerX, double centerY, double mouseX, double mouseY, double radius)
        {
            double diffX = centerX - mouseX;
            double diffY = centerY - mouseY;
            return (diffX * diffX + diffY * diffY) <= radius * radius;
        }

        public bool ContainsPoint(double x_center, double y_center, double radius, double x_test, double y_test)
        {
            // Is the point inside the circle? Sum the squares of the x - difference and
            // y-difference from the centre, square-root it, and compare with the radius.
            // (This is Pythagoras' theorem.)

            double dX = Math.Abs(x_test - x_center);
            double dY = Math.Abs(y_test - y_center);

            double sumOfSquares = dX * dX + dY * dY;

            double distance = Math.Sqrt(sumOfSquares);

            return (radius >= distance);
        }

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
                return;
            if (editType == EditType.SINGLE)
            {
                HitTestResult result = this.elevation_chart.HitTest(e.X, e.Y);

                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    this.elevation_chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;

                    // store the index of the point being dragged
                    this.draggedPointIndex = result.PointIndex;
                    this.isDraggingPoint = true;

                    prevHistory = new History() { Index = this.draggedPointIndex, X = this.elevation_chart.Series[3].Points[this.draggedPointIndex].XValue, Y = this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0] };

                    if (Loaded)
                    {
                        Panel PANEL = (Panel)fLP_elevations.Controls["panel_" + this.draggedPointIndex];
                        if(PANEL != null)
                        {
                            NumericUpDown NUD = (NumericUpDown)PANEL.Controls["nUD_" + this.draggedPointIndex];
                            if (NUD != null)
                                NUD.ValueChanged -= new System.EventHandler(nUD_ValueChanged);
                        }
                    }
                        
                }
            }
            else if (editType == EditType.BRUSH)
            {
                this.isDraggingBrush = true;
            }
        }

        private void chart_MouseUp(object sender, MouseEventArgs e)
        {
            if (editType == EditType.SINGLE)
            {
                if (draggedPointIndex != -1)
                {
                    if (Loaded)
                    {
                        Panel PANEL = (Panel)fLP_elevations.Controls["panel_" + this.draggedPointIndex];
                        if (PANEL != null)
                        {
                            NumericUpDown NUD = (NumericUpDown)PANEL.Controls["nUD_" + this.draggedPointIndex];
                            if (NUD != null)
                                NUD.ValueChanged += new System.EventHandler(nUD_ValueChanged);
                        }
                    }

                    listView1.Items[this.draggedPointIndex].SubItems[2].Text = this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0].ToString();

                    History newHistory = new History() { Index = this.draggedPointIndex, X = this.elevation_chart.Series[3].Points[this.draggedPointIndex].XValue, Y = this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0] };
                    if (!prevHistory.Equals(newHistory))
                    {
                        revert.Add(prevHistory);
                        if (redo.Count > 0)
                            redo = new List<History>();
                    }

                    tooltip.Hide(this.elevation_chart);

                    CheckHistoryStatus();

                    this.elevation_chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                }

                this.draggedPointIndex = -1;
                this.isDraggingPoint = false;

                //set appearance of graph back to normal
                this.elevation_chart.Series[2].Color = Color.Red;
                this.elevation_chart.Series[3].Color = Color.DarkRed;
            }
            else if (editType == EditType.BRUSH)
            {
                this.isDraggingBrush = false;
            }
        }

        private void dataPointResetAppearance(DataPoint point)
        {
            point.MarkerColor = Color.Brown;
            point.MarkerSize = 5;
        }

        private void dataPointSetMouseOverAppearance(DataPoint point)
        {
            point.MarkerColor = Color.Red;
            point.MarkerSize = 10;
        }

        #endregion

        private void GUI_Load(object sender, EventArgs e)
        {
            // To support calling ShowDialog from test method...
            this.Visible = true;
        }

        private void elevation_chart_Paint(object sender, PaintEventArgs e)
        {
            if (editType == EditType.BRUSH)
            {
                Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);
                e.Graphics.DrawEllipse(skyBluePen, x - 25, y - 25, 50, 50);
                //e.Graphics.DrawEllipse(skyBluePen, x - 150, y - 150, 300, 300);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the control first
            this.fLP_elevations.Controls.Clear();

            if (!generateNumericUpDownToolStripMenuItem.Checked)
                return;

            if (listView1.SelectedIndices.Count > 1000)
            {
                Loaded = false;
                return;
            }

            for (int i = 0; i < listView1.SelectedIndices.Count; i++)
            {
                int index = listView1.SelectedIndices[i];
                System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                System.Windows.Forms.Label lbl_entry = new System.Windows.Forms.Label();
                System.Windows.Forms.NumericUpDown nUD = new System.Windows.Forms.NumericUpDown();

                panel.Controls.Add(lbl_entry);
                panel.Controls.Add(nUD);
                panel.Location = new System.Drawing.Point(3, 3);
                panel.Name = "panel_" + index;
                panel.Size = new System.Drawing.Size(203, 24);
                panel.TabIndex = 1;

                lbl_entry.Location = new System.Drawing.Point(1, 1);
                lbl_entry.Margin = new System.Windows.Forms.Padding(0);
                lbl_entry.Name = "lbl_entry_" + index;
                lbl_entry.Size = new System.Drawing.Size(77, 20);
                lbl_entry.TabIndex = 2;
                lbl_entry.Text = "Entry: " + index;
                lbl_entry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                nUD.Location = new System.Drawing.Point(81, 2);
                nUD.Name = "nUD_" + index;
                nUD.Size = new System.Drawing.Size(120, 20);
                nUD.Increment = (decimal)0.01;
                nUD.DecimalPlaces = 5;
                nUD.Maximum = 10000;
                nUD.Minimum = -10000;
                nUD.Value = (decimal)mod_heights[index].Z;
                nUD.ValueChanged += new System.EventHandler(nUD_ValueChanged);
                nUD.TabIndex = 3;

                this.fLP_elevations.Controls.Add(panel);

                //Console.WriteLine("nUD_" + index);
            }
            Loaded = true;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(listView1, new Point(e.X, e.Y));
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor != null && !editor.IsDisposed)
                editor.Dispose();

            editor = new Editor(listView1, (listView1.SelectedItems.Count > 1) ? 1 : (listView1.SelectedItems.Count == 1) ? 0 : -1);
            if (editor.ShowDialog() == DialogResult.OK)
            {
#if DEBUG
                Console.WriteLine("DialogResult: OK"); 
#endif
                if (editor.editorMode == Editor.Editor_Mode.SINGLE)
                {
                    double value = (double)editor.singleHeightVal;

                    foreach(ListViewItem item in listView1.SelectedItems)
                    {
                        int entry = Convert.ToInt32(item.Text);
                        revert.Add(new History() { Index = entry, X = this.mod_heights[entry].Y, Y = this.mod_heights[entry].Z });
                        if (redo.Count > 0)
                            redo = new List<History>();

                        CheckHistoryStatus();

                        this.mod_heights[entry].Z = value;
                        item.SubItems[2].Text = value.ToString();

                        this.elevation_chart.Series[2].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                        this.elevation_chart.Series[3].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                    }
                }
                else if (editor.editorMode == Editor.Editor_Mode.MULTI)
                {
                    double start_x = this.mod_heights[Convert.ToInt32(listView1.SelectedItems[0].Text)].Y;
                    double end_x = this.mod_heights[Convert.ToInt32(listView1.SelectedItems[(listView1.SelectedItems.Count - 1)].Text)].Y;

                    double start_y = (double)editor.multiHeightSVal;
                    double end_y = (double)editor.multiHeightEVal;

                    int index = 0;
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        int entry = Convert.ToInt32(item.Text);
                        revert.Add(new History() { Index = entry, X = this.mod_heights[entry].Y, Y = this.mod_heights[entry].Z });
                        if (redo.Count > 0)
                            redo = new List<History>();

                        CheckHistoryStatus();

                        double new_x = this.mod_heights[entry].Y - start_x;
                        double slope = (end_y - start_y) / (end_x - start_x);
                        double new_y = (((slope * new_x) + start_y));

                        this.mod_heights[entry].Z = new_y;
                        item.SubItems[2].Text = new_y.ToString();

                        this.elevation_chart.Series[2].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                        this.elevation_chart.Series[3].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                        index++;
                    }
                }
                else if (editor.editorMode == Editor.Editor_Mode.ARC_Horizontal)
                {
                    double sagitta = (double)editor.arcSagitta;
                    double firstPoint = this.mod_heights[Convert.ToInt32(listView1.SelectedItems[0].Text)].Y;
                    double width = this.mod_heights[Convert.ToInt32(listView1.SelectedItems[(listView1.SelectedItems.Count - 1)].Text)].Y - firstPoint;
                    double radius = GetRadius(sagitta, width);
                    double centerPoint = firstPoint + (width / 2);
                    double heightChange = 0;
                    int index = 0;
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        int entry = Convert.ToInt32(item.Text);
                        if (entry >= editor.arcFinalPoint)
                            break;

                        revert.Add(new History() { Index = entry, X = this.mod_heights[entry].Y, Y = this.mod_heights[entry].Z });
                        if (redo.Count > 0)
                            redo = new List<History>();

                        CheckHistoryStatus();

                        //Point Calculation
                        double new_X_offset = this.mod_heights[entry].Y - centerPoint;
                        double Z = (sagitta < 0) ? (GetHeightARCPoint(sagitta, radius, new_X_offset) * -1) : GetHeightARCPoint(sagitta, radius, new_X_offset);
                        if (index == 0)
                            heightChange = (double)editor.arcHeightSVal - Z;
                        Z += heightChange;

                        this.mod_heights[entry].Z = Z;
                        item.SubItems[2].Text = Z.ToString();

                        this.elevation_chart.Series[2].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                        this.elevation_chart.Series[3].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                        index++;
                    }
                }

                else if (editor.editorMode == Editor.Editor_Mode.ARC_Vertical)
                {
                    double sagitta = (double)editor.arcVSagitta;
                    double firstPoint = (double)editor.arcVHeightSVal;
                    double width = (double)editor.arcVHeightEVal - firstPoint;
                    double radius = GetRadius(sagitta, width);
                    double centerPoint = firstPoint + (width / 2);
                    double heightChange = 0;
                    int index = 0;
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        int entry = Convert.ToInt32(item.Text);
                        if (entry >= editor.arcVFinalPoint)
                            break;

                        revert.Add(new History() { Index = entry, X = this.mod_heights[entry].Y, Y = this.mod_heights[entry].Z });
                        if (redo.Count > 0)
                            redo = new List<History>();

                        CheckHistoryStatus();

                        //Point Calculation
                        double new_X_offset = this.mod_heights[entry].Z - centerPoint;
                        double Z = (sagitta < 0) ? (GetHeightARCPoint(sagitta, radius, new_X_offset) * -1) : GetHeightARCPoint(sagitta, radius, new_X_offset);
                        if (index == 0)
                            heightChange = (double)editor.arcVHeightSVal - Z;
                        Z += heightChange;

                        this.mod_heights[entry].Z = Z;
                        item.SubItems[2].Text = Z.ToString();

                        this.elevation_chart.Series[2].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                        this.elevation_chart.Series[3].Points[entry].YValues[0] = this.mod_heights[entry].Z;
                        index++;
                    }
                }

                // reset all data point attributes
                foreach (DataPoint point in this.elevation_chart.Series[3].Points)
                {
                    this.dataPointResetAppearance(point);
                }
                foreach (DataPoint point in this.elevation_chart.Series[2].Points)
                {
                    this.dataPointResetAppearance(point);
                }
            }
            else
            {
#if DEBUG
                Console.WriteLine("DialogResult: Cancel");
#endif
            }
            editor.Dispose();
        }

        /// <summary>
        /// Calculating Height of an Arc at Any Point
        /// h = s + Sqrt(r² - x² - r)
        /// where:
        /// h = the height of the arc
        /// s = the sagitta of the arc
        /// r = the radius of the arc
        /// x = the horizontal offset from the center to the point where you want the height
        /// </summary>
        /// <returns>double:height</returns>
        private double GetHeightARCPoint(double sagitta, double radius, double x)
        {
            return (sagitta + Math.Sqrt((radius * radius) - (x * x) - radius));
        }

        private double GetRadius(double height, double width)
        {
            return ((height / 2) + ((width * width) / (8 * height)));
        }

        private double GetDifference(int selectedItemsCount, double pointA, double pointB)
        {
            if (pointA > pointB)
            {
                return (((pointB - pointA) / selectedItemsCount) * -1);
            }
            else if (pointA < pointB)
            {
                return (((pointB - pointA) * -1) / selectedItemsCount);
            }
            else
            {
                return (pointA);
            }
        }
    }

    public class History
    {
        public int Index { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
    }
}

static class SwapExtension
{
    public static T Swap<T>(this T x, ref T y)
    {
        T t = y;
        y = x;
        return t;
    }
}
