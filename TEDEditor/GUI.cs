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
        public Vertex[] orig_heights;
        public Vertex[] mod_heights;

        public GUI()
        {
            InitializeComponent();
        }

        public GUI(Vertex[] heights)
        {
            InitializeComponent();

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
            Visualize_mod(this.mod_heights);
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
            elevation_chart.Series["Elevation"].Points.Clear();
            elevation_chart.Series["Elevation Points"].Points.Clear();

            // Populate
            for (int i = 0; i < heights.Length; i++)
            {
                elevation_chart.Series["Elevation"].Points.AddXY(heights[i].Y, heights[i].Z);
                elevation_chart.Series["Elevation Points"].Points.AddXY(heights[i].Y, heights[i].Z);
            }
            elevation_chart.Series["Elevation"].ChartType = SeriesChartType.FastLine;
            elevation_chart.Series["Elevation"].Color = Color.Blue;

            elevation_chart.Series["Elevation Points"].ChartType = SeriesChartType.FastPoint;
            elevation_chart.Series["Elevation Points"].Color = Color.DarkBlue;

            elevation_chart.Series["Elevation"].Enabled = displayElevationToolStripMenuItem.Checked;
            elevation_chart.Series["Elevation Points"].Enabled = displayElevationPointsToolStripMenuItem.Checked;
        }

        public void Visualize_mod(Vertex[] heights)
        {
            // Clear
            elevation_chart.Series["Modified"].Points.Clear();
            elevation_chart.Series["Modified Points"].Points.Clear();

            // Populate
            for (int i = 0; i < heights.Length; i++)
            {
                elevation_chart.Series["Modified"].Points.AddXY(heights[i].Y, heights[i].Z);
                elevation_chart.Series["Modified Points"].Points.AddXY(heights[i].Y, heights[i].Z);
            }
            elevation_chart.Series["Modified"].ChartType = SeriesChartType.FastLine;
            elevation_chart.Series["Modified"].Color = Color.Red;

            elevation_chart.Series["Modified Points"].ChartType = SeriesChartType.FastPoint;
            elevation_chart.Series["Modified Points"].Color = Color.DarkRed;

            elevation_chart.Series["Modified"].Enabled = displayModifiedToolStripMenuItem.Checked;
            elevation_chart.Series["Modified Points"].Enabled = displayModifiedPointsToolStripMenuItem.Checked;
        }

        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    elevation_chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    elevation_chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
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

            Visualize(this.orig_heights);
            Visualize_mod(this.mod_heights);
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
    }
}
