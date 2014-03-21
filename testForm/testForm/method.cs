
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
        public static String serverIP = "140.112.249.97";
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
        public List<int> roomIDList = new List<int>();
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
        public List<chatSocket> clientList;

        public TabPage newRoom = new TabPage();
        public RichTextBox text = new RichTextBox();

        public chatRoom(int roomID, String roomsID)
        {
            ID = roomID;
            sID = roomsID;
            clientList = new List<chatSocket>();

            text.BackColor = System.Drawing.Color.Azure;
            text.Dock = System.Windows.Forms.DockStyle.Fill;
            text.Location = new System.Drawing.Point(3, 3);
            text.Size = new System.Drawing.Size(508, 485);
            text.TabIndex = 0;
            text.Text = "";

            newRoom.AllowDrop = true;
            newRoom.BackColor = System.Drawing.Color.Azure;
            newRoom.Controls.Add(text);
            newRoom.Location = new System.Drawing.Point(4, 29);
            newRoom.Padding = new System.Windows.Forms.Padding(3);
            newRoom.Size = new System.Drawing.Size(514, 491);
            newRoom.Text = "";
        }
    }

    public class userGUI
    {
        public PictureBox userPic;
        public TableLayoutPanel infoPanel;
        public Label sIDLabel;
        public FlowLayoutPanel buttonHandle;
        public Button button1;
        public Button button2;

        public int ID;
        public String sID;

        public userGUI(int id, String sid)
        {
            ID = id;
            sID = sid;

            userPic = new PictureBox();
            infoPanel = new TableLayoutPanel();
            sIDLabel = new Label();
            buttonHandle = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();

            userPic.BackColor = Color.White;
            userPic.BackgroundImage = global::chatRoomClient.Properties.Resources.pencil_2;
            userPic.BackgroundImageLayout = ImageLayout.Stretch;
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
            sIDLabel.Dock = DockStyle.Top;
            sIDLabel.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(136)));
            sIDLabel.Location = new Point(3, 3);
            sIDLabel.Margin = new Padding(3);
            sIDLabel.Size = new Size(193, 18);
            this.sIDLabel.Text = sID;

            buttonHandle.Controls.Add(this.button1);
            buttonHandle.Controls.Add(this.button2);
            buttonHandle.Dock = DockStyle.Fill;
            buttonHandle.Location = new Point(0, 24);
            buttonHandle.Margin = new Padding(0);
            buttonHandle.Size = new Size(199, 24);

            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Location = new System.Drawing.Point(3, 3);
            button1.Size = new System.Drawing.Size(16, 16);
            button1.UseVisualStyleBackColor = true;

            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Location = new System.Drawing.Point(25, 3);
            button2.Size = new System.Drawing.Size(16, 16);
            button2.UseVisualStyleBackColor = true;
        }
    }
}
