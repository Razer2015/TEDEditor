using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        ListView lView;
        decimal sagittaOldVal;
        decimal sagittaOldVal_Vertical;
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

        public Editor(ListView lView, int index)
        {
            InitializeComponent();

            this.lView = lView;

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
                if (lView != null && lView.SelectedItems.Count > 0)
                    nUD_single_heightVal.Value = Convert.ToDecimal(lView.SelectedItems[0].SubItems[2].Text);
                gBox_single.Visible = true;
            }
            else if (editorMode == Editor_Mode.MULTI)
            {
                if(lView != null && lView.SelectedItems.Count > 1)
                {
                    nUD_multi_heightS.Value = Convert.ToDecimal(lView.SelectedItems[0].SubItems[2].Text);
                    nUD_multi_heightE.Value = Convert.ToDecimal(lView.SelectedItems[lView.SelectedItems.Count - 1].SubItems[2].Text);
                }
                
                gBox_multi.Visible = true;
            }
            else if (editorMode == Editor_Mode.ARC_Horizontal)
            {
                if (lView != null && lView.SelectedItems.Count > 0)
                {
                    nUD_arc_heightS.Value = Convert.ToDecimal(lView.SelectedItems[0].SubItems[2].Text);
                    nUD_arc_finalPoint.Minimum = Convert.ToInt32(lView.SelectedItems[0].Text) + 1;
                    nUD_arc_finalPoint.Maximum = Convert.ToInt32(lView.SelectedItems[lView.SelectedItems.Count - 1].Text);
                    nUD_arc_finalPoint.Value = Convert.ToInt32(lView.SelectedItems[(lView.SelectedItems.Count - 1)].Text);
                    nUD_arc_sagitta.Value = 0.1M;
                    arcSagitta = nUD_arc_sagitta.Value;
                }

                gBox_arc.Visible = true;
            }
            else if (editorMode == Editor_Mode.ARC_Vertical)
            {
                if (lView != null && lView.SelectedItems.Count > 0)
                {
                    nUD_arcV_heightS.Value = Convert.ToDecimal(lView.SelectedItems[0].SubItems[2].Text);
                    nUD_arcV_heightE.Value = Convert.ToDecimal(lView.SelectedItems[lView.SelectedItems.Count - 1].SubItems[2].Text);
                    nUD_arcV_finalPoint.Minimum = Convert.ToInt32(lView.SelectedItems[0].Text) + 1;
                    nUD_arcV_finalPoint.Maximum = Convert.ToInt32(lView.SelectedItems[lView.SelectedItems.Count - 1].Text);
                    nUD_arcV_finalPoint.Value = Convert.ToInt32(lView.SelectedItems[(lView.SelectedItems.Count - 1)].Text);
                    nUD_arcV_sagitta.Value = 0.1M;
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

        #region Single
        private void nUD_single_heightVal_ValueChanged(object sender, EventArgs e)
        {
            singleHeightVal = nUD_single_heightVal.Value;
        }
        #endregion

        #region Multi
        private void nUD_multi_heightS_ValueChanged(object sender, EventArgs e)
        {
            multiHeightSVal = nUD_multi_heightS.Value;
        }

        private void nUD_multi_heightE_ValueChanged(object sender, EventArgs e)
        {
            multiHeightEVal = nUD_multi_heightE.Value;
        }
        #endregion

        #region ARC Horizontal
        private void nUD_arc_heightS_ValueChanged(object sender, EventArgs e)
        {
            arcHeightSVal = nUD_arc_heightS.Value;
        }

        private void nUD_arc_finalPoint_ValueChanged(object sender, EventArgs e)
        {
            arcFinalPoint = nUD_arc_finalPoint.Value;
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
        }

        #endregion

        #region ARC Vertical
        private void nUD_arcV_heightS_ValueChanged(object sender, EventArgs e)
        {
            arcVHeightSVal = nUD_arcV_heightS.Value;
        }

        private void nUD_arcV_heightE_ValueChanged(object sender, EventArgs e)
        {
            arcVHeightEVal = nUD_arcV_heightE.Value;
        }

        private void nUD_arcV_finalPoint_ValueChanged(object sender, EventArgs e)
        {
            arcVFinalPoint = nUD_arcV_finalPoint.Value;
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
        }
        #endregion
    }
}
