namespace ReuseSchemeTool.view
{
    partial class Inspector_SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inspector_SplashScreen));
            this.tlpLogo = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pbAppLogo = new System.Windows.Forms.PictureBox();
            this.tlpLogo.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLogo
            // 
            this.tlpLogo.ColumnCount = 2;
            this.tlpLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpLogo.Controls.Add(this.tlpTitle, 1, 0);
            this.tlpLogo.Controls.Add(this.pbAppLogo, 0, 0);
            this.tlpLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogo.Location = new System.Drawing.Point(0, 0);
            this.tlpLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpLogo.Name = "tlpLogo";
            this.tlpLogo.RowCount = 1;
            this.tlpLogo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 313F));
            this.tlpLogo.Size = new System.Drawing.Size(471, 333);
            this.tlpLogo.TabIndex = 0;
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 1;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.Controls.Add(this.lblApplicationName, 0, 0);
            this.tlpTitle.Controls.Add(this.lblVersion, 0, 1);
            this.tlpTitle.Controls.Add(this.lblCopyright, 0, 2);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(309, 3);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 3;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.99522F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.00478F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpTitle.Size = new System.Drawing.Size(159, 327);
            this.tlpTitle.TabIndex = 2;
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblApplicationName.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationName.Location = new System.Drawing.Point(3, 148);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(153, 64);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "Application Name";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(3, 212);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(153, 26);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version: ";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(97, 238);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(59, 15);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright";
            // 
            // pbAppLogo
            // 
            this.pbAppLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbAppLogo.BackgroundImage")));
            this.pbAppLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAppLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAppLogo.Location = new System.Drawing.Point(2, 2);
            this.pbAppLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbAppLogo.Name = "pbAppLogo";
            this.pbAppLogo.Size = new System.Drawing.Size(302, 329);
            this.pbAppLogo.TabIndex = 3;
            this.pbAppLogo.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(471, 333);
            this.Controls.Add(this.tlpLogo);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.Text = "SplashScreen";
            this.tlpLogo.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAppLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLogo;
        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblApplicationName;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.PictureBox pbAppLogo;
    }
}