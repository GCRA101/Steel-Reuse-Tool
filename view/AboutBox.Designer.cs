namespace ReuseSchemeTool.view
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.tlpAboutBox = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.plAppLogo = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.tlpAboutBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAboutBox
            // 
            this.tlpAboutBox.ColumnCount = 2;
            this.tlpAboutBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.91803F));
            this.tlpAboutBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.08197F));
            this.tlpAboutBox.Controls.Add(this.lblProductName, 1, 0);
            this.tlpAboutBox.Controls.Add(this.lblVersion, 1, 1);
            this.tlpAboutBox.Controls.Add(this.lblCopyright, 1, 2);
            this.tlpAboutBox.Controls.Add(this.lblCompanyName, 1, 3);
            this.tlpAboutBox.Controls.Add(this.plAppLogo, 0, 0);
            this.tlpAboutBox.Controls.Add(this.btnOK, 1, 5);
            this.tlpAboutBox.Controls.Add(this.rtbAbout, 0, 4);
            this.tlpAboutBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAboutBox.Location = new System.Drawing.Point(0, 0);
            this.tlpAboutBox.Name = "tlpAboutBox";
            this.tlpAboutBox.RowCount = 6;
            this.tlpAboutBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpAboutBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tlpAboutBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tlpAboutBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tlpAboutBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpAboutBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpAboutBox.Size = new System.Drawing.Size(610, 453);
            this.tlpAboutBox.TabIndex = 0;
            // 
            // lblProductName
            // 
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(215, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(392, 54);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product Name";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(215, 54);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(392, 49);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(215, 103);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(392, 49);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(215, 152);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(392, 49);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "Company Name";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plAppLogo
            // 
            this.plAppLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plAppLogo.BackgroundImage")));
            this.plAppLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plAppLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plAppLogo.Location = new System.Drawing.Point(3, 3);
            this.plAppLogo.Name = "plAppLogo";
            this.tlpAboutBox.SetRowSpan(this.plAppLogo, 4);
            this.plAppLogo.Size = new System.Drawing.Size(206, 195);
            this.plAppLogo.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(501, 407);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 43);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // rtbAbout
            // 
            this.tlpAboutBox.SetColumnSpan(this.rtbAbout, 2);
            this.rtbAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAbout.Location = new System.Drawing.Point(3, 204);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.Size = new System.Drawing.Size(604, 197);
            this.rtbAbout.TabIndex = 6;
            this.rtbAbout.Text = "";
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 453);
            this.Controls.Add(this.tlpAboutBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutBox";
            this.Text = "AboutBox";
            this.Load += new System.EventHandler(this.AboutBox_Load_1);
            this.tlpAboutBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlpAboutBox;
        public System.Windows.Forms.Label lblProductName;
        public System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.Label lblCopyright;
        public System.Windows.Forms.Label lblCompanyName;
        public System.Windows.Forms.Panel plAppLogo;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.RichTextBox rtbAbout;
    }
}