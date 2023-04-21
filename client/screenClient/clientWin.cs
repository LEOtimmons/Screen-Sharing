using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace screenClient
{
    public partial class clientWin : Form
    {
        IPAddress ip;
        string IP;
        int port;
        bool disconnectClick = false;
        bool serverdisconnect = false;
        Socket clientSocket;
        Thread imageUpdate;
        public clientWin()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string ipPort = configBox.Text;
            string[] config = ipPort.Split(':');
            if (config.Length!=2)
            {
                MessageBox.Show("請輸入正確的IP、Port！");
                return;
            }
            IP = config[0];
            port = Convert.ToInt32(config[1]);
            try
            {
                ip = IPAddress.Parse(IP);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(ip, port));
                imageUpdate = new Thread(update);
                imageUpdate.Start(clientSocket);
                textBox1.Text = "已成功連接!";
                disconnect.Enabled = true;
                startButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("建立連接失敗，請重試！");
            }
        }

        private void update(object clientSocket_)
        {
            Socket client = (Socket)clientSocket_;
            int receiveNumber;
            byte[] buffer;
            byte[] image;
            while (true)
            {
                try
                {
                    //先发送一个确认连接包
                    buffer = new byte[1];
                    buffer[0] = 1;
                    client.Send(buffer);
                    //先记录数据的大小，再申请对应大小的缓冲区
                    buffer = new byte[4];
                    receiveNumber = client.Receive(buffer);
                    int dataLength = BitConverter.ToInt32(buffer, 0);
                    client.Send(buffer);
                    buffer = new byte[4096];
                    image = new byte[dataLength];
                    GC.Collect();
                    int offset = 0;
                    while (offset != dataLength)
                    {
                        receiveNumber = client.Receive(buffer);
                        Buffer.BlockCopy(buffer, 0, image, offset, receiveNumber);
                        offset += receiveNumber;
                    }
                    pictureBox.Image = getBitmap(image);
                }
                catch(Exception ex)
                {                   
                    while (true)
                    {
                        
                        if (disconnectClick==true)
                        {
                            disconnectClick = false;
                            textBox1.Invoke(new Action(() => textBox1.Text = "客戶端主動離線!"));
                            break;
                        }
                        if(serverdisconnect==false)
                        {
                            serverdisconnect = true;
                            //MessageBox.Show("伺服器斷線！");
                        }
                        try
                        {
                            ip = IPAddress.Parse(IP);
                            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            clientSocket.Connect(new IPEndPoint(ip, port));
                            imageUpdate = new Thread(update);
                            imageUpdate.IsBackground = true;
                            imageUpdate.Start(clientSocket);
                            textBox1.Invoke(new Action(() => textBox1.Text = "已成功連線!"));
                            serverdisconnect = false;
                            break;
                        }
                        catch (Exception e)
                        {
                            //
                            //此處有一BUG，當伺服器端主動中斷，客戶端跳出伺服器斷線後，若直接關閉程式
                            //會有Thread持續在背景執行，關不乾淨。
                            //
                            //
                            if (this.InvokeRequired)
                            {                                                                         
                                Thread.Sleep(500);
                                textBox1.Invoke(new Action(() => textBox1.Text = "嘗試重新連接中..."));
                            }
                        }
                    }
                    //---------------------------------------------------
                    break;
                }
            }
        }

        private Bitmap getBitmap(byte[] bytesData)
        {
            MemoryStream ms1 = new MemoryStream(bytesData);
            Bitmap bm = (Bitmap)Image.FromStream(ms1);
            ms1.Close();
            return bm;
        }

        private void clientWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("客戶端準備關閉...");
            Application.Exit();
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            MessageBox.Show("客戶端準備離線...");
            startButton.Enabled = true;
            disconnect.Enabled = false;
            disconnectClick = true;
            clientSocket.Close();
            imageUpdate.Abort();
        }
    }
}
