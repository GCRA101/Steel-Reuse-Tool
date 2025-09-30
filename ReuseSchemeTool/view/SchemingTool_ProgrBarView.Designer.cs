namespace ReuseSchemeTool.view
{
    partial class SchemingTool_ProgrBarView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemingTool_ProgrBarView));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.prgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgrPercent = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61364F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.38636F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.Controls.Add(this.panelLogo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.prgbProgress, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblProgrPercent, 2, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(385, 56);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogo.Location = new System.Drawing.Point(3, 3);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(51, 50);
            this.panelLogo.TabIndex = 0;
            // 
            // prgbProgress
            // 
            this.prgbProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgbProgress.Location = new System.Drawing.Point(60, 2);
            this.prgbProgress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prgbProgress.Name = "prgbProgress";
            this.prgbProgress.Size = new System.Drawing.Size(261, 52);
            this.prgbProgress.Step = 1;
            this.prgbProgress.TabIndex = 2;
            // 
            // lblProgrPercent
            // 
            this.lblProgrPercent.AutoSize = true;
            this.lblProgrPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgrPercent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgrPercent.Location = new System.Drawing.Point(327, 0);
            this.lblProgrPercent.Name = "lblProgrPercent";
            this.lblProgrPercent.Size = new System.Drawing.Size(55, 56);
            this.lblProgrPercent.TabIndex = 3;
            this.lblProgrPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SchemingTool_ProgrBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(392, 66);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SchemingTool_ProgrBarView";
            this.Text = "SchemingTool_ProgrBarView";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelLogo;
        public System.Windows.Forms.ProgressBar prgbProgress;
        private System.Windows.Forms.Label lblProgrPercent;
    }
}