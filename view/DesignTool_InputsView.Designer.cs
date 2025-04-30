namespace ReuseSchemeTool.view
{
    partial class DesignTool_InputsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignTool_InputsView));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.fbd_SchemeOuputs = new System.Windows.Forms.FolderBrowserDialog();
            this.pbPDispInputs = new System.Windows.Forms.PictureBox();
            this.grbJsonDatasets = new System.Windows.Forms.GroupBox();
            this.btnOpenPropFramesJson = new System.Windows.Forms.Button();
            this.lblExistingFrameObjs = new System.Windows.Forms.Label();
            this.btnOpenExistFramesJson = new System.Windows.Forms.Button();
            this.lblProposedFrameObjs = new System.Windows.Forms.Label();
            this.gbFEAModel = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFEAModel = new System.Windows.Forms.Label();
            this.btnOpenFEAModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPDispInputs)).BeginInit();
            this.grbJsonDatasets.SuspendLayout();
            this.gbFEAModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(122, 364);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(141, 47);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(23, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(336, 81);
            this.lblDescription.TabIndex = 45;
            this.lblDescription.Text = "Select the JSON Datasets of the Existing and the Proposed Frame Objects generated" +
    " using the other Reuse Tools and select the FEA Model to support the design.";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbPDispInputs
            // 
            this.pbPDispInputs.BackColor = System.Drawing.Color.Transparent;
            this.pbPDispInputs.Image = ((System.Drawing.Image)(resources.GetObject("pbPDispInputs.Image")));
            this.pbPDispInputs.InitialImage = null;
            this.pbPDispInputs.Location = new System.Drawing.Point(0, 0);
            this.pbPDispInputs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPDispInputs.Name = "pbPDispInputs";
            this.pbPDispInputs.Size = new System.Drawing.Size(40, 40);
            this.pbPDispInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPDispInputs.TabIndex = 39;
            this.pbPDispInputs.TabStop = false;
            // 
            // grbJsonDatasets
            // 
            this.grbJsonDatasets.Controls.Add(this.btnOpenPropFramesJson);
            this.grbJsonDatasets.Controls.Add(this.pbPDispInputs);
            this.grbJsonDatasets.Controls.Add(this.lblExistingFrameObjs);
            this.grbJsonDatasets.Controls.Add(this.btnOpenExistFramesJson);
            this.grbJsonDatasets.Controls.Add(this.lblProposedFrameObjs);
            this.grbJsonDatasets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbJsonDatasets.Location = new System.Drawing.Point(23, 101);
            this.grbJsonDatasets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbJsonDatasets.Name = "grbJsonDatasets";
            this.grbJsonDatasets.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbJsonDatasets.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbJsonDatasets.Size = new System.Drawing.Size(336, 134);
            this.grbJsonDatasets.TabIndex = 48;
            this.grbJsonDatasets.TabStop = false;
            this.grbJsonDatasets.Text = "JSON DataSets";
            // 
            // btnOpenPropFramesJson
            // 
            this.btnOpenPropFramesJson.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPropFramesJson.Location = new System.Drawing.Point(205, 82);
            this.btnOpenPropFramesJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenPropFramesJson.Name = "btnOpenPropFramesJson";
            this.btnOpenPropFramesJson.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpenPropFramesJson.Size = new System.Drawing.Size(124, 28);
            this.btnOpenPropFramesJson.TabIndex = 40;
            this.btnOpenPropFramesJson.Text = "Browse...";
            this.btnOpenPropFramesJson.UseVisualStyleBackColor = true;
            // 
            // lblExistingFrameObjs
            // 
            this.lblExistingFrameObjs.AutoSize = true;
            this.lblExistingFrameObjs.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistingFrameObjs.Location = new System.Drawing.Point(8, 52);
            this.lblExistingFrameObjs.Name = "lblExistingFrameObjs";
            this.lblExistingFrameObjs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExistingFrameObjs.Size = new System.Drawing.Size(129, 15);
            this.lblExistingFrameObjs.TabIndex = 37;
            this.lblExistingFrameObjs.Text = "Existing Frame Objects:";
            // 
            // btnOpenExistFramesJson
            // 
            this.btnOpenExistFramesJson.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenExistFramesJson.Location = new System.Drawing.Point(205, 46);
            this.btnOpenExistFramesJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenExistFramesJson.Name = "btnOpenExistFramesJson";
            this.btnOpenExistFramesJson.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpenExistFramesJson.Size = new System.Drawing.Size(124, 28);
            this.btnOpenExistFramesJson.TabIndex = 36;
            this.btnOpenExistFramesJson.Text = "Browse...";
            this.btnOpenExistFramesJson.UseVisualStyleBackColor = true;
            // 
            // lblProposedFrameObjs
            // 
            this.lblProposedFrameObjs.AutoSize = true;
            this.lblProposedFrameObjs.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProposedFrameObjs.Location = new System.Drawing.Point(8, 89);
            this.lblProposedFrameObjs.Name = "lblProposedFrameObjs";
            this.lblProposedFrameObjs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProposedFrameObjs.Size = new System.Drawing.Size(139, 15);
            this.lblProposedFrameObjs.TabIndex = 30;
            this.lblProposedFrameObjs.Text = "Proposed Frame Objects:";
            // 
            // gbFEAModel
            // 
            this.gbFEAModel.Controls.Add(this.pictureBox1);
            this.gbFEAModel.Controls.Add(this.lblFEAModel);
            this.gbFEAModel.Controls.Add(this.btnOpenFEAModel);
            this.gbFEAModel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFEAModel.Location = new System.Drawing.Point(23, 254);
            this.gbFEAModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFEAModel.Name = "gbFEAModel";
            this.gbFEAModel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFEAModel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbFEAModel.Size = new System.Drawing.Size(336, 87);
            this.gbFEAModel.TabIndex = 49;
            this.gbFEAModel.TabStop = false;
            this.gbFEAModel.Text = "FEA Model";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // lblFEAModel
            // 
            this.lblFEAModel.AutoSize = true;
            this.lblFEAModel.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFEAModel.Location = new System.Drawing.Point(8, 52);
            this.lblFEAModel.Name = "lblFEAModel";
            this.lblFEAModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFEAModel.Size = new System.Drawing.Size(153, 19);
            this.lblFEAModel.TabIndex = 37;
            this.lblFEAModel.Text = "Finite Element Model:";
            // 
            // btnOpenFEAModel
            // 
            this.btnOpenFEAModel.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFEAModel.Location = new System.Drawing.Point(205, 46);
            this.btnOpenFEAModel.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFEAModel.Name = "btnOpenFEAModel";
            this.btnOpenFEAModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpenFEAModel.Size = new System.Drawing.Size(124, 28);
            this.btnOpenFEAModel.TabIndex = 36;
            this.btnOpenFEAModel.Text = "Browse...";
            this.btnOpenFEAModel.UseVisualStyleBackColor = true;
            // 
            // DesignTool_InputsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 427);
            this.Controls.Add(this.gbFEAModel);
            this.Controls.Add(this.grbJsonDatasets);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DesignTool_InputsView";
            this.Text = "Inputs";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbPDispInputs)).EndInit();
            this.grbJsonDatasets.ResumeLayout(false);
            this.grbJsonDatasets.PerformLayout();
            this.gbFEAModel.ResumeLayout(false);
            this.gbFEAModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.FolderBrowserDialog fbd_SchemeOuputs;
        internal System.Windows.Forms.PictureBox pbPDispInputs;
        internal System.Windows.Forms.GroupBox grbJsonDatasets;
        internal System.Windows.Forms.Button btnOpenPropFramesJson;
        internal System.Windows.Forms.Label lblExistingFrameObjs;
        internal System.Windows.Forms.Button btnOpenExistFramesJson;
        internal System.Windows.Forms.Label lblProposedFrameObjs;
        internal System.Windows.Forms.GroupBox gbFEAModel;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblFEAModel;
        internal System.Windows.Forms.Button btnOpenFEAModel;
    }
}