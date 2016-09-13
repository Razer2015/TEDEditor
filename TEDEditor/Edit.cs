using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TEDEditor
{
    public class Edit
    {
        static List<History> reverts;
        static List<History> redos;
        static Vertex[] _heights;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="selectedItems"></param>
        /// <param name="chart"></param>
        /// <param name="heights"></param>
        public static void getData(Editor editor, ListView.SelectedListViewItemCollection selectedItems, ref Chart chart, Vertex[] heights, bool isPreview = false)
        {
            getData(editor, selectedItems, ref chart, null, null, heights, isPreview);
            reverts = null;
            redos = null;
            _heights = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="selectedItems"></param>
        /// <param name="chart"></param>
        /// <param name="heights"></param>
        public static void getData(Editor editor, ListView.SelectedListViewItemCollection selectedItems, ref Chart chart, ref Vertex[] heights, bool isPreview = false)
        {
            _heights = heights;
            getData(editor, selectedItems, ref chart, null, null, _heights, isPreview);
            heights = _heights;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="selectedItems"></param>
        /// <param name="chart"></param>
        /// <param name="revert"></param>
        /// <param name="redo"></param>
        /// <param name="heights"></param>
        public static void getData(Editor editor, ListView.SelectedListViewItemCollection selectedItems, ref Chart chart, ref List<History> revert, ref List<History> redo, ref Vertex[] heights, bool isPreview = false)
        {
            reverts = revert;
            redos = redo;
            _heights = heights;
            getData(editor, selectedItems, ref chart, reverts, redos, heights, isPreview);
            revert = reverts;
            redo = redos;
            heights = _heights;
        }

        /// <summary>
        /// Get the new modified data
        /// </summary>
        /// <param name="editor"></param>
        /// <param name="selectedItems"></param>
        /// <param name="chart"></param>
        /// <param name="revert"></param>
        /// <param name="redo"></param>
        /// <param name="heights"></param>
        public static void getData(Editor editor, ListView.SelectedListViewItemCollection selectedItems, ref Chart chart, List<History> revert, List<History> redo, Vertex[] heights, bool isPreview = false)
        {
            if (editor.editorMode == Editor.Editor_Mode.SINGLE)
            {
                double value = (double)editor.singleHeightVal;

                foreach (ListViewItem item in selectedItems)
                {
                    int entry = Convert.ToInt32(item.Text);

                    if(revert != null)
                    {
                        revert.Add(new History() { Index = entry, X = heights[entry].Y, Y = heights[entry].Z });
                        if (redo != null && redo.Count > 0)
                            redo = new List<History>();
                    }
                    
                    if (!isPreview)
                    {
                        heights[entry].Z = value;
                        item.SubItems[2].Text = value.ToString();
                    }
                        

                    chart.Series[0].Points[entry].YValues[0] = value;
                    chart.Series[1].Points[entry].YValues[0] = value;
                }
            }
            else if (editor.editorMode == Editor.Editor_Mode.MULTI)
            {
                double start_x = heights[Convert.ToInt32(selectedItems[0].Text)].Y;
                double end_x = heights[Convert.ToInt32(selectedItems[(selectedItems.Count - 1)].Text)].Y;

                double start_y = (double)editor.multiHeightSVal;
                double end_y = (double)editor.multiHeightEVal;

                int index = 0;
                foreach (ListViewItem item in selectedItems)
                {
                    int entry = Convert.ToInt32(item.Text);
                    if (revert != null)
                    {
                        revert.Add(new History() { Index = entry, X = heights[entry].Y, Y = heights[entry].Z });
                        if (redo != null && redo.Count > 0)
                            redo = new List<History>();
                    }

                    double new_x = heights[entry].Y - start_x;
                    double slope = (end_y - start_y) / (end_x - start_x);
                    double new_y = (((slope * new_x) + start_y));

                    if (!isPreview)
                    {
                        heights[entry].Z = new_y;
                        item.SubItems[2].Text = new_y.ToString();
                    }

                    chart.Series[0].Points[entry].YValues[0] = new_y;
                    chart.Series[1].Points[entry].YValues[0] = new_y;
                    index++;
                }
            }
            else if (editor.editorMode == Editor.Editor_Mode.ARC_Horizontal)
            {
                double sagitta = (double)editor.arcSagitta;
                double firstPoint = heights[Convert.ToInt32(selectedItems[0].Text)].Y;
                double width = heights[Convert.ToInt32(selectedItems[(selectedItems.Count - 1)].Text)].Y - firstPoint;
                double radius = GetRadius(sagitta, width);
                double centerPoint = firstPoint + (width / 2);
                double heightChange = 0;
                int index = 0;
                foreach (ListViewItem item in selectedItems)
                {
                    int entry = Convert.ToInt32(item.Text);
                    if (entry >= editor.arcFinalPoint)
                        break;

                    if (revert != null)
                    {
                        revert.Add(new History() { Index = entry, X = heights[entry].Y, Y = heights[entry].Z });
                        if (redo != null && redo.Count > 0)
                            redo = new List<History>();
                    }

                    //Point Calculation
                    double new_X_offset = heights[entry].Y - centerPoint;
                    double Z = (sagitta < 0) ? (GetHeightARCPoint(sagitta, radius, new_X_offset) * -1) : GetHeightARCPoint(sagitta, radius, new_X_offset);
                    if (index == 0)
                        heightChange = (double)editor.arcHeightSVal - Z;
                    Z += heightChange;

                    if (!isPreview)
                    {
                        heights[entry].Z = Z;
                        item.SubItems[2].Text = Z.ToString();
                    }

                    chart.Series[0].Points[entry].YValues[0] = Z;
                    chart.Series[1].Points[entry].YValues[0] = Z;
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
                foreach (ListViewItem item in selectedItems)
                {
                    int entry = Convert.ToInt32(item.Text);
                    if (entry >= editor.arcVFinalPoint)
                        break;

                    if (revert != null)
                    {
                        revert.Add(new History() { Index = entry, X = heights[entry].Y, Y = heights[entry].Z });
                        if (redo != null && redo.Count > 0)
                            redo = new List<History>();
                    }

                    //Point Calculation
                    double new_X_offset = heights[entry].Z - centerPoint;
                    double Z = (sagitta < 0) ? (GetHeightARCPoint(sagitta, radius, new_X_offset) * -1) : GetHeightARCPoint(sagitta, radius, new_X_offset);
                    if (index == 0)
                        heightChange = (double)editor.arcVHeightSVal - Z;
                    Z += heightChange;

                    if (!isPreview)
                    {
                        heights[entry].Z = Z;
                        item.SubItems[2].Text = Z.ToString();
                    }

                    chart.Series[0].Points[entry].YValues[0] = Z;
                    chart.Series[1].Points[entry].YValues[0] = Z;
                    index++;
                }
            }
            chart.Refresh();

            //// reset all data point attributes
            //foreach (DataPoint point in chart.Series[0].Points)
            //{
            //    dataPointResetAppearance(point);
            //}
            //foreach (DataPoint point in chart.Series[1].Points)
            //{
            //    dataPointResetAppearance(point);
            //}
        }

        private static void dataPointResetAppearance(DataPoint point)
        {
            point.MarkerColor = Color.Brown;
            point.MarkerSize = 5;
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
        public static double GetHeightARCPoint(double sagitta, double radius, double x)
        {
            double step1 = (radius * radius) - (x * x) - radius;
            double step2 = (step1 < 0) ? Math.Sqrt((step1 < 0) ? step1 * -1 : step1) * -1 : Math.Sqrt((step1 < 0) ? step1 * -1 : step1);
            return (sagitta + step2);
        }

        public static double GetRadius(double height, double width)
        {
            return ((height / 2) + ((width * width) / (8 * height)));
        }
    }
}
