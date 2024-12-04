namespace exer3
{
    partial class ForgotPassword
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
            tboxEmail = new TextBox();
            lblEmail = new Label();
            btnGetNewPassword = new Button();
            linkLogin = new LinkLabel();
            SuspendLayout();
            // 
            // tboxEmail
            // 
            tboxEmail.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxEmail.ForeColor = Color.PaleVioletRed;
            tboxEmail.Location = new Point(236, 93);
            tboxEmail.Margin = new Padding(2);
            tboxEmail.Name = "tboxEmail";
            tboxEmail.Size = new Size(462, 31);
            tboxEmail.TabIndex = 14;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.PaleVioletRed;
            lblEmail.Location = new Point(85, 93);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(66, 26);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email";
            // 
            // btnGetNewPassword
            // 
            btnGetNewPassword.AutoSize = true;
            btnGetNewPassword.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGetNewPassword.ForeColor = Color.PaleVioletRed;
            btnGetNewPassword.Location = new Point(497, 162);
            btnGetNewPassword.Margin = new Padding(2);
            btnGetNewPassword.Name = "btnGetNewPassword";
            btnGetNewPassword.Size = new Size(201, 34);
            btnGetNewPassword.TabIndex = 19;
            btnGetNewPassword.Text = "Get New Password";
            btnGetNewPassword.UseVisualStyleBackColor = true;
            btnGetNewPassword.Click += btnGetNewPassword_Click;
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.BackColor = Color.Transparent;
            linkLogin.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLogin.LinkColor = Color.PaleVioletRed;
            linkLogin.Location = new Point(236, 171);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(59, 23);
            linkLogin.TabIndex = 20;
            linkLogin.TabStop = true;
            linkLogin.Text = "Login";
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._3046153;
            ClientSize = new Size(782, 375);
            Controls.Add(linkLogin);
            Controls.Add(btnGetNewPassword);
            Controls.Add(tboxEmail);
            Controls.Add(lblEmail);
            Name = "ForgotPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tboxEmail;
        private Label lblEmail;
        private Button btnGetNewPassword;
        private LinkLabel linkLogin;
    }
}