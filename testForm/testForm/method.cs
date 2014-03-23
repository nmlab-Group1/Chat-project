
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace chatRoomClient
{
    public class setting
    {
        public static String serverIP = "140.112.18.216";
        public static int port = 11000;
    }

    public delegate String StringHandler(String str);

    public class chatSocket
    {
        // handler
        public Socket socket;
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;
        public StringHandler strHandler;
        public EndPoint remoteEndPoint;
        public bool active = true;

        public int ID;
        public String sID;
        public int activeRoom = 0;
        public List<chatRoom> roomList = new List<chatRoom>();
        public List<userGUI> userList = new List<userGUI>();
        public Color color = new Color();

        // constructor
        public chatSocket(Socket s)
        {
            socket = s;
            stream = new NetworkStream(s);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            remoteEndPoint = socket.RemoteEndPoint;

            color = Color.Black;
        }

        // send receive ~50
        public chatSocket sendMessage(String line)
        {
            writer.WriteLine(line);
            writer.Flush();
            return this;
        }
        
        public String receiveMessage()
        {
            return reader.ReadLine();
        }

        // connection ~85
        public static chatSocket connect()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(setting.serverIP), setting.port);
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newSocket.Connect(ipep);
            return new chatSocket(newSocket);
        }

        public Thread newListener(StringHandler handler)
        {
            strHandler = handler;

            Thread listener = new Thread(new ThreadStart(listen));
            listener.Start();
            return listener;
        }

        public void listen()
        {
            try
            {
                while (true)
                {
                    String line = receiveMessage();
                    strHandler(line);
                }
            }
            catch (Exception e)
            {
                active = false;
                Console.WriteLine(e.Message);
            }
        }
    }

    public class chatRoom
    {
        public int ID;
        public String sID;

        public TabPage newRoom;
        public RichTextBox text;

        public chatRoom(int roomID, String roomsID)
        {
            ID = roomID;
            sID = roomsID;

            newRoom = new TabPage();
            text = new RichTextBox();

            text.BackColor = System.Drawing.Color.Azure;
            text.Dock = System.Windows.Forms.DockStyle.Fill;
            text.Location = new System.Drawing.Point(3, 3);
            text.Size = new System.Drawing.Size(508, 485);
            text.Text = "";

            newRoom.AllowDrop = true;
            newRoom.BackColor = System.Drawing.Color.Azure;
            newRoom.Controls.Add(text);
            newRoom.Location = new System.Drawing.Point(4, 29);
            newRoom.Padding = new System.Windows.Forms.Padding(3);
            newRoom.Size = new System.Drawing.Size(514, 491);
            newRoom.Text = roomsID;
            newRoom.Tag = roomID;
        }
    }

    public class userGUI
    {
        public chatSocket client;

        public PictureBox userPic;
        public TableLayoutPanel infoPanel;
        public Label sIDLabel;
        public FlowLayoutPanel buttonHandle;
        public Button chatButton;
        public Button fileButton;
        public Button micButton;

        public int ID;
        public String sID;

        public userGUI(int id, String sid, chatSocket clnt)
        {
            client = clnt;

            ID = id;
            sID = sid;

            userPic = new PictureBox();
            infoPanel = new TableLayoutPanel();
            sIDLabel = new Label();
            buttonHandle = new FlowLayoutPanel();
            chatButton = new Button();
            fileButton = new Button();
            micButton = new Button();

            userPic.BackColor = Color.White;
            userPic.BackgroundImage = global::chatRoomClient.Properties.Resources.defaultImage;
            userPic.BackgroundImageLayout = ImageLayout.Zoom;
            userPic.BackColor = Color.Transparent;
            userPic.Dock = DockStyle.Fill;
            userPic.Location = new Point(0, 0);
            userPic.Margin = new Padding(0);
            userPic.Size = new Size(48, 48);
            userPic.SizeMode = PictureBoxSizeMode.Zoom;

            infoPanel.ColumnCount = 1;
            infoPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoPanel.Controls.Add(this.buttonHandle, 0, 1);
            infoPanel.Controls.Add(this.sIDLabel, 0, 0);
            infoPanel.Location = new Point(48, 0);
            infoPanel.Margin = new Padding(0);
            infoPanel.RowCount = 2;
            infoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            infoPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            infoPanel.Size = new Size(199, 48);

            sIDLabel.AutoSize = true;
            sIDLabel.Dock = DockStyle.Fill;
            sIDLabel.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(136)));
            //sIDLabel.Location = new Point(3, 3);
            sIDLabel.Margin = new Padding(0);
            sIDLabel.Size = new Size(193, 18);
            this.sIDLabel.Text = sID;

            buttonHandle.Dock = DockStyle.Fill;
            buttonHandle.Location = new Point(0, 24);
            buttonHandle.Margin = new Padding(0);
            buttonHandle.Size = new Size(199, 24);

            initializeButton(chatButton, global::chatRoomClient.Properties.Resources.chatBlack);
            initializeButton(fileButton, global::chatRoomClient.Properties.Resources.folder);
            initializeButton(micButton, global::chatRoomClient.Properties.Resources.mic);
            buttonHandle.Controls.Add(chatButton);
            buttonHandle.Controls.Add(fileButton);
            buttonHandle.Controls.Add(micButton);

            chatButton.Click += new EventHandler(this.chatButton_Click);
            fileButton.Click += new EventHandler(this.fileButton_Click);
            /*
            chatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chatButton.Location = new System.Drawing.Point(3, 3);
            chatButton.Size = new System.Drawing.Size(16, 16);
            chatButton.UseVisualStyleBackColor = true;
            chatButton.Click += new System.EventHandler(this.chatButton_Click);

            fileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            fileButton.Location = new System.Drawing.Point(25, 3);
            fileButton.Size = new System.Drawing.Size(16, 16);
            fileButton.UseVisualStyleBackColor = true;
            */
        }

        private void initializeButton(Button button, Image image)
        {
            button.BackColor = Color.MediumTurquoise;
            button.BackgroundImage = image;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Margin = new Padding(4, 0, 0, 0);
            //button.Location = new System.Drawing.Point(3, 3);
            button.Size = new System.Drawing.Size(24, 24);
            button.UseVisualStyleBackColor = true;
        }

        private void chatButton_Click(object sender, EventArgs e)
        {
            client.sendMessage("NEWROOM:" + client.ID + ":" + ID);
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(fd.FileName);
                int fileLength = (int)fs.Length;
                Byte[] buffer = new Byte[fileLength];
                fs.Read(buffer, 0, fileLength);
                fs.Close();

                String fileName = fd.FileName.Substring(fd.FileName.LastIndexOf('\\') + 1);
                client.sendMessage("FILE:" + client.ID + ":" + ID + ":" + fileLength + ":" + fileName);
                int sent = 0;
                while (sent < buffer.Length)
                    sent += client.socket.Send(buffer, sent, buffer.Length - sent, System.Net.Sockets.SocketFlags.None);
            }
        }
    }
}
