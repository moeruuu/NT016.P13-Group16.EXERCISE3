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
            pbHomepage = new PictureBox();
            lbWelcome = new Label();
            btnReturn = new Button();
            btnExit = new Button();
            lbUserInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)pbHomepage).BeginInit();
            SuspendLayout();
            // 
            // pbHomepage
            // 
            pbHomepage.BackgroundImage = (Image)resources.GetObject("pbHomepage.BackgroundImage");
            pbHomepage.Location = new Point(281, 140);
            pbHomepage.Name = "pbHomepage";
            pbHomepage.Size = new Size(450, 377);
            pbHomepage.SizeMode = PictureBoxSizeMode.AutoSize;
            pbHomepage.TabIndex = 0;
            pbHomepage.TabStop = false;
            // 
            // lbWelcome
            // 
            lbWelcome.AutoSize = true;
            lbWelcome.BackColor = Color.Transparent;
            lbWelcome.Font = new Font("Stencil", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWelcome.ForeColor = Color.FromArgb(255, 128, 255);
            lbWelcome.Location = new Point(314, 25);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.Size = new Size(390, 40);
            lbWelcome.TabIndex = 1;
            lbWelcome.Text = "WELCOME TO MY PAGE";
            lbWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnReturn.BackColor = SystemColors.Control;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatStyle = FlatStyle.Popup;
            btnReturn.Font = new Font("Calibri", 16.2F, FontStyle.Bold);
            btnReturn.ForeColor = Color.PaleVioletRed;
            btnReturn.Location = new Point(326, 568);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(114, 49);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "Log out";
            btnReturn.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnExit.BackColor = SystemColors.Control;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Font = new Font("Calibri", 16.2F, FontStyle.Bold);
            btnExit.ForeColor = Color.PaleVioletRed;
            btnExit.Location = new Point(566, 568);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(114, 49);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // lbUserInfo
            // 
            lbUserInfo.AutoSize = true;
            lbUserInfo.BackColor = Color.Transparent;
            lbUserInfo.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUserInfo.ForeColor = Color.PaleVioletRed;
            lbUserInfo.Location = new Point(448, 84);
            lbUserInfo.Name = "lbUserInfo";
            lbUserInfo.Size = new Size(114, 35);
            lbUserInfo.TabIndex = 4;
            lbUserInfo.Text = "UserInfo";
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.f4559a0ac40cf5c464dd1c321dbd78c0;
            ClientSize = new Size(1019, 653);
            Controls.Add(lbUserInfo);
            Controls.Add(btnExit);
            Controls.Add(btnReturn);
            Controls.Add(lbWelcome);
            Controls.Add(pbHomepage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Homepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepage";
            ((System.ComponentModel.ISupportInitialize)pbHomepage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbHomepage;
        private Label lbWelcome;
        private Button btnReturn;
        private Button btnExit;
        private Label lbUserInfo;
    }
}