namespace ReuseSchemeTool.view
{
    partial class SplashScreen 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
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
            this.tlpLogo.Name = "tlpLogo";
            this.tlpLogo.RowCount = 1;
            this.tlpLogo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 385F));
            this.tlpLogo.Size = new System.Drawing.Size(628, 410);
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
            this.tlpTitle.Location = new System.Drawing.Point(412, 4);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(4);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 3;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.99522F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.00478F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tlpTitle.Size = new System.Drawing.Size(212, 402);
            this.tlpTitle.TabIndex = 2;
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblApplicationName.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationName.Location = new System.Drawing.Point(4, 179);
            this.lblApplicationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(204, 82);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "Application Name";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(4, 261);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(204, 32);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version: ";
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(136, 293);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(72, 20);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright";
            // 
            // pbAppLogo
            // 
            this.pbAppLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbAppLogo.BackgroundImage")));
            this.pbAppLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAppLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAppLogo.Location = new System.Drawing.Point(3, 3);
            this.pbAppLogo.Name = "pbAppLogo";
            this.pbAppLogo.Size = new System.Drawing.Size(402, 404);
            this.pbAppLogo.TabIndex = 3;
            this.pbAppLogo.TabStop = false;
            this.pbAppLogo.Click += new System.EventHandler(this.pbAppLogo_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 410);
            this.Controls.Add(this.tlpLogo);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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