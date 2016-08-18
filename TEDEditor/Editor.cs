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
            ARC,
            NONE = -1
        }

        #region Private Variables
        ListView lView;
        decimal sagittaOldVal;
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

        #region ARC
        public decimal arcHeightSVal { get; set; }
        public decimal arcFinalPoint { get; set; }
        public decimal arcSagitta { get; set; }
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
            else if (editorMode == Editor_Mode.ARC)
            {
                if (lView != null && lView.SelectedItems.Count > 0)
                {
                    nUD_arc_heightS.Value = Convert.ToDecimal(lView.SelectedItems[0].SubItems[2].Text);
                    //nUD_arc_finalPoint.Minimum = Convert.ToInt32(lView.SelectedItems[0].Text) + 1;
                    //nUD_arc_finalPoint.Maximum = (lView.Items.Count - 1);
                    nUD_arc_finalPoint.Value = Convert.ToInt32(lView.SelectedItems[(lView.SelectedItems.Count - 1)].Text);
                    nUD_arc_sagitta.Value = 0.1M;
                    arcSagitta = nUD_arc_sagitta.Value;
                }

                gBox_arc.Visible = true;
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

        #region ARC
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
    }
}
