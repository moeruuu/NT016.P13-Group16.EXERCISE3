namespace exer3
{
    partial class Homepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            lbWelcome = new Label();
            funcLogOut = new Button();
            funcExit = new Button();
            lbUserInfo = new Label();
            image = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)image).BeginInit();
            SuspendLayout();
            // 
            // lbWelcome
            // 
            lbWelcome.AutoSize = true;
            lbWelcome.BackColor = Color.Transparent;
            lbWelcome.Font = new Font("Stencil", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWelcome.ForeColor = Color.DarkMagenta;
            lbWelcome.Location = new Point(392, 31);
            lbWelcome.Margin = new Padding(4, 0, 4, 0);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.Size = new Size(449, 47);
            lbWelcome.TabIndex = 1;
            lbWelcome.Text = "WELCOME TO MY PAGE";
            lbWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // funcLogOut
            // 
            funcLogOut.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            funcLogOut.BackColor = SystemColors.ButtonHighlight;
            funcLogOut.Cursor = Cursors.Hand;
            funcLogOut.FlatStyle = FlatStyle.Popup;
            funcLogOut.Font = new Font("Calibri", 16.2F, FontStyle.Bold);
            funcLogOut.ForeColor = Color.PaleVioletRed;
            funcLogOut.Location = new Point(292, 710);
            funcLogOut.Margin = new Padding(4);
            funcLogOut.Name = "funcLogOut";
            funcLogOut.Size = new Size(258, 61);
            funcLogOut.TabIndex = 2;
            funcLogOut.Text = "Log out";
            funcLogOut.UseVisualStyleBackColor = false;
//            funcLogOut.Click += funcLogOut_Click;
            // 
            // funcExit
            // 
            funcExit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            funcExit.BackColor = SystemColors.ButtonHighlight;
            funcExit.Cursor = Cursors.Hand;
            funcExit.FlatStyle = FlatStyle.Popup;
            funcExit.Font = new Font("Calibri", 16.2F, FontStyle.Bold);
            funcExit.ForeColor = Color.PaleVioletRed;
            funcExit.Location = new Point(708, 710);
            funcExit.Margin = new Padding(4);
            funcExit.Name = "funcExit";
            funcExit.Size = new Size(243, 61);
            funcExit.TabIndex = 3;
            funcExit.Text = "Exit";
            funcExit.UseVisualStyleBackColor = false;
//            funcExit.Click += funcExit_Click;
            // 
            // lbUserInfo
            // 
            lbUserInfo.AutoSize = true;
            lbUserInfo.BackColor = Color.Transparent;
            lbUserInfo.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUserInfo.ForeColor = Color.PaleVioletRed;
            lbUserInfo.Location = new Point(550, 104);
            lbUserInfo.Margin = new Padding(4, 0, 4, 0);
            lbUserInfo.Name = "lbUserInfo";
            lbUserInfo.Size = new Size(136, 40);
            lbUserInfo.TabIndex = 4;
            lbUserInfo.Text = "UserInfo";
            // 
            // image
            // 
            image.BackColor = Color.Transparent;
            image.Image = (Image)resources.GetObject("image.Image");
            image.Location = new Point(392, 171);
            image.Name = "image";
            image.Size = new Size(458, 472);
            image.SizeMode = PictureBoxSizeMode.Zoom;
            image.TabIndex = 5;
            image.TabStop = false;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1274, 816);
            Controls.Add(image);
            Controls.Add(lbUserInfo);
            Controls.Add(funcExit);
            Controls.Add(funcLogOut);
            Controls.Add(lbWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Homepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepage";
          //  Load += Homepage_Load;
            ((System.ComponentModel.ISupportInitialize)image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbWelcome;
        private Button funcLogOut;
        private Button funcExit;
        private Label lbUserInfo;
        private PictureBox image;
    }
}