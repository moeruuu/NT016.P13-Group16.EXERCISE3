﻿namespace exer3
{
    partial class Searchform
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
            label1 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvBoooks = new DataGridView();
            btnLoadBookshelf = new Button();
            lbNhap = new Label();
            labelBookList = new Label();
            buttonExit = new Button();
            labelName = new Label();
            progressBar = new ProgressBar();
            dgvShelf = new DataGridView();
            btnAddBook = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBoooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvShelf).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(560, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(363, 61);
            label1.TabIndex = 0;
            label1.Text = "TÌM KIẾM SÁCH";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.LavenderBlush;
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.PaleVioletRed;
            txtSearch.Location = new Point(622, 122);
            txtSearch.Margin = new Padding(2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(422, 35);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LavenderBlush;
            btnSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.PaleVioletRed;
            btnSearch.Location = new Point(1070, 126);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(135, 36);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvBoooks
            // 
            dgvBoooks.BackgroundColor = Color.LavenderBlush;
            dgvBoooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBoooks.Location = new Point(444, 258);
            dgvBoooks.Margin = new Padding(2);
            dgvBoooks.Name = "dgvBoooks";
            dgvBoooks.ReadOnly = true;
            dgvBoooks.RowHeadersWidth = 51;
            dgvBoooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBoooks.Size = new Size(1018, 502);
            dgvBoooks.TabIndex = 3;
            dgvBoooks.CellClick += dgvBoooks_CellClick;
            // 
            // btnLoadBookshelf
            // 
            btnLoadBookshelf.BackColor = Color.LavenderBlush;
            btnLoadBookshelf.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadBookshelf.ForeColor = Color.PaleVioletRed;
            btnLoadBookshelf.Location = new Point(15, 126);
            btnLoadBookshelf.Margin = new Padding(2);
            btnLoadBookshelf.Name = "btnLoadBookshelf";
            btnLoadBookshelf.Size = new Size(241, 36);
            btnLoadBookshelf.TabIndex = 4;
            btnLoadBookshelf.Text = "Load kệ sách của tôi";
            btnLoadBookshelf.UseVisualStyleBackColor = false;
            btnLoadBookshelf.Click += btnLoadBookshelf_Click;
            // 
            // lbNhap
            // 
            lbNhap.AutoSize = true;
            lbNhap.BackColor = Color.Transparent;
            lbNhap.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNhap.ForeColor = Color.PaleVioletRed;
            lbNhap.Location = new Point(444, 130);
            lbNhap.Margin = new Padding(4, 0, 4, 0);
            lbNhap.Name = "lbNhap";
            lbNhap.Size = new Size(154, 30);
            lbNhap.TabIndex = 7;
            lbNhap.Text = "Nhập tên sách";
            // 
            // labelBookList
            // 
            labelBookList.AutoSize = true;
            labelBookList.BackColor = Color.Transparent;
            labelBookList.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBookList.ForeColor = Color.PaleVioletRed;
            labelBookList.Location = new Point(444, 206);
            labelBookList.Margin = new Padding(4, 0, 4, 0);
            labelBookList.Name = "labelBookList";
            labelBookList.Size = new Size(218, 30);
            labelBookList.TabIndex = 8;
            labelBookList.Text = "Danh sách cuốn sách";
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.LavenderBlush;
            buttonExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExit.ForeColor = Color.PaleVioletRed;
            buttonExit.Location = new Point(1344, 841);
            buttonExit.Margin = new Padding(2);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(118, 36);
            buttonExit.TabIndex = 12;
            buttonExit.Text = "Thoát";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = Color.Transparent;
            labelName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelName.ForeColor = Color.PaleVioletRed;
            labelName.Location = new Point(14, 851);
            labelName.Margin = new Padding(2, 0, 2, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(102, 28);
            labelName.TabIndex = 13;
            labelName.Text = "Welcome, ";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(444, 784);
            progressBar.Margin = new Padding(2);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1018, 34);
            progressBar.TabIndex = 14;
            progressBar.Visible = false;
            // 
            // dgvShelf
            // 
            dgvShelf.BackgroundColor = Color.LavenderBlush;
            dgvShelf.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShelf.Location = new Point(15, 258);
            dgvShelf.Margin = new Padding(2);
            dgvShelf.Name = "dgvShelf";
            dgvShelf.ReadOnly = true;
            dgvShelf.RowHeadersWidth = 51;
            dgvShelf.Size = new Size(385, 502);
            dgvShelf.TabIndex = 15;
            dgvShelf.CellDoubleClick += dgvShelf_CellDoubleClick;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.LavenderBlush;
            btnAddBook.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddBook.ForeColor = Color.PaleVioletRed;
            btnAddBook.Location = new Point(14, 199);
            btnAddBook.Margin = new Padding(2);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(242, 36);
            btnAddBook.TabIndex = 19;
            btnAddBook.Text = "Thêm sách vào kệ";
            btnAddBook.UseVisualStyleBackColor = false;
            // 
            // Searchform
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Download_Free_Vectors__Images__Photos___Videos___Vecteezy;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1475, 891);
            Controls.Add(btnAddBook);
            Controls.Add(dgvShelf);
            Controls.Add(progressBar);
            Controls.Add(labelName);
            Controls.Add(buttonExit);
            Controls.Add(labelBookList);
            Controls.Add(lbNhap);
            Controls.Add(btnLoadBookshelf);
            Controls.Add(dgvBoooks);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Searchform";
            Text = "Tìm kiếm sách";
            ((System.ComponentModel.ISupportInitialize)dgvBoooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvShelf).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvBoooks;
        private Button btnLoadBookshelf;
        private Label lbNhap;
        private Label labelBookList;
        private Button buttonExit;
        private Label labelName;
        private ProgressBar progressBar;
        private DataGridView dgvShelf;
        private Button btnAddBook;
    }
}