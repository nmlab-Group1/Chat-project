
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace chatRoomClient
{
    public partial class Form1 : Form
    {
        bool isSearchTextBoxEmpty;
        bool isChatTextBoxEmpty;
        bool isMyNameTextBoxEmpty;

        bool isIDAvailable;
        bool isRegister;

        Color backgroundColor;
        Color lightColor;
        Color darkColor;

        chatSocket client = null;
        StringHandler msgHandler;

        public Form1()
        {
            InitializeComponent();

            this.ActiveControl = myNameTextBox;     //focus on myName
            isSearchTextBoxEmpty = true;
            isChatTextBoxEmpty = true;
            isMyNameTextBoxEmpty = true;

            isIDAvailable = false;
            isRegister = false;

            backgroundColor = System.Drawing.Color.PaleTurquoise;
            lightColor = System.Drawing.Color.Azure;
            darkColor = System.Drawing.Color.LightSeaGreen;

            msgHandler = parseReceiveMessage;
            /*
            client = chatSocket.connect();
            client.newListener(parseReceiveMessage);
            sendChatMessage("REGNEWUSER:");*/
        }

        private void changeTheme()
        {
            //this.BackColor = System.Drawing.SystemColors.Control;

            this.BackColor = backgroundColor;

            this.myNameTextBox.BackColor = lightColor;
            this.myImageBox.BackColor = lightColor;

            this.searchTextBox.ForeColor = darkColor;
        }
        //
        // myNameTextBox
        //
        private void myNameTextBox_Enter(object sender, EventArgs e)
        {
            if (isMyNameTextBoxEmpty)
            {
                isMyNameTextBoxEmpty = false;
                myNameTextBox.Clear();
            }
        }

        private void myNameTextBox_Leave(object sender, EventArgs e)
        {
            if (myNameTextBox.Text.Trim().Length == 0)
            {
                this.myNameTextBox.Text = "請輸入暱稱";
                isMyNameTextBoxEmpty = true;
            }
        }

        private void myNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isIDAvailable)
                {
                    myNameTextBox.Text = myNameTextBox.Text.Trim();
                    sendChatMessage("WELCOME:" + myNameTextBox.Text);
                    isRegister = true;
                    myNameTextBox.Enabled = false;
                    this.myNameTextBox.BackColor = backgroundColor;
                }
                else
                {
                    MessageBox.Show("\"" + myNameTextBox.Text + "\" has been registered by someone else.");
                }
            }
        }

        private void myNameTextBox_TextChanged(object sender, EventArgs e)
        {
            sendChatMessage("AVAILABLEID:" + myNameTextBox.Text.Trim());
        }
        // 
        // searchTextBox
        // 
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (isSearchTextBoxEmpty)
            {
                isSearchTextBoxEmpty = false;
                searchTextBox.Clear();
                this.searchTextBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Trim().Length == 0)
            {
                this.searchTextBox.ForeColor = System.Drawing.Color.Gray;
                this.searchTextBox.Text = "search user";
                isSearchTextBoxEmpty = true;
            }
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchUser(searchTextBox.Text);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isRegister)
                return;
            sendChatMessage("SEARCHID" + myNameTextBox.Text.Trim() + ':' + searchTextBox.Text.Trim());
        }
        // 
        // chatTextBox
        // 
        private void chatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendChatMessage(chatTextBox.Text);
            }
        }

        private void chatTextBox_Enter(object sender, EventArgs e)
        {
            if (isChatTextBoxEmpty)
            {
                isChatTextBoxEmpty = false;
                chatTextBox.Clear();
                this.chatTextBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void chatTextBox_Leave(object sender, EventArgs e)
        {
            if (chatTextBox.Text.Trim().Length == 0)
            {
                this.chatTextBox.ForeColor = System.Drawing.Color.Gray;
                this.chatTextBox.Text = "search user";
                isChatTextBoxEmpty = true;
            }
        }
        //
        // others
        //

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchUser(searchTextBox.Text);
        }

        private void searchUser(string username)
        {
            //todo
        }

        private String parseReceiveMessage(String msg)
        {
            char[] del = { ':' };
            String[] words = msg.Split(del);

            if (words[0].Equals("AVAILABLEID"))
            {
                if (words[1].Equals("USABLE"))
                {
                    isIDAvailable = true;
                }
                else if (words[1].Equals(""))
                {
                    isIDAvailable = false;
                }
            }

            return "";
        }

        private void sendChatMessage(string chatMessage)
        {
            //todo
            //client.sendMessage(chatMessage);
        }

        private void myImageBox_Click(object sender, EventArgs e)
        {
            //todo
            if (!isRegister)
                return;

            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(fd.FileName);
                int fileLength = (int)fs.Length;
                Byte[] image = new Byte[fileLength];
                fs.Read(image, 0, fileLength);
                myImageBox.BackgroundImage = Image.FromStream(fs);
                fs.Close();

                sendChatMessage("IDPHOTO:" + myNameTextBox.Text + ':' + fileLength);
                // sed the file
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void emoticon_click(object sender, EventArgs e)
        {
            Image emotionImg = global::chatRoomClient.Properties.Resources._02;// Image.FromFile("D:\\roger\\nmlab\\testWindowsForm\\icon\\tuzki\\05.gif");
            Clipboard.SetImage(emotionImg);
            richTextBox1.Paste();
            Clipboard.Clear();
            this.emoticonPanel.Visible = false;
        }

        private void emoticonButton_Click(object sender, EventArgs e)
        {
            this.emoticonPanel.Visible = true;
        }
    }
}
