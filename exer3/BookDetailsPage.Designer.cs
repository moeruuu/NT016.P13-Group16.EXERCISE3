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
            progressBar = new ProgressBar();
            btnExit = new Button();
            picBookcover = new PictureBox();
            lbNotFoundCover = new Label();
            rtbDescription = new RichTextBox();
            lbDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)picBookcover).BeginInit();
            SuspendLayout();
            // 
            // rtbBookDetails
            // 
            rtbBookDetails.BackColor = Color.LavenderBlush;
            rtbBookDetails.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbBookDetails.ForeColor = Color.PaleVioletRed;
            rtbBookDetails.Location = new Point(389, 72);
            rtbBookDetails.Margin = new Padding(4, 4, 4, 4);
            rtbBookDetails.Name = "rtbBookDetails";
            rtbBookDetails.ReadOnly = true;
            rtbBookDetails.Size = new Size(565, 155);
            rtbBookDetails.TabIndex = 0;
            rtbBookDetails.Text = "";
            // 
            // labelBookDetail
            // 
            labelBookDetail.AutoSize = true;
            labelBookDetail.BackColor = Color.Transparent;
            labelBookDetail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBookDetail.ForeColor = Color.PaleVioletRed;
            labelBookDetail.Location = new Point(389, 11);
            labelBookDetail.Margin = new Padding(4, 0, 4, 0);
            labelBookDetail.Name = "labelBookDetail";
            labelBookDetail.Size = new Size(210, 38);
            labelBookDetail.TabIndex = 1;
            labelBookDetail.Text = "Thông tin sách";
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.LavenderBlush;
            progressBar.ForeColor = Color.PaleVioletRed;
            progressBar.Location = new Point(39, 511);
            progressBar.Margin = new Padding(4, 4, 4, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(708, 36);
            progressBar.TabIndex = 4;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LavenderBlush;
            btnExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.PaleVioletRed;
            btnExit.Location = new Point(754, 511);
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
            picBookcover.Location = new Point(39, 72);
            picBookcover.Margin = new Padding(2);
            picBookcover.Name = "picBookcover";
            picBookcover.Size = new Size(306, 398);
            picBookcover.SizeMode = PictureBoxSizeMode.Zoom;
            picBookcover.TabIndex = 6;
            picBookcover.TabStop = false;
            // 
            // lbNotFoundCover
            // 
            lbNotFoundCover.Font = new Font("Cambria", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNotFoundCover.ForeColor = SystemColors.ButtonShadow;
            lbNotFoundCover.Location = new Point(48, 256);
            lbNotFoundCover.Margin = new Padding(4, 0, 4, 0);
            lbNotFoundCover.Name = "lbNotFoundCover";
            lbNotFoundCover.Size = new Size(290, 50);
            lbNotFoundCover.TabIndex = 7;
            lbNotFoundCover.Text = "Không tìm thấy ảnh bìa của cuốn sách này :((";
            lbNotFoundCover.TextAlign = ContentAlignment.MiddleCenter;
            lbNotFoundCover.Visible = false;
            // 
            // rtbDescription
            // 
            rtbDescription.BackColor = Color.LavenderBlush;
            rtbDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbDescription.ForeColor = Color.PaleVioletRed;
            rtbDescription.Location = new Point(389, 261);
            rtbDescription.Margin = new Padding(4, 4, 4, 4);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.ReadOnly = true;
            rtbDescription.Size = new Size(565, 208);
            rtbDescription.TabIndex = 8;
            rtbDescription.Text = "";
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.BackColor = Color.Transparent;
            lbDescription.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDescription.ForeColor = Color.PaleVioletRed;
            lbDescription.Location = new Point(389, 232);
            lbDescription.Margin = new Padding(4, 0, 4, 0);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(72, 25);
            lbDescription.TabIndex = 9;
            lbDescription.Text = "Mô tả:";
            // 
            // BookDetailsPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Download_Free_Vectors__Images__Photos___Videos___Vecteezy;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(970, 562);
            Controls.Add(lbDescription);
            Controls.Add(rtbDescription);
            Controls.Add(lbNotFoundCover);
            Controls.Add(picBookcover);
            Controls.Add(btnExit);
            Controls.Add(progressBar);
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
        private ProgressBar progressBar;
        private Button btnExit;
        private PictureBox picBookcover;
        private Label lbNotFoundCover;
        private RichTextBox rtbDescription;
        private Label lbDescription;
    }
}