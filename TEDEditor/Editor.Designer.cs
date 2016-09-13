namespace TEDEditor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.rTBox_arcH = new System.Windows.Forms.RichTextBox();
            this.lbl_arc_sagitta = new System.Windows.Forms.Label();
            this.nUD_arc_sagitta = new System.Windows.Forms.NumericUpDown();
            this.lbl_arc_FinalPoint = new System.Windows.Forms.Label();
            this.nUD_arc_finalPoint = new System.Windows.Forms.NumericUpDown();
            this.lbl_arc_heightS = new System.Windows.Forms.Label();
            this.nUD_arc_heightS = new System.Windows.Forms.NumericUpDown();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.gBox_arcV = new System.Windows.Forms.GroupBox();
            this.lbl_arcV_heightE = new System.Windows.Forms.Label();
            this.nUD_arcV_heightE = new System.Windows.Forms.NumericUpDown();
            this.lbl_arcV_sagitta = new System.Windows.Forms.Label();
            this.nUD_arcV_sagitta = new System.Windows.Forms.NumericUpDown();
            this.lbl_arcV_FinalPoint = new System.Windows.Forms.Label();
            this.nUD_arcV_finalPoint = new System.Windows.Forms.NumericUpDown();
            this.lbl_arcV_heightS = new System.Windows.Forms.Label();
            this.nUD_arcV_heightS = new System.Windows.Forms.NumericUpDown();
            this.chart_preview = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_edit = new System.Windows.Forms.Panel();
            this.tBar_zoom = new System.Windows.Forms.TrackBar();
            this.gBox_mode.SuspendLayout();
            this.gBox_single.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_single_heightVal)).BeginInit();
            this.gBox_multi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_multi_heightE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_multi_heightS)).BeginInit();
            this.gBox_arc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_sagitta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_finalPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_heightS)).BeginInit();
            this.gBox_arcV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_heightE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_sagitta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_finalPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_heightS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_preview)).BeginInit();
            this.panel_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_zoom)).BeginInit();
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
            "ARC Horizontal"});
            this.cBox_mode.Location = new System.Drawing.Point(6, 19);
            this.cBox_mode.Name = "cBox_mode";
            this.cBox_mode.Size = new System.Drawing.Size(316, 21);
            this.cBox_mode.TabIndex = 0;
            this.cBox_mode.SelectedIndexChanged += new System.EventHandler(this.cBox_mode_SelectedIndexChanged);
            // 
            // gBox_mode
            // 
            this.gBox_mode.Controls.Add(this.cBox_mode);
            this.gBox_mode.Location = new System.Drawing.Point(3, 3);
            this.gBox_mode.Name = "gBox_mode";
            this.gBox_mode.Size = new System.Drawing.Size(328, 49);
            this.gBox_mode.TabIndex = 1;
            this.gBox_mode.TabStop = false;
            this.gBox_mode.Text = "Mode";
            // 
            // gBox_single
            // 
            this.gBox_single.Controls.Add(this.lbl_single_heightVal);
            this.gBox_single.Controls.Add(this.nUD_single_heightVal);
            this.gBox_single.Location = new System.Drawing.Point(3, 57);
            this.gBox_single.Name = "gBox_single";
            this.gBox_single.Size = new System.Drawing.Size(328, 182);
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
            this.nUD_single_heightVal.Size = new System.Drawing.Size(239, 20);
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
            this.gBox_multi.Location = new System.Drawing.Point(3, 57);
            this.gBox_multi.Name = "gBox_multi";
            this.gBox_multi.Size = new System.Drawing.Size(328, 182);
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
            this.nUD_multi_heightE.Size = new System.Drawing.Size(214, 20);
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
            this.nUD_multi_heightS.Size = new System.Drawing.Size(214, 20);
            this.nUD_multi_heightS.TabIndex = 2;
            this.nUD_multi_heightS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_multi_heightS.ValueChanged += new System.EventHandler(this.nUD_multi_heightS_ValueChanged);
            // 
            // gBox_arc
            // 
            this.gBox_arc.Controls.Add(this.rTBox_arcH);
            this.gBox_arc.Controls.Add(this.lbl_arc_sagitta);
            this.gBox_arc.Controls.Add(this.nUD_arc_sagitta);
            this.gBox_arc.Controls.Add(this.lbl_arc_FinalPoint);
            this.gBox_arc.Controls.Add(this.nUD_arc_finalPoint);
            this.gBox_arc.Controls.Add(this.lbl_arc_heightS);
            this.gBox_arc.Controls.Add(this.nUD_arc_heightS);
            this.gBox_arc.Location = new System.Drawing.Point(3, 57);
            this.gBox_arc.Name = "gBox_arc";
            this.gBox_arc.Size = new System.Drawing.Size(328, 182);
            this.gBox_arc.TabIndex = 4;
            this.gBox_arc.TabStop = false;
            this.gBox_arc.Text = "ARC Mode";
            this.gBox_arc.Visible = false;
            // 
            // rTBox_arcH
            // 
            this.rTBox_arcH.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBox_arcH.Location = new System.Drawing.Point(6, 99);
            this.rTBox_arcH.Name = "rTBox_arcH";
            this.rTBox_arcH.ReadOnly = true;
            this.rTBox_arcH.Size = new System.Drawing.Size(316, 77);
            this.rTBox_arcH.TabIndex = 10;
            this.rTBox_arcH.Text = "";
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
            this.nUD_arc_sagitta.Location = new System.Drawing.Point(108, 72);
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
            this.nUD_arc_sagitta.Size = new System.Drawing.Size(214, 20);
            this.nUD_arc_sagitta.TabIndex = 8;
            this.nUD_arc_sagitta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arc_sagitta.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUD_arc_sagitta.ValueChanged += new System.EventHandler(this.nUD_arc_sagitta_ValueChanged);
            // 
            // lbl_arc_FinalPoint
            // 
            this.lbl_arc_FinalPoint.AutoSize = true;
            this.lbl_arc_FinalPoint.Location = new System.Drawing.Point(6, 47);
            this.lbl_arc_FinalPoint.Name = "lbl_arc_FinalPoint";
            this.lbl_arc_FinalPoint.Size = new System.Drawing.Size(59, 13);
            this.lbl_arc_FinalPoint.TabIndex = 7;
            this.lbl_arc_FinalPoint.Text = "Final Point:";
            // 
            // nUD_arc_finalPoint
            // 
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
            this.nUD_arc_finalPoint.Size = new System.Drawing.Size(214, 20);
            this.nUD_arc_finalPoint.TabIndex = 6;
            this.nUD_arc_finalPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arc_finalPoint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_arc_finalPoint.ValueChanged += new System.EventHandler(this.nUD_arc_finalPoint_ValueChanged);
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
            this.nUD_arc_heightS.Size = new System.Drawing.Size(214, 20);
            this.nUD_arc_heightS.TabIndex = 4;
            this.nUD_arc_heightS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arc_heightS.ValueChanged += new System.EventHandler(this.nUD_arc_heightS_ValueChanged);
            // 
            // btn_apply
            // 
            this.btn_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_apply.Location = new System.Drawing.Point(3, 246);
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
            this.btn_cancel.Location = new System.Drawing.Point(212, 245);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(119, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // gBox_arcV
            // 
            this.gBox_arcV.Controls.Add(this.lbl_arcV_heightE);
            this.gBox_arcV.Controls.Add(this.nUD_arcV_heightE);
            this.gBox_arcV.Controls.Add(this.lbl_arcV_sagitta);
            this.gBox_arcV.Controls.Add(this.nUD_arcV_sagitta);
            this.gBox_arcV.Controls.Add(this.lbl_arcV_FinalPoint);
            this.gBox_arcV.Controls.Add(this.nUD_arcV_finalPoint);
            this.gBox_arcV.Controls.Add(this.lbl_arcV_heightS);
            this.gBox_arcV.Controls.Add(this.nUD_arcV_heightS);
            this.gBox_arcV.Location = new System.Drawing.Point(3, 57);
            this.gBox_arcV.Name = "gBox_arcV";
            this.gBox_arcV.Size = new System.Drawing.Size(328, 182);
            this.gBox_arcV.TabIndex = 10;
            this.gBox_arcV.TabStop = false;
            this.gBox_arcV.Text = "ARC Vertical Mode";
            this.gBox_arcV.Visible = false;
            // 
            // lbl_arcV_heightE
            // 
            this.lbl_arcV_heightE.AutoSize = true;
            this.lbl_arcV_heightE.Location = new System.Drawing.Point(6, 47);
            this.lbl_arcV_heightE.Name = "lbl_arcV_heightE";
            this.lbl_arcV_heightE.Size = new System.Drawing.Size(96, 13);
            this.lbl_arcV_heightE.TabIndex = 11;
            this.lbl_arcV_heightE.Text = "Height Start Value:";
            // 
            // nUD_arcV_heightE
            // 
            this.nUD_arcV_heightE.DecimalPlaces = 5;
            this.nUD_arcV_heightE.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_arcV_heightE.Location = new System.Drawing.Point(108, 45);
            this.nUD_arcV_heightE.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_arcV_heightE.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_arcV_heightE.Name = "nUD_arcV_heightE";
            this.nUD_arcV_heightE.Size = new System.Drawing.Size(214, 20);
            this.nUD_arcV_heightE.TabIndex = 10;
            this.nUD_arcV_heightE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arcV_heightE.ValueChanged += new System.EventHandler(this.nUD_arcV_heightE_ValueChanged);
            // 
            // lbl_arcV_sagitta
            // 
            this.lbl_arcV_sagitta.AutoSize = true;
            this.lbl_arcV_sagitta.Location = new System.Drawing.Point(6, 99);
            this.lbl_arcV_sagitta.Name = "lbl_arcV_sagitta";
            this.lbl_arcV_sagitta.Size = new System.Drawing.Size(73, 13);
            this.lbl_arcV_sagitta.TabIndex = 9;
            this.lbl_arcV_sagitta.Text = "Sagitta Value:";
            // 
            // nUD_arcV_sagitta
            // 
            this.nUD_arcV_sagitta.DecimalPlaces = 1;
            this.nUD_arcV_sagitta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUD_arcV_sagitta.Location = new System.Drawing.Point(108, 97);
            this.nUD_arcV_sagitta.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUD_arcV_sagitta.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nUD_arcV_sagitta.Name = "nUD_arcV_sagitta";
            this.nUD_arcV_sagitta.Size = new System.Drawing.Size(214, 20);
            this.nUD_arcV_sagitta.TabIndex = 8;
            this.nUD_arcV_sagitta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arcV_sagitta.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUD_arcV_sagitta.ValueChanged += new System.EventHandler(this.nUD_arcV_sagitta_ValueChanged);
            // 
            // lbl_arcV_FinalPoint
            // 
            this.lbl_arcV_FinalPoint.AutoSize = true;
            this.lbl_arcV_FinalPoint.Location = new System.Drawing.Point(6, 74);
            this.lbl_arcV_FinalPoint.Name = "lbl_arcV_FinalPoint";
            this.lbl_arcV_FinalPoint.Size = new System.Drawing.Size(59, 13);
            this.lbl_arcV_FinalPoint.TabIndex = 7;
            this.lbl_arcV_FinalPoint.Text = "Final Point:";
            // 
            // nUD_arcV_finalPoint
            // 
            this.nUD_arcV_finalPoint.Location = new System.Drawing.Point(108, 71);
            this.nUD_arcV_finalPoint.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_arcV_finalPoint.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_arcV_finalPoint.Name = "nUD_arcV_finalPoint";
            this.nUD_arcV_finalPoint.Size = new System.Drawing.Size(214, 20);
            this.nUD_arcV_finalPoint.TabIndex = 6;
            this.nUD_arcV_finalPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arcV_finalPoint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD_arcV_finalPoint.ValueChanged += new System.EventHandler(this.nUD_arcV_finalPoint_ValueChanged);
            // 
            // lbl_arcV_heightS
            // 
            this.lbl_arcV_heightS.AutoSize = true;
            this.lbl_arcV_heightS.Location = new System.Drawing.Point(6, 21);
            this.lbl_arcV_heightS.Name = "lbl_arcV_heightS";
            this.lbl_arcV_heightS.Size = new System.Drawing.Size(96, 13);
            this.lbl_arcV_heightS.TabIndex = 5;
            this.lbl_arcV_heightS.Text = "Height Start Value:";
            // 
            // nUD_arcV_heightS
            // 
            this.nUD_arcV_heightS.DecimalPlaces = 5;
            this.nUD_arcV_heightS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_arcV_heightS.Location = new System.Drawing.Point(108, 19);
            this.nUD_arcV_heightS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_arcV_heightS.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUD_arcV_heightS.Name = "nUD_arcV_heightS";
            this.nUD_arcV_heightS.Size = new System.Drawing.Size(214, 20);
            this.nUD_arcV_heightS.TabIndex = 4;
            this.nUD_arcV_heightS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUD_arcV_heightS.ValueChanged += new System.EventHandler(this.nUD_arcV_heightS_ValueChanged);
            // 
            // chart_preview
            // 
            chartArea6.Name = "ChartArea1";
            this.chart_preview.ChartAreas.Add(chartArea6);
            this.chart_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chart_preview.Legends.Add(legend6);
            this.chart_preview.Location = new System.Drawing.Point(337, 45);
            this.chart_preview.Name = "chart_preview";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series11.Legend = "Legend1";
            series11.Name = "Elevation Points";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series12.Legend = "Legend1";
            series12.Name = "Elevation Line";
            this.chart_preview.Series.Add(series11);
            this.chart_preview.Series.Add(series12);
            this.chart_preview.Size = new System.Drawing.Size(806, 234);
            this.chart_preview.TabIndex = 11;
            this.chart_preview.Text = "chart1";
            // 
            // panel_edit
            // 
            this.panel_edit.Controls.Add(this.gBox_arc);
            this.panel_edit.Controls.Add(this.gBox_multi);
            this.panel_edit.Controls.Add(this.gBox_single);
            this.panel_edit.Controls.Add(this.gBox_arcV);
            this.panel_edit.Controls.Add(this.gBox_mode);
            this.panel_edit.Controls.Add(this.btn_apply);
            this.panel_edit.Controls.Add(this.btn_cancel);
            this.panel_edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_edit.Location = new System.Drawing.Point(0, 0);
            this.panel_edit.Name = "panel_edit";
            this.panel_edit.Size = new System.Drawing.Size(337, 279);
            this.panel_edit.TabIndex = 12;
            // 
            // tBar_zoom
            // 
            this.tBar_zoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.tBar_zoom.Location = new System.Drawing.Point(337, 0);
            this.tBar_zoom.Maximum = 5000;
            this.tBar_zoom.Minimum = -5000;
            this.tBar_zoom.Name = "tBar_zoom";
            this.tBar_zoom.Size = new System.Drawing.Size(806, 45);
            this.tBar_zoom.TabIndex = 13;
            this.tBar_zoom.Visible = false;
            this.tBar_zoom.Scroll += new System.EventHandler(this.tBar_zoom_Scroll);
            this.tBar_zoom.ValueChanged += new System.EventHandler(this.tBar_zoom_ValueChanged);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 279);
            this.Controls.Add(this.chart_preview);
            this.Controls.Add(this.tBar_zoom);
            this.Controls.Add(this.panel_edit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
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
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_sagitta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_finalPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arc_heightS)).EndInit();
            this.gBox_arcV.ResumeLayout(false);
            this.gBox_arcV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_heightE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_sagitta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_finalPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_arcV_heightS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_preview)).EndInit();
            this.panel_edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tBar_zoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox gBox_arcV;
        private System.Windows.Forms.Label lbl_arcV_sagitta;
        private System.Windows.Forms.NumericUpDown nUD_arcV_sagitta;
        private System.Windows.Forms.Label lbl_arcV_FinalPoint;
        private System.Windows.Forms.NumericUpDown nUD_arcV_finalPoint;
        private System.Windows.Forms.Label lbl_arcV_heightS;
        private System.Windows.Forms.NumericUpDown nUD_arcV_heightS;
        private System.Windows.Forms.Label lbl_arcV_heightE;
        private System.Windows.Forms.NumericUpDown nUD_arcV_heightE;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_preview;
        private System.Windows.Forms.Panel panel_edit;
        private System.Windows.Forms.RichTextBox rTBox_arcH;
        private System.Windows.Forms.TrackBar tBar_zoom;
    }
}