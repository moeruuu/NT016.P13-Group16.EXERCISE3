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
            lbWelcome = new Label();
            btnReturn = new Button();
            btnExit = new Button();
            lbFullname = new Label();
            lbBirthday = new Label();
            lbEmail = new Label();
            lbUserID = new Label();
            btnChangePassword = new Button();
            SuspendLayout();
            // 
            // lbWelcome
            // 
            lbWelcome.AutoSize = true;
            lbWelcome.BackColor = Color.Transparent;
            lbWelcome.Font = new Font("Stencil", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWelcome.ForeColor = Color.FromArgb(255, 128, 255);
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
            btnReturn.BackColor = SystemColors.Control;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatStyle = FlatStyle.Popup;
            btnReturn.Font = new Font("Calibri", 16.2F, FontStyle.Bold);
            btnReturn.ForeColor = Color.PaleVioletRed;
            btnReturn.Location = new Point(941, 740);
            btnReturn.Margin = new Padding(4, 4, 4, 4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(142, 61);
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
            btnExit.Location = new Point(1116, 740);
            btnExit.Margin = new Padding(4, 4, 4, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(142, 61);
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
            lbFullname.Location = new Point(744, 402);
            lbFullname.Margin = new Padding(4, 0, 4, 0);
            lbFullname.Name = "lbFullname";
            lbFullname.Size = new Size(160, 40);
            lbFullname.TabIndex = 4;
            lbFullname.Text = "Fullname: ";
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.BackColor = Color.Transparent;
            lbBirthday.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbBirthday.ForeColor = Color.PaleVioletRed;
            lbBirthday.Location = new Point(744, 479);
            lbBirthday.Margin = new Padding(4, 0, 4, 0);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(143, 40);
            lbBirthday.TabIndex = 5;
            lbBirthday.Text = "Birthday:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.BackColor = Color.Transparent;
            lbEmail.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.ForeColor = Color.PaleVioletRed;
            lbEmail.Location = new Point(744, 556);
            lbEmail.Margin = new Padding(4, 0, 4, 0);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(101, 40);
            lbEmail.TabIndex = 6;
            lbEmail.Text = "Email:";
            // 
            // lbUserID
            // 
            lbUserID.AutoSize = true;
            lbUserID.BackColor = Color.Transparent;
            lbUserID.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUserID.ForeColor = Color.PaleVioletRed;
            lbUserID.Location = new Point(744, 338);
            lbUserID.Margin = new Padding(4, 0, 4, 0);
            lbUserID.Name = "lbUserID";
            lbUserID.Size = new Size(120, 40);
            lbUserID.TabIndex = 7;
            lbUserID.Text = "UserID:";
            // 
            // btnChangePassword
            // 
            btnChangePassword.AutoSize = true;
            btnChangePassword.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = Color.PaleVioletRed;
            btnChangePassword.Location = new Point(1020, 664);
            btnChangePassword.Margin = new Padding(2);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(206, 45);
            btnChangePassword.TabIndex = 19;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.f4559a0ac40cf5c464dd1c321dbd78c0;
            ClientSize = new Size(1274, 816);
            Controls.Add(btnChangePassword);
            Controls.Add(lbUserID);
            Controls.Add(lbEmail);
            Controls.Add(lbBirthday);
            Controls.Add(lbFullname);
            Controls.Add(btnExit);
            Controls.Add(btnReturn);
            Controls.Add(lbWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
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
        private Button btnChangePassword;
    }
}