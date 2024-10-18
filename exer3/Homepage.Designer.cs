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
            lbFullname = new Label();
            lbBirthday = new Label();
            lbEmail = new Label();
            lbUserID = new Label();
            SuspendLayout();
            // 
            // pbHomepage
            // 
            //pbHomepage.BackgroundImage = (Image)resources.GetObject("pbHomepage.BackgroundImage");
            //pbHomepage.Location = new Point(59, 144);
            //pbHomepage.Name = "pbHomepage";
            //pbHomepage.Size = new Size(450, 377);
            //pbHomepage.SizeMode = PictureBoxSizeMode.AutoSize;
            //pbHomepage.TabIndex = 0;
            //pbHomepage.TabStop = false;
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
            btnReturn.Location = new Point(753, 592);
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
            btnExit.Location = new Point(893, 592);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(114, 49);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // lbFullname
            // 
            lbFullname.AutoSize = true;
            lbFullname.BackColor = Color.Transparent;
            lbFullname.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbFullname.ForeColor = Color.PaleVioletRed;
            lbFullname.Location = new Point(595, 322);
            lbFullname.Name = "lbFullname";
            lbFullname.Size = new Size(137, 35);
            lbFullname.TabIndex = 4;
            lbFullname.Text = "Fullname: ";
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.BackColor = Color.Transparent;
            lbBirthday.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbBirthday.ForeColor = Color.PaleVioletRed;
            lbBirthday.Location = new Point(595, 383);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(122, 35);
            lbBirthday.TabIndex = 5;
            lbBirthday.Text = "Birthday:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.BackColor = Color.Transparent;
            lbEmail.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.ForeColor = Color.PaleVioletRed;
            lbEmail.Location = new Point(595, 445);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(88, 35);
            lbEmail.TabIndex = 6;
            lbEmail.Text = "Email:";
            // 
            // lbUserID
            // 
            lbUserID.AutoSize = true;
            lbUserID.BackColor = Color.Transparent;
            lbUserID.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUserID.ForeColor = Color.PaleVioletRed;
            lbUserID.Location = new Point(595, 270);
            lbUserID.Name = "lbUserID";
            lbUserID.Size = new Size(101, 35);
            lbUserID.TabIndex = 7;
            lbUserID.Text = "UserID:";
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.f4559a0ac40cf5c464dd1c321dbd78c0;
            ClientSize = new Size(1019, 653);
            Controls.Add(lbUserID);
            Controls.Add(lbEmail);
            Controls.Add(lbBirthday);
            Controls.Add(lbFullname);
            Controls.Add(btnExit);
            Controls.Add(btnReturn);
            Controls.Add(lbWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Homepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbWelcome;
        private Button btnReturn;
        private Button btnExit;
        private Label lbFullname;
        private Label lbBirthday;
        private Label lbEmail;
        private Label lbUserID;
    }
}