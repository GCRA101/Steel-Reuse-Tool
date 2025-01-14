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
            this.label1 = new System.Windows.Forms.Label();
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
            this.clbSectionTypes.Location = new System.Drawing.Point(26, 113);
            this.clbSectionTypes.Name = "clbSectionTypes";
            this.clbSectionTypes.Size = new System.Drawing.Size(149, 106);
            this.clbSectionTypes.TabIndex = 0;
            // 
            // prgbProgress
            // 
            this.prgbProgress.Location = new System.Drawing.Point(26, 643);
            this.prgbProgress.Name = "prgbProgress";
            this.prgbProgress.Size = new System.Drawing.Size(323, 32);
            this.prgbProgress.TabIndex = 1;
            this.prgbProgress.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // trbMinLength
            // 
            this.trbMinLength.Location = new System.Drawing.Point(26, 267);
            this.trbMinLength.Name = "trbMinLength";
            this.trbMinLength.Size = new System.Drawing.Size(323, 56);
            this.trbMinLength.TabIndex = 2;
            this.trbMinLength.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trbMaxLength
            // 
            this.trbMaxLength.BackColor = System.Drawing.SystemColors.Control;
            this.trbMaxLength.Location = new System.Drawing.Point(26, 338);
            this.trbMaxLength.Name = "trbMaxLength";
            this.trbMaxLength.Size = new System.Drawing.Size(323, 56);
            this.trbMaxLength.TabIndex = 3;
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
            this.lblProgrBar.Click += new System.EventHandler(this.lblProgrBar_Click);
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
            this.btnRun.Click += new System.EventHandler(this.btnRunIteration_Click);
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
            this.clbSteelGrades.Location = new System.Drawing.Point(200, 113);
            this.clbSteelGrades.Name = "clbSteelGrades";
            this.clbSteelGrades.Size = new System.Drawing.Size(149, 106);
            this.clbSteelGrades.TabIndex = 37;
            // 
            // lblMinLength
            // 
            this.lblMinLength.AutoSize = true;
            this.lblMinLength.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinLength.Location = new System.Drawing.Point(122, 247);
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
            this.lblMaxLength.Location = new System.Drawing.Point(121, 318);
            this.lblMaxLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(147, 17);
            this.lblMaxLength.TabIndex = 40;
            this.lblMaxLength.Text = "MAXIMUM LENGTH [m]";
            // 
            // trbMinWeight
            // 
            this.trbMinWeight.Location = new System.Drawing.Point(26, 409);
            this.trbMinWeight.Name = "trbMinWeight";
            this.trbMinWeight.Size = new System.Drawing.Size(323, 56);
            this.trbMinWeight.TabIndex = 41;
            // 
            // trbMaxWeight
            // 
            this.trbMaxWeight.Location = new System.Drawing.Point(26, 480);
            this.trbMaxWeight.Name = "trbMaxWeight";
            this.trbMaxWeight.Size = new System.Drawing.Size(323, 56);
            this.trbMaxWeight.TabIndex = 42;
            // 
            // lblMinWeight
            // 
            this.lblMinWeight.AutoSize = true;
            this.lblMinWeight.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinWeight.Location = new System.Drawing.Point(121, 389);
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
            this.lblMaxWeight.Location = new System.Drawing.Point(120, 460);
            this.lblMaxWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxWeight.Name = "lblMaxWeight";
            this.lblMaxWeight.Size = new System.Drawing.Size(149, 17);
            this.lblMaxWeight.TabIndex = 44;
            this.lblMaxWeight.Text = "MAXIMUM WEIGHT [kg]";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 70);
            this.label1.TabIndex = 45;
            this.label1.Text = "asdfasdfdassdfsadfsadfafsafaadsfasdfasdfasdfsadfsfasdfdfsdfsadfsadfasdfasdfasfsaf" +
    "sfasfsfasfsafasfasfsadfsdfadsfssdfadsfasdfasdfasdfasfasdsdfa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // InputsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 706);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.CheckedListBox clbSectionTypes;
        private System.Windows.Forms.ProgressBar prgbProgress;
        private System.Windows.Forms.TrackBar trbMinLength;
        private System.Windows.Forms.TrackBar trbMaxLength;
        internal System.Windows.Forms.Label lblProgrBar;
        internal System.Windows.Forms.Button btnRun;
        internal System.Windows.Forms.Label lblSectionTypes;
        internal System.Windows.Forms.Label lblSteelGrades;
        private System.Windows.Forms.CheckedListBox clbSteelGrades;
        internal System.Windows.Forms.Label lblMinLength;
        internal System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.TrackBar trbMinWeight;
        private System.Windows.Forms.TrackBar trbMaxWeight;
        internal System.Windows.Forms.Label lblMinWeight;
        internal System.Windows.Forms.Label lblMaxWeight;
        private System.Windows.Forms.Label label1;
    }
}