﻿namespace exer3
{
    partial class login
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
            labelPassword = new Label();
            labelUsername = new Label();
            tbpass = new TextBox();
            tbusername = new TextBox();
            linklogin = new LinkLabel();
            label2 = new Label();
            btnLogin = new Button();
            btnForgotPassword = new Button();
            SuspendLayout();
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = Color.PaleVioletRed;
            labelPassword.Location = new Point(98, 235);
            labelPassword.Margin = new Padding(2, 0, 2, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(104, 26);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.BackColor = Color.Transparent;
            labelUsername.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.ForeColor = Color.PaleVioletRed;
            labelUsername.Location = new Point(98, 142);
            labelUsername.Margin = new Padding(2, 0, 2, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(107, 26);
            labelUsername.TabIndex = 5;
            labelUsername.Text = "Username";
            // 
            // tbpass
            // 
            tbpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbpass.ForeColor = Color.PaleVioletRed;
            tbpass.Location = new Point(281, 235);
            tbpass.Margin = new Padding(2);
            tbpass.Name = "tbpass";
            tbpass.PasswordChar = '*';
            tbpass.Size = new Size(462, 31);
            tbpass.TabIndex = 13;
            // 
            // tbusername
            // 
            tbusername.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbusername.ForeColor = Color.PaleVioletRed;
            tbusername.Location = new Point(281, 142);
            tbusername.Margin = new Padding(2);
            tbusername.Name = "tbusername";
            tbusername.Size = new Size(462, 31);
            tbusername.TabIndex = 12;
            // 
            // linklogin
            // 
            linklogin.AutoSize = true;
            linklogin.BackColor = Color.Transparent;
            linklogin.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linklogin.ForeColor = Color.Honeydew;
            linklogin.LinkColor = Color.Crimson;
            linklogin.Location = new Point(598, 367);
            linklogin.Margin = new Padding(2, 0, 2, 0);
            linklogin.Name = "linklogin";
            linklogin.Size = new Size(74, 25);
            linklogin.TabIndex = 15;
            linklogin.TabStop = true;
            linklogin.Text = "Signup";
            linklogin.LinkClicked += linksignup_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.PaleVioletRed;
            label2.Location = new Point(363, 369);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(217, 23);
            label2.TabIndex = 14;
            label2.Text = "Do not have an account?";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.PaleVioletRed;
            btnLogin.Location = new Point(281, 303);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(139, 34);
            btnLogin.TabIndex = 18;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.AutoSize = true;
            btnForgotPassword.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnForgotPassword.ForeColor = Color.PaleVioletRed;
            btnForgotPassword.Location = new Point(572, 303);
            btnForgotPassword.Margin = new Padding(2);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(171, 34);
            btnForgotPassword.TabIndex = 19;
            btnForgotPassword.Text = "Forgot Password";
            btnForgotPassword.UseVisualStyleBackColor = true;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._3046153;
            ClientSize = new Size(898, 502);
            Controls.Add(btnForgotPassword);
            Controls.Add(btnLogin);
            Controls.Add(linklogin);
            Controls.Add(label2);
            Controls.Add(tbpass);
            Controls.Add(tbusername);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Margin = new Padding(4, 4, 4, 4);
            Name = "login";
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPassword;
        private Label labelUsername;
        private TextBox tbpass;
        private TextBox tbusername;
        private LinkLabel linklogin;
        private Label label2;
        private Button btnLogin;
        private Button btnForgotPassword;
    }
}