using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TEDEditor
{
    public partial class Editor : Form
    {
        public enum Editor_Mode
        {
            SINGLE,
            MULTI,
            ARC_Horizontal,
            ARC_Vertical,
            NONE = -1
        }

        #region Private Variables
        ListView.SelectedListViewItemCollection selectedItems;
        Vertex[] heights;
        decimal sagittaOldVal;
        decimal sagittaOldVal_Vertical;

        String elevation_line_name = "";
        String elevation_point_name = "";

        // Used for zooming event
        private int zoom_depth = 0;

        private bool update = false;
        #endregion

        #region Accessors
        public Editor_Mode editorMode { get; set; }

        #region Single
        public decimal singleHeightVal { get; set; }
        #endregion

        #region Multi
        public decimal multiHeightSVal { get; set; }
        public decimal multiHeightEVal { get; set; }
        #endregion

        #region ARC Horizontal
        public decimal arcHeightSVal { get; set; }
        public decimal arcFinalPoint { get; set; }
        public decimal arcSagitta { get; set; }
        #endregion

        #region ARC Vertical
        public decimal arcVHeightSVal { get; set; }
        public decimal arcVHeightEVal { get; set; }
        public decimal arcVFinalPoint { get; set; }
        public decimal arcVSagitta { get; set; }
        #endregion

        #endregion

        #region Constructors
        public Editor()
        {
            InitializeComponent();
        }

        public Editor(ListView.SelectedListViewItemCollection selectedItems, Vertex[] heights, int index)
        {
            InitializeComponent();

            this.heights = DeepCopy<Vertex[]>(heights);
            this.selectedItems = selectedItems;

            this.chart_preview.ChartAreas[0].AxisX.IsStartedFromZero = true;

            this.chart_preview.ChartAreas[0].CursorX.IsUserEnabled = true;
            this.chart_preview.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            // set selection color to transparent so that range selection is not drawn
            this.chart_preview.ChartAreas[0].CursorX.LineColor = System.Drawing.Color.Transparent;

            elevation_line_name = this.chart_preview.Series[0].Name;
            elevation_point_name = this.chart_preview.Series[1].Name;

            chart_preview.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_preview.MouseWheel += new System.Windows.Forms.MouseEventHandler(chData_MouseWheel);

            Visualize(this.heights);
#if DEBUG
            cBox_mode.Items.Add("ARC Vertical");
#endif

            if (index < cBox_mode.Items.Count)
                cBox_mode.SelectedIndex = index;
        }
        #endregion

        #region Global Controls
        private void cBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            editorMode = (Editor_Mode)cBox_mode.SelectedIndex;

            gBox_single.Visible = false;
            gBox_multi.Visible = false;
            gBox_arc.Visible = false;
            gBox_arcV.Visible = false;
            if (editorMode == Editor_Mode.SINGLE)
            {
                if (selectedItems != null && selectedItems.Count > 0)
                    nUD_single_heightVal.Value = Convert.ToDecimal(selectedItems[0].SubItems[2].Text);
                gBox_single.Visible = true;
            }
            else if (editorMode == Editor_Mode.MULTI)
            {
                if(selectedItems != null && selectedItems.Count > 1)
                {
                    nUD_multi_heightS.Value = Convert.ToDecimal(selectedItems[0].SubItems[2].Text);
                    nUD_multi_heightE.Value = Convert.ToDecimal(selectedItems[selectedItems.Count - 1].SubItems[2].Text);
                }
                
                gBox_multi.Visible = true;
            }
            else if (editorMode == Editor_Mode.ARC_Horizontal)
            {
                if (selectedItems != null && selectedItems.Count > 0)
                {
                    update = false;
                    nUD_arc_heightS.Value = Convert.ToDecimal(selectedItems[0].SubItems[2].Text);
                    nUD_arc_finalPoint.Minimum = Convert.ToInt32(selectedItems[0].Text) + 1;
                    nUD_arc_finalPoint.Maximum = Convert.ToInt32(selectedItems[selectedItems.Count - 1].Text);
                    nUD_arc_finalPoint.Value = Convert.ToInt32(selectedItems[(selectedItems.Count - 1)].Text);
                    nUD_arc_sagitta.Value = 0.1M;
                    update = true;
                    arcSagitta = nUD_arc_sagitta.Value;
                }

                gBox_arc.Visible = true;
            }
            else if (editorMode == Editor_Mode.ARC_Vertical)
            {
                if (selectedItems != null && selectedItems.Count > 0)
                {
                    update = false;
                    nUD_arcV_heightS.Value = Convert.ToDecimal(selectedItems[0].SubItems[2].Text);
                    nUD_arcV_heightE.Value = Convert.ToDecimal(selectedItems[selectedItems.Count - 1].SubItems[2].Text);
                    nUD_arcV_finalPoint.Minimum = Convert.ToInt32(selectedItems[0].Text) + 1;
                    nUD_arcV_finalPoint.Maximum = Convert.ToInt32(selectedItems[selectedItems.Count - 1].Text);
                    nUD_arcV_finalPoint.Value = Convert.ToInt32(selectedItems[(selectedItems.Count - 1)].Text);
                    nUD_arcV_sagitta.Value = 0.1M;
                    update = true;
                    arcSagitta = nUD_arcV_sagitta.Value;
                }

                gBox_arcV.Visible = true;
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Global Functions
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
        #endregion

        #region Single
        private void nUD_single_heightVal_ValueChanged(object sender, EventArgs e)
        {
            singleHeightVal = nUD_single_heightVal.Value;
            RefreshChart();
        }
        #endregion

        #region Multi
        private void nUD_multi_heightS_ValueChanged(object sender, EventArgs e)
        {
            multiHeightSVal = nUD_multi_heightS.Value;
            RefreshChart();
        }

        private void nUD_multi_heightE_ValueChanged(object sender, EventArgs e)
        {
            multiHeightEVal = nUD_multi_heightE.Value;
            RefreshChart();
        }
        #endregion

        #region ARC Horizontal
        private double getMaxSagitta(double width)
        {
            double maxSagitta = 0;
            double sagitta = 0;
            do
            {
                sagitta += 0.1;
                maxSagitta = Edit.GetRadius(sagitta, width);
            } while (sagitta < maxSagitta);

            return (maxSagitta);
        }

        private void setrTBox()
        {
            // 24
            rTBox_arcH.Text = String.Format(
                "Height Start (Max/Min): {0}/{1}\r\n" + 
                "Final Point (Max/Min):  {2}/{3}\r\n" +
                "Sagitta (Max/Min):      {4:F1}/{5:F1}", 
                nUD_arc_heightS.Maximum, nUD_arc_heightS.Minimum,
                nUD_arc_finalPoint.Maximum, nUD_arc_finalPoint.Minimum,
                nUD_arc_sagitta.Maximum, nUD_arc_sagitta.Minimum);
        }

        private void nUD_arc_heightS_ValueChanged(object sender, EventArgs e)
        {
            arcHeightSVal = nUD_arc_heightS.Value;
            double MaxSagitta = getMaxSagitta((
                                heights[Convert.ToInt32(selectedItems[selectedItems.Count - 1].Text)].Y - 
                                heights[Convert.ToInt32(selectedItems[0].Text)].Y));
            nUD_arc_sagitta.Maximum = (decimal)MaxSagitta;
            nUD_arc_sagitta.Minimum = (decimal)MaxSagitta * -1;
            setrTBox();
            if (update)
                RefreshChart();
        }

        private void nUD_arc_finalPoint_ValueChanged(object sender, EventArgs e)
        {
            arcFinalPoint = nUD_arc_finalPoint.Value;
            double MaxSagitta = getMaxSagitta((
                    heights[Convert.ToInt32(selectedItems[selectedItems.Count - 1].Text)].Y -
                    heights[Convert.ToInt32(selectedItems[0].Text)].Y));
            nUD_arc_sagitta.Maximum = (decimal)MaxSagitta;
            nUD_arc_sagitta.Minimum = (decimal)MaxSagitta * -1;
            setrTBox();
            if (update)
                RefreshChart();
        }

        private void nUD_arc_sagitta_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nUD_arc_sagitta.Value;
            if (value == 0)
                if (value > sagittaOldVal)
                {
                    value += 0.1M;
                    nUD_arc_sagitta.Value = value;
                }
                else
                {
                    value -= 0.1M;
                    nUD_arc_sagitta.Value = value;
                }

            arcSagitta = value;
            sagittaOldVal = value;
            if (update)
                RefreshChart();
        }

        #endregion

        #region ARC Vertical
        private void nUD_arcV_heightS_ValueChanged(object sender, EventArgs e)
        {
            arcVHeightSVal = nUD_arcV_heightS.Value;
            if (update)
                RefreshChart();
        }

        private void nUD_arcV_heightE_ValueChanged(object sender, EventArgs e)
        {
            arcVHeightEVal = nUD_arcV_heightE.Value;
            if (update)
                RefreshChart();
        }

        private void nUD_arcV_finalPoint_ValueChanged(object sender, EventArgs e)
        {
            arcVFinalPoint = nUD_arcV_finalPoint.Value;
            if (update)
                RefreshChart();
        }

        private void nUD_arcV_sagitta_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nUD_arcV_sagitta.Value;
            if (value == 0)
                if (value > sagittaOldVal_Vertical)
                {
                    value += 0.1M;
                    nUD_arcV_sagitta.Value = value;
                }
                else
                {
                    value -= 0.1M;
                    nUD_arcV_sagitta.Value = value;
                }

            arcVSagitta = value;
            sagittaOldVal_Vertical = value;
            if (update)
                RefreshChart();
        }
        #endregion

        #region Chart Preview

        #region Populate/Visualize
        public void Visualize(Vertex[] heights)
        {
            // Clear
            chart_preview.Series[elevation_line_name].Points.Clear();
            chart_preview.Series[elevation_point_name].Points.Clear();

            // Populate
            for (int i = 0; i < heights.Length; i++)
            {
                chart_preview.Series[elevation_line_name].Points.AddXY(heights[i].Y, heights[i].Z);
                chart_preview.Series[elevation_point_name].Points.AddXY(heights[i].Y, heights[i].Z);
            }
            chart_preview.Series[elevation_line_name].ChartType = SeriesChartType.FastLine;
            chart_preview.Series[elevation_line_name].Color = Color.Blue;

            chart_preview.Series[elevation_point_name].ChartType = SeriesChartType.FastPoint;
            chart_preview.Series[elevation_point_name].Color = Color.DarkBlue;
        }
        #endregion

        #region Zooming
        private void chData_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    zoom_depth--;
                    if (zoom_depth < 1)
                    {
                        chart_preview.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                        chart_preview.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                        zoom_depth = 0;
                    }
                    else
                    {
                        double xMin = chart_preview.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                        double xMax = chart_preview.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                        double yMin = chart_preview.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                        double yMax = chart_preview.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                        double posXStart = chart_preview.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) * 4;
                        double posXFinish = chart_preview.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) * 4;
                        double posYStart = chart_preview.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) * 4;
                        double posYFinish = chart_preview.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) * 4;

                        chart_preview.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                        chart_preview.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                    }
                }

                if (e.Delta > 0)
                {
                    zoom_depth++;

                    double xMin = chart_preview.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart_preview.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart_preview.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart_preview.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart_preview.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    double posXFinish = chart_preview.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    double posYStart = chart_preview.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    double posYFinish = chart_preview.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    chart_preview.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    chart_preview.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        #region Additonal Code
        private void tBar_zoom_Scroll(object sender, EventArgs e)
        {
            chart_preview.ChartAreas[0].AxisX.ScaleView.Size = tBar_zoom.Maximum - tBar_zoom.Value;
        }

        private void tBar_zoom_ValueChanged(object sender, EventArgs e)
        {
            chart_preview.ChartAreas[0].AxisX.ScaleView.Position = tBar_zoom.Value;
        } 
        #endregion

        #endregion

        #region Edit
        private void RefreshChart()
        {
            // Reset
            for (int i = 0; i < this.heights.Length; i++)
            {
                chart_preview.Series[0].Points[i].YValues[0] = heights[i].Z;
                chart_preview.Series[1].Points[i].YValues[0] = heights[i].Z;
            }

            // Edit
            Edit.getData(this, selectedItems, ref chart_preview, this.heights, true);
        }
        #endregion

        #endregion
    }
}
