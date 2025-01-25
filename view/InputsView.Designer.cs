namespace ReuseSchemeTool.view
{
    partial class InputsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputsView));
            this.clbSectionTypes = new System.Windows.Forms.CheckedListBox();
            this.prgbProgress = new System.Windows.Forms.ProgressBar();
            this.trbMinLength = new System.Windows.Forms.TrackBar();
            this.trbMaxLength = new System.Windows.Forms.TrackBar();
            this.lblProgrBar = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblSectionTypes = new System.Windows.Forms.Label();
            this.lblSteelGrades = new System.Windows.Forms.Label();
            this.clbSteelGrades = new System.Windows.Forms.CheckedListBox();
            this.lblMinLength = new System.Windows.Forms.Label();
            this.lblMaxLength = new System.Windows.Forms.Label();
            this.trbMinWeight = new System.Windows.Forms.TrackBar();
            this.trbMaxWeight = new System.Windows.Forms.TrackBar();
            this.lblMinWeight = new System.Windows.Forms.Label();
            this.lblMaxWeight = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMinLengthValue = new System.Windows.Forms.Label();
            this.lblMaxLengthValue = new System.Windows.Forms.Label();
            this.lblMinWeightValue = new System.Windows.Forms.Label();
            this.lblMaxWeightValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // clbSectionTypes
            // 
            this.clbSectionTypes.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbSectionTypes.FormattingEnabled = true;
            this.clbSectionTypes.Items.AddRange(new object[] {
            "CHS",
            "PFC",
            "RHS",
            "SHS",
            "UB",
            "UC"});
            this.clbSectionTypes.Location = new System.Drawing.Point(26, 113);
            this.clbSectionTypes.Name = "clbSectionTypes";
            this.clbSectionTypes.Size = new System.Drawing.Size(149, 104);
            this.clbSectionTypes.TabIndex = 0;
            // 
            // prgbProgress
            // 
            this.prgbProgress.Location = new System.Drawing.Point(26, 643);
            this.prgbProgress.Name = "prgbProgress";
            this.prgbProgress.Size = new System.Drawing.Size(323, 32);
            this.prgbProgress.TabIndex = 1;
            // 
            // trbMinLength
            // 
            this.trbMinLength.Location = new System.Drawing.Point(26, 267);
            this.trbMinLength.Maximum = 6;
            this.trbMinLength.Minimum = 2;
            this.trbMinLength.Name = "trbMinLength";
            this.trbMinLength.Size = new System.Drawing.Size(257, 56);
            this.trbMinLength.TabIndex = 2;
            this.trbMinLength.Value = 2;
            // 
            // trbMaxLength
            // 
            this.trbMaxLength.BackColor = System.Drawing.SystemColors.Control;
            this.trbMaxLength.Location = new System.Drawing.Point(26, 338);
            this.trbMaxLength.Maximum = 18;
            this.trbMaxLength.Minimum = 6;
            this.trbMaxLength.Name = "trbMaxLength";
            this.trbMaxLength.Size = new System.Drawing.Size(257, 56);
            this.trbMaxLength.TabIndex = 3;
            this.trbMaxLength.Value = 6;
            // 
            // lblProgrBar
            // 
            this.lblProgrBar.AutoSize = true;
            this.lblProgrBar.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgrBar.Location = new System.Drawing.Point(23, 615);
            this.lblProgrBar.Name = "lblProgrBar";
            this.lblProgrBar.Size = new System.Drawing.Size(135, 17);
            this.lblProgrBar.TabIndex = 29;
            this.lblProgrBar.Text = "Iteration in Progress...";
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(125, 545);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(141, 47);
            this.btnRun.TabIndex = 30;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // lblSectionTypes
            // 
            this.lblSectionTypes.AutoSize = true;
            this.lblSectionTypes.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionTypes.Location = new System.Drawing.Point(47, 93);
            this.lblSectionTypes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSectionTypes.Name = "lblSectionTypes";
            this.lblSectionTypes.Size = new System.Drawing.Size(99, 17);
            this.lblSectionTypes.TabIndex = 36;
            this.lblSectionTypes.Text = "SECTION TYPES";
            // 
            // lblSteelGrades
            // 
            this.lblSteelGrades.AutoSize = true;
            this.lblSteelGrades.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteelGrades.Location = new System.Drawing.Point(224, 93);
            this.lblSteelGrades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteelGrades.Name = "lblSteelGrades";
            this.lblSteelGrades.Size = new System.Drawing.Size(94, 17);
            this.lblSteelGrades.TabIndex = 38;
            this.lblSteelGrades.Text = "STEEL GRADES";
            // 
            // clbSteelGrades
            // 
            this.clbSteelGrades.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbSteelGrades.FormattingEnabled = true;
            this.clbSteelGrades.Items.AddRange(new object[] {
            "S455",
            "S355",
            "S275",
            "S235",
            "Steel",
            "UNKNOWN"});
            this.clbSteelGrades.Location = new System.Drawing.Point(200, 113);
            this.clbSteelGrades.Name = "clbSteelGrades";
            this.clbSteelGrades.Size = new System.Drawing.Size(149, 104);
            this.clbSteelGrades.TabIndex = 37;
            // 
            // lblMinLength
            // 
            this.lblMinLength.AutoSize = true;
            this.lblMinLength.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinLength.Location = new System.Drawing.Point(92, 247);
            this.lblMinLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinLength.Name = "lblMinLength";
            this.lblMinLength.Size = new System.Drawing.Size(144, 17);
            this.lblMinLength.TabIndex = 39;
            this.lblMinLength.Text = "MINIMUM LENGTH [m]";
            // 
            // lblMaxLength
            // 
            this.lblMaxLength.AutoSize = true;
            this.lblMaxLength.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLength.Location = new System.Drawing.Point(92, 318);
            this.lblMaxLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(147, 17);
            this.lblMaxLength.TabIndex = 40;
            this.lblMaxLength.Text = "MAXIMUM LENGTH [m]";
            // 
            // trbMinWeight
            // 
            this.trbMinWeight.LargeChange = 10;
            this.trbMinWeight.Location = new System.Drawing.Point(26, 409);
            this.trbMinWeight.Maximum = 100;
            this.trbMinWeight.Minimum = 10;
            this.trbMinWeight.Name = "trbMinWeight";
            this.trbMinWeight.Size = new System.Drawing.Size(257, 56);
            this.trbMinWeight.SmallChange = 5;
            this.trbMinWeight.TabIndex = 41;
            this.trbMinWeight.Value = 10;
            // 
            // trbMaxWeight
            // 
            this.trbMaxWeight.LargeChange = 100;
            this.trbMaxWeight.Location = new System.Drawing.Point(26, 480);
            this.trbMaxWeight.Maximum = 800;
            this.trbMaxWeight.Minimum = 100;
            this.trbMaxWeight.Name = "trbMaxWeight";
            this.trbMaxWeight.Size = new System.Drawing.Size(257, 56);
            this.trbMaxWeight.SmallChange = 25;
            this.trbMaxWeight.TabIndex = 42;
            this.trbMaxWeight.Value = 100;
            // 
            // lblMinWeight
            // 
            this.lblMinWeight.AutoSize = true;
            this.lblMinWeight.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinWeight.Location = new System.Drawing.Point(92, 389);
            this.lblMinWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinWeight.Name = "lblMinWeight";
            this.lblMinWeight.Size = new System.Drawing.Size(146, 17);
            this.lblMinWeight.TabIndex = 43;
            this.lblMinWeight.Text = "MINIMUM WEIGHT [kg]";
            // 
            // lblMaxWeight
            // 
            this.lblMaxWeight.AutoSize = true;
            this.lblMaxWeight.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxWeight.Location = new System.Drawing.Point(92, 460);
            this.lblMaxWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(149, 17);
            this.lblMaxWeight.TabIndex = 44;
            this.lblMaxWeight.Text = "MAXIMUM WEIGHT [kg]";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(30, 23);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(319, 70);
            this.lblDescription.TabIndex = 45;
            this.lblDescription.Text = "Select Section Type, Steel Grade as well as range of lengths and weights that are" +
    " acceptable for reuse purposes.";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMinLengthValue
            // 
            this.lblMinLengthValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblMinLengthValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinLengthValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinLengthValue.Location = new System.Drawing.Point(289, 267);
            this.lblMinLengthValue.Name = "lblMinLengthValue";
            this.lblMinLengthValue.Size = new System.Drawing.Size(60, 24);
            this.lblMinLengthValue.TabIndex = 50;
            this.lblMinLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxLengthValue
            // 
            this.lblMaxLengthValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblMaxLengthValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaxLengthValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLengthValue.Location = new System.Drawing.Point(289, 338);
            this.lblMaxLengthValue.Name = "lblMaxLengthValue";
            this.lblMaxLengthValue.Size = new System.Drawing.Size(60, 24);
            this.lblMaxLengthValue.TabIndex = 51;
            this.lblMaxLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinWeightValue
            // 
            this.lblMinWeightValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblMinWeightValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinWeightValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinWeightValue.Location = new System.Drawing.Point(289, 409);
            this.lblMinWeightValue.Name = "lblMinWeightValue";
            this.lblMinWeightValue.Size = new System.Drawing.Size(60, 24);
            this.lblMinWeightValue.TabIndex = 52;
            this.lblMinWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxWeightValue
            // 
            this.lblMaxWeightValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblMaxWeightValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaxWeightValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxWeightValue.Location = new System.Drawing.Point(289, 480);
            this.lblMaxWeightValue.Name = "lblMaxWeightValue";
            this.lblMaxWeightValue.Size = new System.Drawing.Size(60, 24);
            this.lblMaxWeightValue.TabIndex = 53;
            this.lblMaxWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InputsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 706);
            this.Controls.Add(this.lblMaxWeightValue);
            this.Controls.Add(this.lblMinWeightValue);
            this.Controls.Add(this.lblMaxLengthValue);
            this.Controls.Add(this.lblMinLengthValue);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblMaxWeight);
            this.Controls.Add(this.lblMinWeight);
            this.Controls.Add(this.trbMaxWeight);
            this.Controls.Add(this.trbMinWeight);
            this.Controls.Add(this.lblMaxLength);
            this.Controls.Add(this.lblMinLength);
            this.Controls.Add(this.lblSteelGrades);
            this.Controls.Add(this.clbSteelGrades);
            this.Controls.Add(this.lblSectionTypes);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblProgrBar);
            this.Controls.Add(this.trbMaxLength);
            this.Controls.Add(this.trbMinLength);
            this.Controls.Add(this.prgbProgress);
            this.Controls.Add(this.clbSectionTypes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InputsView";
            this.Text = "InputsView";
            ((System.ComponentModel.ISupportInitialize)(this.trbMinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckedListBox clbSectionTypes;
        public System.Windows.Forms.ProgressBar prgbProgress;
        public System.Windows.Forms.TrackBar trbMinLength;
        public System.Windows.Forms.TrackBar trbMaxLength;
        internal System.Windows.Forms.Label lblProgrBar;
        public System.Windows.Forms.Button btnRun;
        internal System.Windows.Forms.Label lblSectionTypes;
        internal System.Windows.Forms.Label lblSteelGrades;
        public System.Windows.Forms.CheckedListBox clbSteelGrades;
        internal System.Windows.Forms.Label lblMinLength;
        internal System.Windows.Forms.Label lblMaxLength;
        public System.Windows.Forms.TrackBar trbMinWeight;
        public System.Windows.Forms.TrackBar trbMaxWeight;
        internal System.Windows.Forms.Label lblMinWeight;
        internal System.Windows.Forms.Label lblMaxWeight;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.Label lblMinLengthValue;
        public System.Windows.Forms.Label lblMaxLengthValue;
        public System.Windows.Forms.Label lblMinWeightValue;
        public System.Windows.Forms.Label lblMaxWeightValue;
    }
}