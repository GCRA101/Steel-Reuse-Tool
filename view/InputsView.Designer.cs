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
            this.trbMinLength = new System.Windows.Forms.TrackBar();
            this.trbMaxLength = new System.Windows.Forms.TrackBar();
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
            this.lblCutOffValue = new System.Windows.Forms.Label();
            this.lblCutOff = new System.Windows.Forms.Label();
            this.trbCutOff = new System.Windows.Forms.TrackBar();
            this.fbd_SchemeOuputs = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCutOff)).BeginInit();
            this.SuspendLayout();
            // 
            // clbSectionTypes
            // 
            this.clbSectionTypes.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbSectionTypes.FormattingEnabled = true;
            this.clbSectionTypes.Location = new System.Drawing.Point(27, 113);
            this.clbSectionTypes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbSectionTypes.Name = "clbSectionTypes";
            this.clbSectionTypes.Size = new System.Drawing.Size(149, 104);
            this.clbSectionTypes.TabIndex = 0;
            // 
            // trbMinLength
            // 
            this.trbMinLength.Location = new System.Drawing.Point(33, 267);
            this.trbMinLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.trbMaxLength.Location = new System.Drawing.Point(33, 342);
            this.trbMaxLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trbMaxLength.Maximum = 18;
            this.trbMaxLength.Minimum = 6;
            this.trbMaxLength.Name = "trbMaxLength";
            this.trbMaxLength.Size = new System.Drawing.Size(257, 56);
            this.trbMaxLength.TabIndex = 3;
            this.trbMaxLength.Value = 6;
            // 
            // btnRun
            // 
            this.btnRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(121, 642);
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
            this.lblSectionTypes.Location = new System.Drawing.Point(48, 85);
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
            this.lblSteelGrades.Location = new System.Drawing.Point(225, 85);
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
            this.clbSteelGrades.Location = new System.Drawing.Point(200, 113);
            this.clbSteelGrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.lblMaxLength.Location = new System.Drawing.Point(91, 321);
            this.lblMaxLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(147, 17);
            this.lblMaxLength.TabIndex = 40;
            this.lblMaxLength.Text = "MAXIMUM LENGTH [m]";
            // 
            // trbMinWeight
            // 
            this.trbMinWeight.LargeChange = 10;
            this.trbMinWeight.Location = new System.Drawing.Point(33, 492);
            this.trbMinWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.trbMaxWeight.Location = new System.Drawing.Point(33, 567);
            this.trbMaxWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.lblMinWeight.Location = new System.Drawing.Point(80, 469);
            this.lblMinWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinWeight.Name = "lblMinWeight";
            this.lblMinWeight.Size = new System.Drawing.Size(162, 17);
            this.lblMinWeight.TabIndex = 43;
            this.lblMinWeight.Text = "MINIMUM WEIGHT [kg/m]";
            // 
            // lblMaxWeight
            // 
            this.lblMaxWeight.AutoSize = true;
            this.lblMaxWeight.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxWeight.Location = new System.Drawing.Point(79, 543);
            this.lblMaxWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(165, 17);
            this.lblMaxWeight.TabIndex = 44;
            this.lblMaxWeight.Text = "MAXIMUM WEIGHT [kg/m]";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(29, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(319, 65);
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
            this.lblMinLengthValue.Location = new System.Drawing.Point(296, 267);
            this.lblMinLengthValue.Name = "lblMinLengthValue";
            this.lblMinLengthValue.Size = new System.Drawing.Size(60, 25);
            this.lblMinLengthValue.TabIndex = 50;
            this.lblMinLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxLengthValue
            // 
            this.lblMaxLengthValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblMaxLengthValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaxLengthValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLengthValue.Location = new System.Drawing.Point(296, 342);
            this.lblMaxLengthValue.Name = "lblMaxLengthValue";
            this.lblMaxLengthValue.Size = new System.Drawing.Size(60, 25);
            this.lblMaxLengthValue.TabIndex = 51;
            this.lblMaxLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinWeightValue
            // 
            this.lblMinWeightValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblMinWeightValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinWeightValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinWeightValue.Location = new System.Drawing.Point(296, 492);
            this.lblMinWeightValue.Name = "lblMinWeightValue";
            this.lblMinWeightValue.Size = new System.Drawing.Size(60, 25);
            this.lblMinWeightValue.TabIndex = 52;
            this.lblMinWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxWeightValue
            // 
            this.lblMaxWeightValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblMaxWeightValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaxWeightValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxWeightValue.Location = new System.Drawing.Point(296, 567);
            this.lblMaxWeightValue.Name = "lblMaxWeightValue";
            this.lblMaxWeightValue.Size = new System.Drawing.Size(60, 25);
            this.lblMaxWeightValue.TabIndex = 53;
            this.lblMaxWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCutOffValue
            // 
            this.lblCutOffValue.BackColor = System.Drawing.SystemColors.Info;
            this.lblCutOffValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCutOffValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCutOffValue.Location = new System.Drawing.Point(296, 417);
            this.lblCutOffValue.Name = "lblCutOffValue";
            this.lblCutOffValue.Size = new System.Drawing.Size(60, 25);
            this.lblCutOffValue.TabIndex = 56;
            this.lblCutOffValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCutOff
            // 
            this.lblCutOff.AutoSize = true;
            this.lblCutOff.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCutOff.Location = new System.Drawing.Point(104, 395);
            this.lblCutOff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCutOff.Name = "lblCutOff";
            this.lblCutOff.Size = new System.Drawing.Size(119, 17);
            this.lblCutOff.TabIndex = 55;
            this.lblCutOff.Text = "ENDS CUT-OFF [m]";
            // 
            // trbCutOff
            // 
            this.trbCutOff.BackColor = System.Drawing.SystemColors.Control;
            this.trbCutOff.Location = new System.Drawing.Point(33, 417);
            this.trbCutOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trbCutOff.Name = "trbCutOff";
            this.trbCutOff.Size = new System.Drawing.Size(257, 56);
            this.trbCutOff.TabIndex = 54;
            // 
            // InputsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 729);
            this.Controls.Add(this.lblCutOffValue);
            this.Controls.Add(this.lblCutOff);
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
            this.Controls.Add(this.trbMaxLength);
            this.Controls.Add(this.trbMinLength);
            this.Controls.Add(this.clbSectionTypes);
            this.Controls.Add(this.trbCutOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InputsView";
            this.Text = "InputsView";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.trbMinLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMaxWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCutOff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckedListBox clbSectionTypes;
        public System.Windows.Forms.TrackBar trbMinLength;
        public System.Windows.Forms.TrackBar trbMaxLength;
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
        public System.Windows.Forms.Label lblCutOffValue;
        internal System.Windows.Forms.Label lblCutOff;
        public System.Windows.Forms.TrackBar trbCutOff;
        public System.Windows.Forms.FolderBrowserDialog fbd_SchemeOuputs;
    }
}