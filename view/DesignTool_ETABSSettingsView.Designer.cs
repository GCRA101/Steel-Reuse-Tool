namespace ReuseSchemeTool.view
{
    partial class DesignTool_ETABSSettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignTool_ETABSSettingsView));
            this.btnRUN = new System.Windows.Forms.Button();
            this.fbd_SchemeOuputs = new System.Windows.Forms.FolderBrowserDialog();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gbETABSSettings = new System.Windows.Forms.GroupBox();
            this.lblDeflectionCombos = new System.Windows.Forms.Label();
            this.lblStrengthCombos = new System.Windows.Forms.Label();
            this.lblLoadCombos = new System.Windows.Forms.Label();
            this.lbDeflCombos = new System.Windows.Forms.ListBox();
            this.lbStrCombos = new System.Windows.Forms.ListBox();
            this.lbLoadCombos = new System.Windows.Forms.ListBox();
            this.lblSteelDesignCodes = new System.Windows.Forms.Label();
            this.cklbSteelDesignCodes = new System.Windows.Forms.CheckedListBox();
            this.pbETABSInputs = new System.Windows.Forms.PictureBox();
            this.lblProgrBar = new System.Windows.Forms.Label();
            this.progrBar = new System.Windows.Forms.ProgressBar();
            this.gbETABSSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbETABSInputs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRUN
            // 
            this.btnRUN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRUN.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRUN.Location = new System.Drawing.Point(119, 671);
            this.btnRUN.Margin = new System.Windows.Forms.Padding(4);
            this.btnRUN.Name = "btnRUN";
            this.btnRUN.Size = new System.Drawing.Size(141, 47);
            this.btnRUN.TabIndex = 30;
            this.btnRUN.Text = "RUN DESIGN";
            this.btnRUN.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(23, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(336, 81);
            this.lblDescription.TabIndex = 45;
            this.lblDescription.Text = "Select the Steel Design Code to use as well as the Strength and Deflection Load C" +
    "ombos dragging them from the full list of Load Combos defined in the selected ET" +
    "ABS Model (see below).";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gbETABSSettings
            // 
            this.gbETABSSettings.Controls.Add(this.lblDeflectionCombos);
            this.gbETABSSettings.Controls.Add(this.lblStrengthCombos);
            this.gbETABSSettings.Controls.Add(this.lblLoadCombos);
            this.gbETABSSettings.Controls.Add(this.lbDeflCombos);
            this.gbETABSSettings.Controls.Add(this.lbStrCombos);
            this.gbETABSSettings.Controls.Add(this.lbLoadCombos);
            this.gbETABSSettings.Controls.Add(this.lblSteelDesignCodes);
            this.gbETABSSettings.Controls.Add(this.cklbSteelDesignCodes);
            this.gbETABSSettings.Controls.Add(this.pbETABSInputs);
            this.gbETABSSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbETABSSettings.Location = new System.Drawing.Point(22, 94);
            this.gbETABSSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbETABSSettings.Name = "gbETABSSettings";
            this.gbETABSSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbETABSSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbETABSSettings.Size = new System.Drawing.Size(337, 554);
            this.gbETABSSettings.TabIndex = 49;
            this.gbETABSSettings.TabStop = false;
            this.gbETABSSettings.Text = "ETABS Settings";
            // 
            // lblDeflectionCombos
            // 
            this.lblDeflectionCombos.AutoSize = true;
            this.lblDeflectionCombos.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeflectionCombos.Location = new System.Drawing.Point(182, 352);
            this.lblDeflectionCombos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeflectionCombos.Name = "lblDeflectionCombos";
            this.lblDeflectionCombos.Size = new System.Drawing.Size(119, 17);
            this.lblDeflectionCombos.TabIndex = 46;
            this.lblDeflectionCombos.Text = "Deflection Combos";
            // 
            // lblStrengthCombos
            // 
            this.lblStrengthCombos.AutoSize = true;
            this.lblStrengthCombos.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrengthCombos.Location = new System.Drawing.Point(182, 152);
            this.lblStrengthCombos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStrengthCombos.Name = "lblStrengthCombos";
            this.lblStrengthCombos.Size = new System.Drawing.Size(110, 17);
            this.lblStrengthCombos.TabIndex = 45;
            this.lblStrengthCombos.Text = "Strength Combos";
            // 
            // lblLoadCombos
            // 
            this.lblLoadCombos.AutoSize = true;
            this.lblLoadCombos.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadCombos.Location = new System.Drawing.Point(5, 152);
            this.lblLoadCombos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoadCombos.Name = "lblLoadCombos";
            this.lblLoadCombos.Size = new System.Drawing.Size(90, 17);
            this.lblLoadCombos.TabIndex = 44;
            this.lblLoadCombos.Text = "Load Combos";
            // 
            // lbDeflCombos
            // 
            this.lbDeflCombos.FormattingEnabled = true;
            this.lbDeflCombos.ItemHeight = 20;
            this.lbDeflCombos.Location = new System.Drawing.Point(182, 372);
            this.lbDeflCombos.Name = "lbDeflCombos";
            this.lbDeflCombos.Size = new System.Drawing.Size(147, 164);
            this.lbDeflCombos.TabIndex = 43;
            // 
            // lbStrCombos
            // 
            this.lbStrCombos.FormattingEnabled = true;
            this.lbStrCombos.ItemHeight = 20;
            this.lbStrCombos.Location = new System.Drawing.Point(182, 172);
            this.lbStrCombos.Name = "lbStrCombos";
            this.lbStrCombos.Size = new System.Drawing.Size(147, 164);
            this.lbStrCombos.TabIndex = 42;
            // 
            // lbLoadCombos
            // 
            this.lbLoadCombos.FormattingEnabled = true;
            this.lbLoadCombos.ItemHeight = 20;
            this.lbLoadCombos.Location = new System.Drawing.Point(5, 172);
            this.lbLoadCombos.Name = "lbLoadCombos";
            this.lbLoadCombos.Size = new System.Drawing.Size(156, 364);
            this.lbLoadCombos.TabIndex = 41;
            // 
            // lblSteelDesignCodes
            // 
            this.lblSteelDesignCodes.AutoSize = true;
            this.lblSteelDesignCodes.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSteelDesignCodes.Location = new System.Drawing.Point(5, 51);
            this.lblSteelDesignCodes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteelDesignCodes.Name = "lblSteelDesignCodes";
            this.lblSteelDesignCodes.Size = new System.Drawing.Size(129, 17);
            this.lblSteelDesignCodes.TabIndex = 40;
            this.lblSteelDesignCodes.Text = "STEEL DESIGN CODE";
            // 
            // cklbSteelDesignCodes
            // 
            this.cklbSteelDesignCodes.BackColor = System.Drawing.SystemColors.Window;
            this.cklbSteelDesignCodes.CheckOnClick = true;
            this.cklbSteelDesignCodes.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cklbSteelDesignCodes.FormattingEnabled = true;
            this.cklbSteelDesignCodes.Location = new System.Drawing.Point(5, 72);
            this.cklbSteelDesignCodes.Margin = new System.Windows.Forms.Padding(4);
            this.cklbSteelDesignCodes.Name = "cklbSteelDesignCodes";
            this.cklbSteelDesignCodes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cklbSteelDesignCodes.Size = new System.Drawing.Size(324, 58);
            this.cklbSteelDesignCodes.TabIndex = 39;
            // 
            // pbETABSInputs
            // 
            this.pbETABSInputs.Image = ((System.Drawing.Image)(resources.GetObject("pbETABSInputs.Image")));
            this.pbETABSInputs.InitialImage = null;
            this.pbETABSInputs.Location = new System.Drawing.Point(0, 0);
            this.pbETABSInputs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbETABSInputs.Name = "pbETABSInputs";
            this.pbETABSInputs.Size = new System.Drawing.Size(40, 34);
            this.pbETABSInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbETABSInputs.TabIndex = 38;
            this.pbETABSInputs.TabStop = false;
            // 
            // lblProgrBar
            // 
            this.lblProgrBar.AutoSize = true;
            this.lblProgrBar.Location = new System.Drawing.Point(24, 743);
            this.lblProgrBar.Name = "lblProgrBar";
            this.lblProgrBar.Size = new System.Drawing.Size(134, 16);
            this.lblProgrBar.TabIndex = 51;
            this.lblProgrBar.Text = "Iteration in Progress...";
            // 
            // progrBar
            // 
            this.progrBar.Location = new System.Drawing.Point(25, 764);
            this.progrBar.Margin = new System.Windows.Forms.Padding(4);
            this.progrBar.Maximum = 100000;
            this.progrBar.Name = "progrBar";
            this.progrBar.Size = new System.Drawing.Size(317, 27);
            this.progrBar.TabIndex = 50;
            // 
            // DesignTool_ETABSSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 816);
            this.Controls.Add(this.lblProgrBar);
            this.Controls.Add(this.progrBar);
            this.Controls.Add(this.gbETABSSettings);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnRUN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DesignTool_ETABSSettingsView";
            this.Text = "ETABS Settings";
            this.TopMost = true;
            this.gbETABSSettings.ResumeLayout(false);
            this.gbETABSSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbETABSInputs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnRUN;
        public System.Windows.Forms.FolderBrowserDialog fbd_SchemeOuputs;
        public System.Windows.Forms.Label lblDescription;
        internal System.Windows.Forms.GroupBox gbETABSSettings;
        internal System.Windows.Forms.Label lblDeflectionCombos;
        internal System.Windows.Forms.Label lblStrengthCombos;
        internal System.Windows.Forms.Label lblLoadCombos;
        private System.Windows.Forms.ListBox lbDeflCombos;
        private System.Windows.Forms.ListBox lbStrCombos;
        private System.Windows.Forms.ListBox lbLoadCombos;
        internal System.Windows.Forms.Label lblSteelDesignCodes;
        internal System.Windows.Forms.CheckedListBox cklbSteelDesignCodes;
        internal System.Windows.Forms.PictureBox pbETABSInputs;
        internal System.Windows.Forms.Label lblProgrBar;
        internal System.Windows.Forms.ProgressBar progrBar;
    }
}