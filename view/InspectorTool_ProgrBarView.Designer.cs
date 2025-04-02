namespace ReuseSchemeTool.view
{
    partial class InspectorTool_ProgrBarView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectorTool_ProgrBarView));
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
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.15385F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.84615F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel.Controls.Add(this.panelLogo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.prgbProgress, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblProgrPercent, 2, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(388, 57);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Location = new System.Drawing.Point(3, 3);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(53, 51);
            this.panelLogo.TabIndex = 0;
            // 
            // prgbProgress
            // 
            this.prgbProgress.Location = new System.Drawing.Point(62, 2);
            this.prgbProgress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prgbProgress.Name = "prgbProgress";
            this.prgbProgress.Size = new System.Drawing.Size(260, 53);
            this.prgbProgress.TabIndex = 2;
            // 
            // lblProgrPercent
            // 
            this.lblProgrPercent.AutoSize = true;
            this.lblProgrPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgrPercent.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgrPercent.Location = new System.Drawing.Point(328, 0);
            this.lblProgrPercent.Name = "lblProgrPercent";
            this.lblProgrPercent.Size = new System.Drawing.Size(57, 57);
            this.lblProgrPercent.TabIndex = 3;
            this.lblProgrPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgrPercent.Click += new System.EventHandler(this.lblProgrPercent_Click);
            // 
            // InspectorTool_ProgrBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(394, 65);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InspectorTool_ProgrBarView";
            this.Text = "InspectorTool_ProgrBarView";
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