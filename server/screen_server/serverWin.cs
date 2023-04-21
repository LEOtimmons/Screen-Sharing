using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace screen_server
{
    public partial class serverWin : Form
    {
        private Server server;
        //private Bitmap screenPic;
        private bool needShowScreen;
        //伺服器Listen thread
        private static Thread serverWinThread;
        private static Thread updateThread;


        public serverWin()
        {
            InitializeComponent();
        }



        private void serverStartButton_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                MessageBox.Show("請先申請Port！");
            }
            else
            {
                serverWinThread = new Thread(server.startService);
                serverWinThread.IsBackground = true;
                serverWinThread.Start();
                MessageBox.Show("伺服器成功運作！");
                screenView.Enabled = true;
                endView.Enabled = true;
                disconnect.Enabled = true;
                updateThread = new Thread(updateconnection);
                updateThread.IsBackground = true;
                updateThread.Start();
                this.serverStatusBox.Text += "Port：" + ListeningPort.Text + " 開啟完成！\r\n";
            }
        }

        private void updateconnection()
        {
            if (this.InvokeRequired)
                {
                    while (true)
                    {
                    foreach (string a in server.ClientConnectionItems.Keys)
                        terminalListBox.Invoke(new Action(() => terminalListBox.Text += a + "\r\n"));
                    Thread.Sleep(500);
                    terminalListBox.Invoke(new Action(() => terminalListBox.Text = ""));
                    }
                }               
        }

        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
        private void showScreen()
        {
            needShowScreen = true;
            Bitmap screen;
            while (needShowScreen)
            {
                screen = new Bitmap(server.ScreenNow);
                GC.Collect();
                pictureBox.Image = ResizeImage(screen,pictureBox.Width,pictureBox.Height);
            }
        }


        private void screenView_Click(object sender, EventArgs e)
        {
            if(server==null || !server.IsWork)
            {
                MessageBox.Show("請先啟動服務！");
            }
            Thread drawScreen = new Thread(showScreen);
            drawScreen.Start();
        }
        

        private void endView_Click(object sender, EventArgs e)
        {
            needShowScreen = false;
            pictureBox.Image = null;
        }

        private void getPort_Click(object sender, EventArgs e)
        {
            int port = 0;
            try
            {
                port = Convert.ToInt32(this.ListeningPort.Text);
            }
            catch
            {
                MessageBox.Show("Port請輸入正確格式");
                return;
            }
            if(port<10000 || port > 65534)
            {
                MessageBox.Show("Port請輸入10000-65534之間的數字！");
                return;
            }
            else
            {
                try
                {
                    server = new Server(port);
                    this.IPShowBox.Text = server.LocalIP;
                    this.serverStatusBox.Text = "Port：" + ListeningPort.Text+" 準備完成！\r\n";
                }
                catch
                {

                }
                MessageBox.Show("Port申請成功！");
            }
        }

        private void serverWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("伺服器準備關閉...");
            Application.Exit();
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            MessageBox.Show("伺服器終止中...");
            this.serverStatusBox.Text = "伺服器離線!";
            screenView.Enabled = false;
            endView.Enabled = false;
            disconnect.Enabled = false;
            
            serverWinThread.Abort();
            updateThread.Abort();
            server.close_socket();
        }
    }
}
