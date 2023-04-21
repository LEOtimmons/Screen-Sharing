using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace screen_server
{
    class Server
    {
        private string localIP;
        private Bitmap screenNow;
        //private string[] terminalList;
        private int listenPort;
        private int screenHeight;
        private int screenWidth;
        private bool isWork;
        private byte[] buffer;
        private string errorMessage;
        private Socket server;
        Thread myThread;
        Thread catchScreen;
        //Thread sendThread;

        public Server(int listenPort)
        {
            screenWidth  = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //screenWidth = 1920;
            //screenHeight = 1080;
            ScreenNow = new Bitmap(screenWidth, screenHeight);
            IsWork = false;

            this.listenPort = listenPort;
            //獲得Loacl IP
            try
            {
                string HostName = Dns.GetHostName(); //Host Name
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        LocalIP = IpEntry.AddressList[i].ToString();
                        //可用來限制IP位置或網域
                        if (IpEntry.AddressList[i].ToString().Contains("127.0.0.1") || IpEntry.AddressList[i].ToString().Contains("114.213"))
                        {
                            LocalIP = IpEntry.AddressList[i].ToString();
                            break;
                        }
                    }
                }
                //若是沒有符合上面的限制，則設為空
                if (LocalIP == null)
                    LocalIP = "";
            }
            catch (Exception ex)
            {
                errorMessage =  ex.Message;
                showErrorMessage();
            }
        }
        
        //public string[] TerminalList { get => terminalList; set => terminalList = value; }

        public Dictionary<string, Socket> ClientConnectionItems = new Dictionary<string, Socket> { };
        public Dictionary<Socket, Thread> keyValuePairs = new Dictionary<Socket, Thread>();
        public string LocalIP { get => localIP; set => localIP = value; }
        public Bitmap ScreenNow { get => screenNow; set => screenNow = value; }
        public bool IsWork { get => isWork; set => isWork = value; }

        public void showErrorMessage()
        {
            
        }

        public void close_socket()
        {
            this.server.Close();
            myThread.Abort();
            catchScreen.Abort();           
            foreach (var item in keyValuePairs)
            {
                item.Key.Close();
                item.Value.Abort();
                //keyValuePairs.Remove(item.Key);
            }
            keyValuePairs.Clear();

            //if (sendThread!=null)
            //    sendThread.Abort();
            if (catchScreen != null)
                catchScreen.Abort();
            
            //this.server.Dispose();
            
            Console.WriteLine(this.ClientConnectionItems);
        }

        public void startService()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress ip = IPAddress.Parse(localIP);
            IPAddress ip = IPAddress.Parse("26.205.213.71");
            server.Bind(new IPEndPoint(ip, listenPort));
            server.Listen(10);
            myThread = new Thread(ListenClientConnect);
            myThread.Start();
            catchScreen = new Thread(screenUpdate);
            catchScreen.Start();
            IsWork = true;
        }

        private void ListenClientConnect()
        {
            while (true)
            {
                Socket client = server.Accept();
                Thread sendThread = new Thread(sendPic);
                sendThread.Start(client);
                ClientConnectionItems.Add(client.RemoteEndPoint.ToString(),client);
                keyValuePairs.Add(client, sendThread);
            }
        }


        private void screenUpdate()
        {
            Bitmap temp = new Bitmap(screenWidth, screenHeight);
            Graphics gc = Graphics.FromImage(temp);
            while (true)
            {
                gc.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(screenWidth, screenHeight));
                imgtoBytes(temp);
                screenNow = new Bitmap(temp);
                GC.Collect();
                Thread.Sleep(20);
            }
        }
        
        private void imgtoBytes(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            buffer = ms.GetBuffer();
            ms.Close();
        }

        private void sendPic(object clientSocket)
        {
            Socket client = (Socket)clientSocket;
            byte[] receiveBuffer = new byte[1024];
            byte[] imageCopy;
            while (true)
            {
                lock (this)
                {
                    try
                    {
                        if (buffer != null)
                        {
                            //Client發送確認後才開始傳送
                            int receiveLength = client.Receive(receiveBuffer);
                            imageCopy = new byte[buffer.Length];
                            Buffer.BlockCopy(buffer, 0, imageCopy, 0, buffer.Length);
                            byte[] dataLength = BitConverter.GetBytes(imageCopy.Length);
                            client.Send(dataLength);
                            receiveLength = client.Receive(receiveBuffer);
                            client.Send(imageCopy);
                        }
                    }
                    catch
                    {
                        if (client.Connected)
                        {
                            ClientConnectionItems.Remove(client.RemoteEndPoint.ToString());
                            client.Close();
                            break;
                        }

                    }
                }
            }
        }
    }
}
