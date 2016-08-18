﻿namespace TEDEditor
{
    partial class Editor
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
            this.cBox_mode = new System.Windows.Forms.ComboBox();
            this.gBox_mode = new System.Windows.Forms.GroupBox();
            this.gBox_single = new System.Windows.Forms.GroupBox();
            this.lbl_single_heightVal = new System.Windows.Forms.Label();
            this.nUD_single_heightVal = new System.Windows.Forms.NumericUpDown();
            this.gBox_multi = new System.Windows.Forms.GroupBox();
            this.lbl_multi_heightE = new System.Windows.Forms.Label();
            this.nUD_multi_heightE = new System.Windows.Forms.NumericUpDown();
            this.lbl_multi_heightS = new System.Windows.Forms.Label();
            this.nUD_multi_heightS = new System.Windows.Forms.NumericUpDown();
            this.gBox_arc = new System.Windows.Forms.GroupBox();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_arc_heightS = new System.Windows.Forms.Label();
            this.nUD_arc_heightS = new System.Windows.Forms.NumericUpDown();
            this.lbl_arc_FinalPoint = new System.Windows.Forms.Label();
            this.nUD_arc_finalPoint = new System.Windows.Forms.NumericUpDown();
            this.lbl_arc_sagitta = new System.Windows.Forms.Label();
            this.nUD_arc_sagitta = new System.Windows.Forms.NumericUpDown();
            this.gBox_mode.SuspendLayout();
            this.gBox_single.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_single_heightVal)).BeginInit();
            this.gBox_multi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_multi_heightE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_multi_heightS)).BeginInit();
            this.gBox_arc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_heightS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_finalPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_sagitta)).BeginInit();
            this.SuspendLayout();
            // 
            // cBox_mode
            // 
            this.cBox_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBox_mode.FormattingEnabled = true;
            this.cBox_mode.Items.AddRange(new object[] {
            "Single",
            "Multi",
            "ARC"});
            this.cBox_mode.Location = new System.Drawing.Point(6, 19);
            this.cBox_mode.Name = "cBox_mode";
            this.cBox_mode.Size = new System.Drawing.Size(248, 21);
            this.cBox_mode.TabIndex = 0;
            this.cBox_mode.SelectedIndexChanged += new System.EventHandler(this.cBox_mode_SelectedIndexChanged);
            // 
            // gBox_mode
            // 
            this.gBox_mode.Controls.Add(this.cBox_mode);
            this.gBox_mode.Location = new System.Drawing.Point(12, 12);
            this.gBox_mode.Name = "gBox_mode";
            this.gBox_mode.Size = new System.Drawing.Size(260, 49);
            this.gBox_mode.TabIndex = 1;
            this.gBox_mode.TabStop = false;
            this.gBox_mode.Text = "Mode";
            // 
            // gBox_single
            // 
            this.gBox_single.Controls.Add(this.lbl_single_heightVal);
            this.gBox_single.Controls.Add(this.nUD_single_heightVal);
            this.gBox_single.Location = new System.Drawing.Point(12, 67);
            this.gBox_single.Name = "gBox_single";
            this.gBox_single.Size = new System.Drawing.Size(260, 182);
            this.gBox_single.TabIndex = 2;
            this.gBox_single.TabStop = false;
            this.gBox_single.Text = "Single Mode";
            this.gBox_single.Visible = false;
            // 
            // lbl_single_heightVal
            // 
            this.lbl_single_heightVal.AutoSize = true;
            this.lbl_single_heightVal.Location = new System.Drawing.Point(6, 21);
            this.lbl_single_heightVal.Name = "lbl_single_heightVal";
            this.lbl_single_heightVal.Size = new System.Drawing.Size(71, 13);
            this.lbl_single_heightVal.TabIndex = 1;
            this.lbl_single_heightVal.Text = "Height Value:";
            // 
            // nUD_single_heightVal
            // 
            this.nUD_single_heightVal.DecimalPlaces = 5;
            this.nUD_single_heightVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_single_heightVal.Location = new System.Drawing.Point(83, 19);
            this.nUD_single_heightVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_single_heightVal.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_single_heightVal.Name = "nUD_single_heightVal";
            this.nUD_single_heightVal.Size = new System.Drawing.Size(171, 20);
            this.nUD_single_heightVal.TabIndex = 0;
            this.nUD_single_heightVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_single_heightVal.ValueChanged += new System.EventHandler(this.nUD_single_heightVal_ValueChanged);
            // 
            // gBox_multi
            // 
            this.gBox_multi.Controls.Add(this.lbl_multi_heightE);
            this.gBox_multi.Controls.Add(this.nUD_multi_heightE);
            this.gBox_multi.Controls.Add(this.lbl_multi_heightS);
            this.gBox_multi.Controls.Add(this.nUD_multi_heightS);
            this.gBox_multi.Location = new System.Drawing.Point(12, 67);
            this.gBox_multi.Name = "gBox_multi";
            this.gBox_multi.Size = new System.Drawing.Size(260, 182);
            this.gBox_multi.TabIndex = 3;
            this.gBox_multi.TabStop = false;
            this.gBox_multi.Text = "Multi Mode";
            this.gBox_multi.Visible = false;
            // 
            // lbl_multi_heightE
            // 
            this.lbl_multi_heightE.AutoSize = true;
            this.lbl_multi_heightE.Location = new System.Drawing.Point(6, 47);
            this.lbl_multi_heightE.Name = "lbl_multi_heightE";
            this.lbl_multi_heightE.Size = new System.Drawing.Size(93, 13);
            this.lbl_multi_heightE.TabIndex = 5;
            this.lbl_multi_heightE.Text = "Height End Value:";
            // 
            // nUD_multi_heightE
            // 
            this.nUD_multi_heightE.DecimalPlaces = 5;
            this.nUD_multi_heightE.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_multi_heightE.Location = new System.Drawing.Point(108, 45);
            this.nUD_multi_heightE.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_multi_heightE.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_multi_heightE.Name = "nUD_multi_heightE";
            this.nUD_multi_heightE.Size = new System.Drawing.Size(146, 20);
            this.nUD_multi_heightE.TabIndex = 4;
            this.nUD_multi_heightE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_multi_heightE.ValueChanged += new System.EventHandler(this.nUD_multi_heightE_ValueChanged);
            // 
            // lbl_multi_heightS
            // 
            this.lbl_multi_heightS.AutoSize = true;
            this.lbl_multi_heightS.Location = new System.Drawing.Point(6, 21);
            this.lbl_multi_heightS.Name = "lbl_multi_heightS";
            this.lbl_multi_heightS.Size = new System.Drawing.Size(96, 13);
            this.lbl_multi_heightS.TabIndex = 3;
            this.lbl_multi_heightS.Text = "Height Start Value:";
            // 
            // nUD_multi_heightS
            // 
            this.nUD_multi_heightS.DecimalPlaces = 5;
            this.nUD_multi_heightS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_multi_heightS.Location = new System.Drawing.Point(108, 19);
            this.nUD_multi_heightS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_multi_heightS.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_multi_heightS.Name = "nUD_multi_heightS";
            this.nUD_multi_heightS.Size = new System.Drawing.Size(146, 20);
            this.nUD_multi_heightS.TabIndex = 2;
            this.nUD_multi_heightS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_multi_heightS.ValueChanged += new System.EventHandler(this.nUD_multi_heightS_ValueChanged);
            // 
            // gBox_arc
            // 
            this.gBox_arc.Controls.Add(this.lbl_arc_sagitta);
            this.gBox_arc.Controls.Add(this.nUD_arc_sagitta);
            this.gBox_arc.Controls.Add(this.lbl_arc_FinalPoint);
            this.gBox_arc.Controls.Add(this.nUD_arc_finalPoint);
            this.gBox_arc.Controls.Add(this.lbl_arc_heightS);
            this.gBox_arc.Controls.Add(this.nUD_arc_heightS);
            this.gBox_arc.Location = new System.Drawing.Point(12, 67);
            this.gBox_arc.Name = "gBox_arc";
            this.gBox_arc.Size = new System.Drawing.Size(260, 182);
            this.gBox_arc.TabIndex = 4;
            this.gBox_arc.TabStop = false;
            this.gBox_arc.Text = "ARC Mode";
            this.gBox_arc.Visible = false;
            // 
            // btn_apply
            // 
            this.btn_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_apply.Location = new System.Drawing.Point(12, 255);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(119, 23);
            this.btn_apply.TabIndex = 5;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(153, 255);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(119, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_arc_heightS
            // 
            this.lbl_arc_heightS.AutoSize = true;
            this.lbl_arc_heightS.Location = new System.Drawing.Point(6, 21);
            this.lbl_arc_heightS.Name = "lbl_arc_heightS";
            this.lbl_arc_heightS.Size = new System.Drawing.Size(96, 13);
            this.lbl_arc_heightS.TabIndex = 5;
            this.lbl_arc_heightS.Text = "Height Start Value:";
            // 
            // nUD_arc_heightS
            // 
            this.nUD_arc_heightS.DecimalPlaces = 5;
            this.nUD_arc_heightS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_arc_heightS.Location = new System.Drawing.Point(108, 19);
            this.nUD_arc_heightS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_arc_heightS.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_arc_heightS.Name = "nUD_arc_heightS";
            this.nUD_arc_heightS.Size = new System.Drawing.Size(146, 20);
            this.nUD_arc_heightS.TabIndex = 4;
            this.nUD_arc_heightS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arc_heightS.ValueChanged += new System.EventHandler(this.nUD_arc_heightS_ValueChanged);
            // 
            // lbl_arc_FinalPoint
            // 
            this.lbl_arc_FinalPoint.AutoSize = true;
            this.lbl_arc_FinalPoint.Enabled = false;
            this.lbl_arc_FinalPoint.Location = new System.Drawing.Point(6, 47);
            this.lbl_arc_FinalPoint.Name = "lbl_arc_FinalPoint";
            this.lbl_arc_FinalPoint.Size = new System.Drawing.Size(59, 13);
            this.lbl_arc_FinalPoint.TabIndex = 7;
            this.lbl_arc_FinalPoint.Text = "Final Point:";
            // 
            // nUD_arc_finalPoint
            // 
            this.nUD_arc_finalPoint.Enabled = false;
            this.nUD_arc_finalPoint.Location = new System.Drawing.Point(108, 45);
            this.nUD_arc_finalPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_arc_finalPoint.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_arc_finalPoint.Name = "nUD_arc_finalPoint";
            this.nUD_arc_finalPoint.Size = new System.Drawing.Size(146, 20);
            this.nUD_arc_finalPoint.TabIndex = 6;
            this.nUD_arc_finalPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arc_finalPoint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_arc_finalPoint.ValueChanged += new System.EventHandler(this.nUD_arc_finalPoint_ValueChanged);
            // 
            // lbl_arc_sagitta
            // 
            this.lbl_arc_sagitta.AutoSize = true;
            this.lbl_arc_sagitta.Location = new System.Drawing.Point(6, 73);
            this.lbl_arc_sagitta.Name = "lbl_arc_sagitta";
            this.lbl_arc_sagitta.Size = new System.Drawing.Size(73, 13);
            this.lbl_arc_sagitta.TabIndex = 9;
            this.lbl_arc_sagitta.Text = "Sagitta Value:";
            // 
            // nUD_arc_sagitta
            // 
            this.nUD_arc_sagitta.DecimalPlaces = 1;
            this.nUD_arc_sagitta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUD_arc_sagitta.Location = new System.Drawing.Point(108, 71);
            this.nUD_arc_sagitta.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUD_arc_sagitta.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nUD_arc_sagitta.Name = "nUD_arc_sagitta";
            this.nUD_arc_sagitta.Size = new System.Drawing.Size(146, 20);
            this.nUD_arc_sagitta.TabIndex = 8;
            this.nUD_arc_sagitta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arc_sagitta.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUD_arc_sagitta.ValueChanged += new System.EventHandler(this.nUD_arc_sagitta_ValueChanged);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 285);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.gBox_arc);
            this.Controls.Add(this.gBox_single);
            this.Controls.Add(this.gBox_multi);
            this.Controls.Add(this.gBox_mode);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Editor";
            this.ShowIcon = false;
            this.Text = "Editor";
            this.gBox_mode.ResumeLayout(false);
            this.gBox_single.ResumeLayout(false);
            this.gBox_single.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_single_heightVal)).EndInit();
            this.gBox_multi.ResumeLayout(false);
            this.gBox_multi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_multi_heightE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_multi_heightS)).EndInit();
            this.gBox_arc.ResumeLayout(false);
            this.gBox_arc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_heightS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_finalPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_sagitta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBox_mode;
        private System.Windows.Forms.GroupBox gBox_mode;
        private System.Windows.Forms.GroupBox gBox_single;
        private System.Windows.Forms.GroupBox gBox_multi;
        private System.Windows.Forms.GroupBox gBox_arc;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_single_heightVal;
        private System.Windows.Forms.NumericUpDown nUD_single_heightVal;
        private System.Windows.Forms.Label lbl_multi_heightE;
        private System.Windows.Forms.NumericUpDown nUD_multi_heightE;
        private System.Windows.Forms.Label lbl_multi_heightS;
        private System.Windows.Forms.NumericUpDown nUD_multi_heightS;
        private System.Windows.Forms.Label lbl_arc_heightS;
        private System.Windows.Forms.NumericUpDown nUD_arc_heightS;
        private System.Windows.Forms.Label lbl_arc_FinalPoint;
        private System.Windows.Forms.NumericUpDown nUD_arc_finalPoint;
        private System.Windows.Forms.Label lbl_arc_sagitta;
        private System.Windows.Forms.NumericUpDown nUD_arc_sagitta;
    }
}