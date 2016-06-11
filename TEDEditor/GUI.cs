using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TEDEditor
{
    public partial class GUI : Form
    {
        // RETURNS
        public DialogResult Result { get; set; }
        public Vertex[] Field1 { get; set; }

        // 
        String elevation_name = "";
        String elevation_point_name = "";
        String modified_name = "";
        String modified_point_name = "";

        public Vertex[] orig_heights;
        public Vertex[] mod_heights;

        // Used for zooming event
        private int zoom_depth = 0;

        //used for mouse over chart events
        private bool isDraggingPoint = false;
        private int draggedPointIndex = -1;

        public GUI()
        {
            InitializeComponent();
        }

        public GUI(Vertex[] heights)
        {
            InitializeComponent();

            elevation_name = this.elevation_chart.Series[0].Name;
            elevation_point_name = this.elevation_chart.Series[1].Name;
            modified_name = this.elevation_chart.Series[2].Name;
            modified_point_name = this.elevation_chart.Series[3].Name;

            elevation_chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            elevation_chart.MouseWheel += new System.Windows.Forms.MouseEventHandler(chData_MouseWheel);
            elevation_chart.AlignDataPointsByAxisLabel();

            this.orig_heights = DeepCopy<Vertex[]>(heights);
            this.mod_heights = DeepCopy<Vertex[]>(heights);

            fLP_elevation(this.orig_heights);
            Visualize(this.orig_heights);
            Visualize_mod(this.mod_heights);
        }

        private void nUD_ValueChanged(object sender, EventArgs e)
        {
            int entry = Convert.ToInt32(((NumericUpDown)sender).Name.Remove(0, 4));
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

        public void fLP_elevation(Vertex[] heights)
        {
            // Clear the control first
            this.fLP_elevations.Controls.Clear();

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
        }

        public void Visualize(Vertex[] heights)
        {
            // Clear
            elevation_chart.Series[elevation_name].Points.Clear();
            elevation_chart.Series[elevation_point_name].Points.Clear();

            // Populate
            for (int i = 0; i < heights.Length; i++)
            {
                elevation_chart.Series[elevation_name].Points.AddXY(heights[i].Y, heights[i].Z);
                elevation_chart.Series[elevation_point_name].Points.AddXY(heights[i].Y, heights[i].Z);

                elevation_chart.Series[elevation_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
                elevation_chart.Series[elevation_point_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
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

                elevation_chart.Series[modified_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
                elevation_chart.Series[modified_point_name].Points[i].AxisLabel = String.Format("{0} Meters", heights[i].Y.ToString("n2"));
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

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TSMI = (ToolStripMenuItem)sender;
            TSMI.Checked = !TSMI.Checked;

            elevation_chart.Series[elevation_name].Enabled = displayElevationToolStripMenuItem.Checked;
            elevation_chart.Series[elevation_point_name].Enabled = displayElevationPointsToolStripMenuItem.Checked;
            elevation_chart.Series[modified_name].Enabled = displayModifiedToolStripMenuItem.Checked;
            elevation_chart.Series[modified_point_name].Enabled = displayModifiedPointsToolStripMenuItem.Checked;
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


        /////////////////////////////////////
        #region chart mouse event handling

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            //call HitTest
            HitTestResult result = this.elevation_chart.HitTest(e.X, e.Y);

            // reset all data point attributes
            foreach (DataPoint point in this.elevation_chart.Series[3].Points)
            {
                this.dataPointResetAppearance(point);
            }
            foreach (DataPoint point in this.elevation_chart.Series[2].Points)
            {
                this.dataPointResetAppearance(point);
            }

            //if mouse is over a data point
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                //find mouse-over data point
                DataPoint point = this.elevation_chart.Series[3].Points[result.PointIndex];

                //change appearance of that data point 
                this.dataPointSetMouseOverAppearance(point);
            }

            //additionally, if mouse is dragging a data point
            if (this.isDraggingPoint)
            {
                //change appearance of the graph
                this.elevation_chart.Series[2].Color = Color.LightBlue;
                //change appearance of the graph
                this.elevation_chart.Series[3].Color = Color.AliceBlue;

                //change mouse position values to Y values
                this.elevation_chart.Series[2].Points[this.draggedPointIndex].YValues[0] = this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
                //change mouse position values to Y values
                this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0] = this.elevation_chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                //change numericupdown Y
                ((NumericUpDown)fLP_elevations.Controls["panel_" + this.draggedPointIndex].Controls["nUD_" + this.draggedPointIndex]).Value = (decimal)this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0];

                //update the values for the table to display
                this.mod_heights[this.draggedPointIndex].Z = this.elevation_chart.Series[3].Points[this.draggedPointIndex].YValues[0];
            }
        }

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult result = this.elevation_chart.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // store the index of the point being dragged
                this.draggedPointIndex = result.PointIndex;
                this.isDraggingPoint = true;

                ((NumericUpDown)fLP_elevations.Controls["panel_" + this.draggedPointIndex].Controls["nUD_" + this.draggedPointIndex]).ValueChanged -= 
                    new System.EventHandler(nUD_ValueChanged);
            }
        }

        private void chart_MouseUp(object sender, MouseEventArgs e)
        {
            if(draggedPointIndex != -1)
            {
                ((NumericUpDown)fLP_elevations.Controls["panel_" + this.draggedPointIndex].Controls["nUD_" + this.draggedPointIndex]).ValueChanged += 
                    new System.EventHandler(nUD_ValueChanged);
            }

            this.draggedPointIndex = -1;
            this.isDraggingPoint = false;

            //set appearance of graph back to normal
            this.elevation_chart.Series[2].Color = Color.Red;
            this.elevation_chart.Series[3].Color = Color.DarkRed;
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result = DialogResult.OK;
            Field1 = this.mod_heights;
            this.Close();
        }

        private void dismissToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result = DialogResult.Cancel;
            Field1 = this.orig_heights;
            this.Close();
        }
    }
}
