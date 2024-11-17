namespace exer3
{
    partial class BookDetailsPage
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
            rtbBookDetails = new RichTextBox();
            labelBookDetail = new Label();
            btnAddToShelf = new Button();
            btnRemoveFromShelf = new Button();
            progressBar = new ProgressBar();
            btnExit = new Button();
            picBookcover = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picBookcover).BeginInit();
            SuspendLayout();
            // 
            // rtbBookDetails
            // 
            rtbBookDetails.BackColor = Color.LavenderBlush;
            rtbBookDetails.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbBookDetails.ForeColor = Color.PaleVioletRed;
            rtbBookDetails.Location = new Point(231, 152);
            rtbBookDetails.Margin = new Padding(4, 4, 4, 4);
            rtbBookDetails.Name = "rtbBookDetails";
            rtbBookDetails.Size = new Size(404, 198);
            rtbBookDetails.TabIndex = 0;
            rtbBookDetails.Text = "";
            // 
            // labelBookDetail
            // 
            labelBookDetail.AutoSize = true;
            labelBookDetail.BackColor = Color.Transparent;
            labelBookDetail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBookDetail.ForeColor = Color.PaleVioletRed;
            labelBookDetail.Location = new Point(360, 52);
            labelBookDetail.Margin = new Padding(4, 0, 4, 0);
            labelBookDetail.Name = "labelBookDetail";
            labelBookDetail.Size = new Size(210, 38);
            labelBookDetail.TabIndex = 1;
            labelBookDetail.Text = "Thông tin sách";
            // 
            // btnAddToShelf
            // 
            btnAddToShelf.AutoSize = true;
            btnAddToShelf.BackColor = Color.LavenderBlush;
            btnAddToShelf.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToShelf.ForeColor = Color.PaleVioletRed;
            btnAddToShelf.Location = new Point(675, 149);
            btnAddToShelf.Margin = new Padding(4, 4, 4, 4);
            btnAddToShelf.Name = "btnAddToShelf";
            btnAddToShelf.Size = new Size(201, 41);
            btnAddToShelf.TabIndex = 2;
            btnAddToShelf.Text = "Thêm vào kệ sách";
            btnAddToShelf.UseVisualStyleBackColor = false;
            // 
            // btnRemoveFromShelf
            // 
            btnRemoveFromShelf.AutoSize = true;
            btnRemoveFromShelf.BackColor = Color.LavenderBlush;
            btnRemoveFromShelf.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveFromShelf.ForeColor = Color.PaleVioletRed;
            btnRemoveFromShelf.Location = new Point(675, 229);
            btnRemoveFromShelf.Margin = new Padding(4, 4, 4, 4);
            btnRemoveFromShelf.Name = "btnRemoveFromShelf";
            btnRemoveFromShelf.Size = new Size(201, 41);
            btnRemoveFromShelf.TabIndex = 3;
            btnRemoveFromShelf.Text = "Xóa khỏi kệ sách";
            btnRemoveFromShelf.UseVisualStyleBackColor = false;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.LavenderBlush;
            progressBar.ForeColor = Color.PaleVioletRed;
            progressBar.Location = new Point(39, 417);
            progressBar.Margin = new Padding(4, 4, 4, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(597, 36);
            progressBar.TabIndex = 4;
            progressBar.Click += progressBar1_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LavenderBlush;
            btnExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.PaleVioletRed;
            btnExit.Location = new Point(675, 311);
            btnExit.Margin = new Padding(4, 4, 4, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(201, 36);
            btnExit.TabIndex = 5;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += buttonExit_Click;
            // 
            // picBookcover
            // 
            picBookcover.Location = new Point(39, 152);
            picBookcover.Name = "picBookcover";
            picBookcover.Size = new Size(150, 198);
            picBookcover.TabIndex = 6;
            picBookcover.TabStop = false;
            // 
            // BookDetailsPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Download_Free_Vectors__Images__Photos___Videos___Vecteezy;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1000, 562);
            Controls.Add(picBookcover);
            Controls.Add(btnExit);
            Controls.Add(progressBar);
            Controls.Add(btnRemoveFromShelf);
            Controls.Add(btnAddToShelf);
            Controls.Add(labelBookDetail);
            Controls.Add(rtbBookDetails);
            Margin = new Padding(4, 4, 4, 4);
            Name = "BookDetailsPage";
            Text = "Thông tin sách";
            ((System.ComponentModel.ISupportInitialize)picBookcover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbBookDetails;
        private Label labelBookDetail;
        private Button btnAddToShelf;
        private Button btnRemoveFromShelf;
        private ProgressBar progressBar;
        private Button btnExit;
        private PictureBox picBookcover;
    }
}