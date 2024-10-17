namespace exercise3
{
    partial class TCPserver
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCPserver));
            txtPort = new TextBox();
            label1 = new Label();
            lblStatus = new Label();
            lstLog = new ListBox();
            btnStart = new Button();
            btnStop = new Button();
            SuspendLayout();
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Trebuchet MS", 11F);
            txtPort.Location = new Point(134, 35);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(242, 33);
            txtPort.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Trebuchet MS", 11F);
            label1.Location = new Point(43, 38);
            label1.Name = "label1";
            label1.Size = new Size(61, 27);
            label1.TabIndex = 1;
            label1.Text = "Port:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Trebuchet MS", 11F);
            lblStatus.Location = new Point(43, 120);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 27);
            lblStatus.TabIndex = 2;
            // 
            // lstLog
            // 
            lstLog.Font = new Font("Trebuchet MS", 11F);
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 27;
            lstLog.Location = new Point(439, 38);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(330, 355);
            lstLog.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.AutoSize = true;
            btnStart.BackColor = SystemColors.ButtonFace;
            btnStart.FlatAppearance.BorderColor = Color.SlateBlue;
            btnStart.FlatAppearance.BorderSize = 3;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Trebuchet MS", 11F);
            btnStart.Location = new Point(43, 328);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(144, 65);
            btnStart.TabIndex = 4;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            btnStop.AutoSize = true;
            btnStop.BackColor = SystemColors.ButtonFace;
            btnStop.FlatAppearance.BorderColor = Color.SlateBlue;
            btnStop.FlatAppearance.BorderSize = 3;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Trebuchet MS", 11F);
            btnStop.Location = new Point(232, 328);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(144, 65);
            btnStop.TabIndex = 5;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = false;
            // 
            // TCPserver
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lstLog);
            Controls.Add(lblStatus);
            Controls.Add(label1);
            Controls.Add(txtPort);
            Name = "TCPserver";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPort;
        private Label label1;
        private Label lblStatus;
        private ListBox lstLog;
        private Button btnStart;
        private Button btnStop;
    }
}
