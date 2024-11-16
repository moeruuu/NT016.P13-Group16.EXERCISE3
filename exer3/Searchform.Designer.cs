namespace exer3
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
            btnCreateBookshelf = new Button();
            txtBookshelfTitle = new TextBox();
            txtBookshelfDescription = new TextBox();
            label2 = new Label();
            labelBookList = new Label();
            labelShelfName = new Label();
            labelShelfDiscription = new Label();
            buttonExit = new Button();
            labelName = new Label();
            progressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dgvBoooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.PaleVioletRed;
            label1.Location = new Point(365, 39);
            label1.Name = "label1";
            label1.Size = new Size(185, 31);
            label1.TabIndex = 0;
            label1.Text = "TÌM KIẾM SÁCH";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.LavenderBlush;
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.PaleVioletRed;
            txtSearch.Location = new Point(246, 106);
            txtSearch.Margin = new Padding(2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(244, 30);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LavenderBlush;
            btnSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.PaleVioletRed;
            btnSearch.Location = new Point(574, 110);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(108, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvBoooks
            // 
            dgvBoooks.BackgroundColor = Color.LavenderBlush;
            dgvBoooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBoooks.Location = new Point(74, 210);
            dgvBoooks.Margin = new Padding(2);
            dgvBoooks.Name = "dgvBoooks";
            dgvBoooks.ReadOnly = true;
            dgvBoooks.RowHeadersWidth = 51;
            dgvBoooks.Size = new Size(416, 216);
            dgvBoooks.TabIndex = 3;
            dgvBoooks.CellClick += dgvBoooks_CellClick;
            // 
            // btnCreateBookshelf
            // 
            btnCreateBookshelf.BackColor = Color.LavenderBlush;
            btnCreateBookshelf.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateBookshelf.ForeColor = Color.PaleVioletRed;
            btnCreateBookshelf.Location = new Point(596, 327);
            btnCreateBookshelf.Margin = new Padding(2);
            btnCreateBookshelf.Name = "btnCreateBookshelf";
            btnCreateBookshelf.Size = new Size(128, 29);
            btnCreateBookshelf.TabIndex = 4;
            btnCreateBookshelf.Text = "Tạo kệ sách";
            btnCreateBookshelf.UseVisualStyleBackColor = false;
            // 
            // txtBookshelfTitle
            // 
            txtBookshelfTitle.BackColor = Color.LavenderBlush;
            txtBookshelfTitle.ForeColor = Color.PaleVioletRed;
            txtBookshelfTitle.Location = new Point(637, 180);
            txtBookshelfTitle.Margin = new Padding(2);
            txtBookshelfTitle.Name = "txtBookshelfTitle";
            txtBookshelfTitle.Size = new Size(237, 27);
            txtBookshelfTitle.TabIndex = 5;
            // 
            // txtBookshelfDescription
            // 
            txtBookshelfDescription.BackColor = Color.LavenderBlush;
            txtBookshelfDescription.ForeColor = Color.PaleVioletRed;
            txtBookshelfDescription.Location = new Point(637, 252);
            txtBookshelfDescription.Margin = new Padding(2);
            txtBookshelfDescription.Name = "txtBookshelfDescription";
            txtBookshelfDescription.Size = new Size(234, 27);
            txtBookshelfDescription.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.PaleVioletRed;
            label2.Location = new Point(74, 110);
            label2.Name = "label2";
            label2.Size = new Size(123, 23);
            label2.TabIndex = 7;
            label2.Text = "Nhập tên sách";
            // 
            // labelBookList
            // 
            labelBookList.AutoSize = true;
            labelBookList.BackColor = Color.Transparent;
            labelBookList.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBookList.ForeColor = Color.PaleVioletRed;
            labelBookList.Location = new Point(74, 156);
            labelBookList.Name = "labelBookList";
            labelBookList.Size = new Size(173, 23);
            labelBookList.TabIndex = 8;
            labelBookList.Text = "Danh sách cuốn sách";
            // 
            // labelShelfName
            // 
            labelShelfName.AutoSize = true;
            labelShelfName.BackColor = Color.Transparent;
            labelShelfName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelShelfName.ForeColor = Color.PaleVioletRed;
            labelShelfName.Location = new Point(546, 184);
            labelShelfName.Name = "labelShelfName";
            labelShelfName.Size = new Size(61, 23);
            labelShelfName.TabIndex = 9;
            labelShelfName.Text = "Tên kệ";
            // 
            // labelShelfDiscription
            // 
            labelShelfDiscription.AutoSize = true;
            labelShelfDiscription.BackColor = Color.Transparent;
            labelShelfDiscription.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelShelfDiscription.ForeColor = Color.PaleVioletRed;
            labelShelfDiscription.Location = new Point(546, 253);
            labelShelfDiscription.Name = "labelShelfDiscription";
            labelShelfDiscription.Size = new Size(57, 23);
            labelShelfDiscription.TabIndex = 10;
            labelShelfDiscription.Text = "Mô tả";
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.LavenderBlush;
            buttonExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExit.ForeColor = Color.PaleVioletRed;
            buttonExit.Location = new Point(777, 327);
            buttonExit.Margin = new Padding(2);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(94, 29);
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
            labelName.Location = new Point(10, 489);
            labelName.Margin = new Padding(2, 0, 2, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(89, 23);
            labelName.TabIndex = 13;
            labelName.Text = "Welcome, ";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(74, 441);
            progressBar.Margin = new Padding(2);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(416, 27);
            progressBar.TabIndex = 14;
            // 
            // Searchform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Download_Free_Vectors__Images__Photos___Videos___Vecteezy;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(931, 518);
            Controls.Add(progressBar);
            Controls.Add(labelName);
            Controls.Add(buttonExit);
            Controls.Add(labelShelfDiscription);
            Controls.Add(labelShelfName);
            Controls.Add(labelBookList);
            Controls.Add(label2);
            Controls.Add(txtBookshelfDescription);
            Controls.Add(txtBookshelfTitle);
            Controls.Add(btnCreateBookshelf);
            Controls.Add(dgvBoooks);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "Searchform";
            Text = "Tìm kiếm sách";
            ((System.ComponentModel.ISupportInitialize)dgvBoooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvBoooks;
        private Button btnCreateBookshelf;
        private TextBox txtBookshelfTitle;
        private TextBox txtBookshelfDescription;
        private Label label2;
        private Label labelBookList;
        private Label labelShelfName;
        private Label labelShelfDiscription;
        private Button buttonExit;
        private Label labelName;
        private ProgressBar progressBar;
    }
}