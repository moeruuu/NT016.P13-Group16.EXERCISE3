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
            btnReturn = new Button();
            btnExit = new Button();
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
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnReturn.BackColor = SystemColors.ButtonHighlight;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatStyle = FlatStyle.Popup;
            btnReturn.Font = new Font("Calibri", 16.2F, FontStyle.Bold);
            btnReturn.ForeColor = Color.PaleVioletRed;
            btnReturn.Location = new Point(292, 710);
            btnReturn.Margin = new Padding(4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(258, 61);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "Log out";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += funcLogOut;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExit.BackColor = SystemColors.ButtonHighlight;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Font = new Font("Calibri", 16.2F, FontStyle.Bold);
            btnExit.ForeColor = Color.PaleVioletRed;
            btnExit.Location = new Point(708, 710);
            btnExit.Margin = new Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(243, 61);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += funcExit;
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
            Controls.Add(btnExit);
            Controls.Add(btnReturn);
            Controls.Add(lbWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Homepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepage";
            ((System.ComponentModel.ISupportInitialize)image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbWelcome;
        private Button btnReturn;
        private Button btnExit;
        private Label lbUserInfo;
        private PictureBox image;
    }
}