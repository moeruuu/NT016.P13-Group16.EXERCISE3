﻿namespace exer3
{
    partial class ChangePassword
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
            tboxReceivedPassword = new TextBox();
            lbReceivedPW = new Label();
            tboxNewPassword = new TextBox();
            lblNewPW = new Label();
            tboxConfirmPassword = new TextBox();
            label1 = new Label();
            btnChangePassword = new Button();
            SuspendLayout();
            // 
            // tboxReceivedPassword
            // 
            tboxReceivedPassword.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxReceivedPassword.ForeColor = Color.PaleVioletRed;
            tboxReceivedPassword.Location = new Point(297, 48);
            tboxReceivedPassword.Margin = new Padding(2);
            tboxReceivedPassword.Name = "tboxReceivedPassword";
            tboxReceivedPassword.Size = new Size(462, 31);
            tboxReceivedPassword.TabIndex = 14;
            // 
            // lbReceivedPW
            // 
            lbReceivedPW.AutoSize = true;
            lbReceivedPW.BackColor = Color.Transparent;
            lbReceivedPW.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbReceivedPW.ForeColor = Color.PaleVioletRed;
            lbReceivedPW.Location = new Point(90, 53);
            lbReceivedPW.Margin = new Padding(2, 0, 2, 0);
            lbReceivedPW.Name = "lbReceivedPW";
            lbReceivedPW.Size = new Size(104, 26);
            lbReceivedPW.TabIndex = 13;
            lbReceivedPW.Text = "Password";
            // 
            // tboxNewPassword
            // 
            tboxNewPassword.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxNewPassword.ForeColor = Color.PaleVioletRed;
            tboxNewPassword.Location = new Point(297, 133);
            tboxNewPassword.Margin = new Padding(2);
            tboxNewPassword.Name = "tboxNewPassword";
            tboxNewPassword.Size = new Size(462, 31);
            tboxNewPassword.TabIndex = 18;
            // 
            // lblNewPW
            // 
            lblNewPW.AutoSize = true;
            lblNewPW.BackColor = Color.Transparent;
            lblNewPW.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPW.ForeColor = Color.PaleVioletRed;
            lblNewPW.Location = new Point(90, 138);
            lblNewPW.Margin = new Padding(2, 0, 2, 0);
            lblNewPW.Name = "lblNewPW";
            lblNewPW.Size = new Size(152, 26);
            lblNewPW.TabIndex = 17;
            lblNewPW.Text = "New Password";
            // 
            // tboxConfirmPassword
            // 
            tboxConfirmPassword.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tboxConfirmPassword.ForeColor = Color.PaleVioletRed;
            tboxConfirmPassword.Location = new Point(297, 225);
            tboxConfirmPassword.Margin = new Padding(2);
            tboxConfirmPassword.Name = "tboxConfirmPassword";
            tboxConfirmPassword.Size = new Size(462, 31);
            tboxConfirmPassword.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(90, 230);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(185, 26);
            label1.TabIndex = 19;
            label1.Text = "Confirm Password";
            // 
            // btnChangePassword
            // 
            btnChangePassword.AutoSize = true;
            btnChangePassword.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = Color.PaleVioletRed;
            btnChangePassword.Location = new Point(573, 287);
            btnChangePassword.Margin = new Padding(2);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(186, 47);
            btnChangePassword.TabIndex = 21;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.f4559a0ac40cf5c464dd1c321dbd78c0;
            ClientSize = new Size(846, 345);
            Controls.Add(btnChangePassword);
            Controls.Add(tboxConfirmPassword);
            Controls.Add(label1);
            Controls.Add(tboxNewPassword);
            Controls.Add(lblNewPW);
            Controls.Add(tboxReceivedPassword);
            Controls.Add(lbReceivedPW);
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tboxReceivedPassword;
        private Label lbReceivedPW;
        private TextBox tboxNewPassword;
        private Label lblNewPW;
        private TextBox tboxConfirmPassword;
        private Label label1;
        private Button btnChangePassword;
    }
}