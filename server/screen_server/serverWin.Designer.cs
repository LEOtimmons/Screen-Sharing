namespace screen_server
{
    partial class serverWin
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
            this.screenView = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.endView = new System.Windows.Forms.Button();
            this.ipShowLabel = new System.Windows.Forms.Label();
            this.IPShowBox = new System.Windows.Forms.TextBox();
            this.ListeningPortLabel = new System.Windows.Forms.Label();
            this.ListeningPort = new System.Windows.Forms.TextBox();
            this.serverStartButton = new System.Windows.Forms.Button();
            this.serverStatusBox = new System.Windows.Forms.TextBox();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.terminalListBox = new System.Windows.Forms.TextBox();
            this.terminalListLabel = new System.Windows.Forms.Label();
            this.getPort = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // screenView
            // 
            this.screenView.Enabled = false;
            this.screenView.Location = new System.Drawing.Point(127, 406);
            this.screenView.Name = "screenView";
            this.screenView.Size = new System.Drawing.Size(75, 23);
            this.screenView.TabIndex = 0;
            this.screenView.Text = "預覽";
            this.screenView.UseVisualStyleBackColor = true;
            this.screenView.Click += new System.EventHandler(this.screenView_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(524, 388);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // endView
            // 
            this.endView.Enabled = false;
            this.endView.Location = new System.Drawing.Point(321, 406);
            this.endView.Name = "endView";
            this.endView.Size = new System.Drawing.Size(75, 23);
            this.endView.TabIndex = 2;
            this.endView.Text = "結束預覽";
            this.endView.UseVisualStyleBackColor = true;
            this.endView.Click += new System.EventHandler(this.endView_Click);
            // 
            // ipShowLabel
            // 
            this.ipShowLabel.AutoSize = true;
            this.ipShowLabel.Location = new System.Drawing.Point(565, 21);
            this.ipShowLabel.Name = "ipShowLabel";
            this.ipShowLabel.Size = new System.Drawing.Size(56, 12);
            this.ipShowLabel.TabIndex = 3;
            this.ipShowLabel.Text = "Local IP：";
            // 
            // IPShowBox
            // 
            this.IPShowBox.Location = new System.Drawing.Point(567, 36);
            this.IPShowBox.Name = "IPShowBox";
            this.IPShowBox.ReadOnly = true;
            this.IPShowBox.Size = new System.Drawing.Size(179, 22);
            this.IPShowBox.TabIndex = 4;
            // 
            // ListeningPortLabel
            // 
            this.ListeningPortLabel.AutoSize = true;
            this.ListeningPortLabel.Location = new System.Drawing.Point(567, 64);
            this.ListeningPortLabel.Name = "ListeningPortLabel";
            this.ListeningPortLabel.Size = new System.Drawing.Size(36, 12);
            this.ListeningPortLabel.TabIndex = 5;
            this.ListeningPortLabel.Text = "Port：";
            // 
            // ListeningPort
            // 
            this.ListeningPort.Location = new System.Drawing.Point(569, 80);
            this.ListeningPort.Name = "ListeningPort";
            this.ListeningPort.Size = new System.Drawing.Size(49, 22);
            this.ListeningPort.TabIndex = 6;
            // 
            // serverStartButton
            // 
            this.serverStartButton.Location = new System.Drawing.Point(668, 222);
            this.serverStartButton.Name = "serverStartButton";
            this.serverStartButton.Size = new System.Drawing.Size(65, 22);
            this.serverStartButton.TabIndex = 7;
            this.serverStartButton.Text = "Start";
            this.serverStartButton.UseVisualStyleBackColor = true;
            this.serverStartButton.Click += new System.EventHandler(this.serverStartButton_Click);
            // 
            // serverStatusBox
            // 
            this.serverStatusBox.Location = new System.Drawing.Point(569, 126);
            this.serverStatusBox.Multiline = true;
            this.serverStatusBox.Name = "serverStatusBox";
            this.serverStatusBox.ReadOnly = true;
            this.serverStatusBox.Size = new System.Drawing.Size(177, 90);
            this.serverStatusBox.TabIndex = 8;
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Location = new System.Drawing.Point(569, 108);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(77, 12);
            this.serverStatusLabel.TabIndex = 9;
            this.serverStatusLabel.Text = "伺服器狀態：";
            // 
            // terminalListBox
            // 
            this.terminalListBox.Location = new System.Drawing.Point(567, 282);
            this.terminalListBox.Multiline = true;
            this.terminalListBox.Name = "terminalListBox";
            this.terminalListBox.ReadOnly = true;
            this.terminalListBox.Size = new System.Drawing.Size(179, 118);
            this.terminalListBox.TabIndex = 10;
            // 
            // terminalListLabel
            // 
            this.terminalListLabel.AutoSize = true;
            this.terminalListLabel.Location = new System.Drawing.Point(567, 264);
            this.terminalListLabel.Name = "terminalListLabel";
            this.terminalListLabel.Size = new System.Drawing.Size(53, 12);
            this.terminalListLabel.TabIndex = 11;
            this.terminalListLabel.Text = "已連接：";
            // 
            // getPort
            // 
            this.getPort.Location = new System.Drawing.Point(571, 222);
            this.getPort.Name = "getPort";
            this.getPort.Size = new System.Drawing.Size(75, 23);
            this.getPort.TabIndex = 12;
            this.getPort.Text = "Listen";
            this.getPort.UseVisualStyleBackColor = true;
            this.getPort.Click += new System.EventHandler(this.getPort_Click);
            // 
            // disconnect
            // 
            this.disconnect.Enabled = false;
            this.disconnect.Location = new System.Drawing.Point(616, 406);
            this.disconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(86, 23);
            this.disconnect.TabIndex = 13;
            this.disconnect.Text = "中斷伺服器";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // serverWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 449);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.getPort);
            this.Controls.Add(this.terminalListLabel);
            this.Controls.Add(this.terminalListBox);
            this.Controls.Add(this.serverStatusLabel);
            this.Controls.Add(this.serverStatusBox);
            this.Controls.Add(this.serverStartButton);
            this.Controls.Add(this.ListeningPort);
            this.Controls.Add(this.ListeningPortLabel);
            this.Controls.Add(this.IPShowBox);
            this.Controls.Add(this.ipShowLabel);
            this.Controls.Add(this.endView);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.screenView);
            this.Name = "serverWin";
            this.Text = "伺服器端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.serverWin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button screenView;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button endView;
        private System.Windows.Forms.Label ipShowLabel;
        private System.Windows.Forms.TextBox IPShowBox;
        private System.Windows.Forms.Label ListeningPortLabel;
        private System.Windows.Forms.TextBox ListeningPort;
        private System.Windows.Forms.Button serverStartButton;
        private System.Windows.Forms.TextBox serverStatusBox;
        private System.Windows.Forms.Label serverStatusLabel;
        private System.Windows.Forms.TextBox terminalListBox;
        private System.Windows.Forms.Label terminalListLabel;
        private System.Windows.Forms.Button getPort;
        private System.Windows.Forms.Button disconnect;
    }
}

