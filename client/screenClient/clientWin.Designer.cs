namespace screenClient
{
    partial class clientWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.disconnect = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.configBox2 = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.configBox = new screenClient.WatermarkTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.disconnect);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 553);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(736, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = " 客戶端狀態";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(738, 488);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(87, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "等待連接中...";
            // 
            // disconnect
            // 
            this.disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnect.Enabled = false;
            this.disconnect.Location = new System.Drawing.Point(738, 436);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 23);
            this.disconnect.TabIndex = 1;
            this.disconnect.Text = "中斷連線";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(732, 553);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.configBox);
            this.panel2.Controls.Add(this.configBox2);
            this.panel2.Controls.Add(this.startButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 532);
            this.panel2.MinimumSize = new System.Drawing.Size(0, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 21);
            this.panel2.TabIndex = 1;
            // 
            // configBox2
            // 
            this.configBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configBox2.Location = new System.Drawing.Point(0, 0);
            this.configBox2.Name = "configBox2";
            this.configBox2.Size = new System.Drawing.Size(712, 22);
            this.configBox2.TabIndex = 1;
            this.configBox2.Text = "請輸入 IP :Port";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(738, 0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 21);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "連接並接收";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // configBox
            // 
            this.configBox.Location = new System.Drawing.Point(0, -1);
            this.configBox.Name = "configBox";
            this.configBox.Size = new System.Drawing.Size(712, 22);
            this.configBox.TabIndex = 4;
            this.configBox.WatermarkText = "請輸入IP:Port";
            // 
            // clientWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "clientWin";
            this.Text = "客戶端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.clientWin_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox configBox2;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private WatermarkTextBox configBox;
    }
}

