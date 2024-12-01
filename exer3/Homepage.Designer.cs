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
            tabPage2 = new TabPage();
            panel1 = new Panel();
            linkLabel1 = new LinkLabel();
            linklogout = new LinkLabel();
            lblEmail = new Label();
            lblFullname = new Label();
            lblUsername = new Label();
            tabPage1 = new TabPage();
            linkBooksForm = new LinkLabel();
            txtintro = new RichTextBox();
            tabControl1 = new TabControl();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // lbWelcome
            // 
            lbWelcome.AutoSize = true;
            lbWelcome.BackColor = Color.Transparent;
            lbWelcome.Font = new Font("Stencil", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWelcome.ForeColor = Color.White;
            lbWelcome.Location = new Point(144, 7);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.Size = new Size(390, 40);
            lbWelcome.TabIndex = 1;
            lbWelcome.Text = "WELCOME TO MY PAGE";
            lbWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(lblEmail);
            tabPage2.Controls.Add(lblFullname);
            tabPage2.Controls.Add(lblUsername);
            tabPage2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage2.ForeColor = Color.PaleVioletRed;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(576, 161);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Information";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(linklogout);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(2, 131);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(572, 28);
            panel1.TabIndex = 3;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.ForeColor = Color.PaleVioletRed;
            linkLabel1.LinkColor = Color.PaleVioletRed;
            linkLabel1.Location = new Point(11, 5);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(134, 20);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Change password";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linklogout
            // 
            linklogout.AutoSize = true;
            linklogout.LinkColor = Color.DeepPink;
            linklogout.Location = new Point(512, 5);
            linklogout.Margin = new Padding(2, 0, 2, 0);
            linklogout.Name = "linklogout";
            linklogout.Size = new Size(61, 20);
            linklogout.TabIndex = 0;
            linklogout.TabStop = true;
            linklogout.Text = "LogOut";
            linklogout.LinkClicked += linklogout_LinkClicked;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(14, 75);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email: ";
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Location = new Point(14, 43);
            lblFullname.Margin = new Padding(2, 0, 2, 0);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(84, 20);
            lblFullname.TabIndex = 1;
            lblFullname.Text = "Fullname: ";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(14, 14);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(89, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username: ";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(linkBooksForm);
            tabPage1.Controls.Add(txtintro);
            tabPage1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.ForeColor = Color.PaleVioletRed;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(576, 161);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Books";
            // 
            // linkBooksForm
            // 
            linkBooksForm.AutoSize = true;
            linkBooksForm.LinkColor = Color.Crimson;
            linkBooksForm.Location = new Point(90, 50);
            linkBooksForm.Margin = new Padding(2, 0, 2, 0);
            linkBooksForm.Name = "linkBooksForm";
            linkBooksForm.Size = new Size(95, 20);
            linkBooksForm.TabIndex = 2;
            linkBooksForm.TabStop = true;
            linkBooksForm.Text = "Books Form";
            linkBooksForm.LinkClicked += linkBooksForm_LinkClicked;
            // 
            // txtintro
            // 
            txtintro.BorderStyle = BorderStyle.None;
            txtintro.ForeColor = Color.PaleVioletRed;
            txtintro.Location = new Point(18, 13);
            txtintro.Margin = new Padding(2);
            txtintro.Name = "txtintro";
            txtintro.Size = new Size(555, 63);
            txtintro.TabIndex = 1;
            txtintro.Text = "Chào mừng bạn đến với NT106.P13!\nNếu muốn khám phá thế giới tri thức qua những cuốn sách thì hãy ấn vào link ở dưới nhé:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(46, 90);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(584, 194);
            tabControl1.TabIndex = 2;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.f4559a0ac40cf5c464dd1c321dbd78c0;
            ClientSize = new Size(678, 294);
            Controls.Add(tabControl1);
            Controls.Add(lbWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Homepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepage";
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbWelcome;
        private TabPage tabPage2;
        private Panel panel1;
        private Label lblEmail;
        private Label lblFullname;
        private Label lblUsername;
        private TabPage tabPage1;
        private LinkLabel linkBooksForm;
        private RichTextBox txtintro;
        private TabControl tabControl1;
        private LinkLabel linklogout;
        private LinkLabel linkLabel1;
    }
}