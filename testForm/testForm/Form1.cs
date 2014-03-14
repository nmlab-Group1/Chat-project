
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace chatRoomClient
{
    public partial class Form1 : Form
    {
        bool isFirstSearchClick;
        bool isFirstChatClick;
        bool isFirstMyNameClick;

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
            isFirstSearchClick = true;
            isFirstChatClick = true;
            isFirstMyNameClick = true;

            isIDAvailable = false;
            isRegister = false;

            backgroundColor = System.Drawing.Color.PaleTurquoise;
            lightColor = System.Drawing.Color.Azure;
            darkColor = System.Drawing.Color.LightSeaGreen;

            msgHandler = parseReceiveMessage;

            client = chatSocket.connect();
            client.newListener(parseReceiveMessage);
            sendChatMessage("REGNEWUSER:");
        }

        private void changeTheme()
        {
            //this.BackColor = System.Drawing.SystemColors.Control;

            this.BackColor = backgroundColor;

            this.myNameTextBox.BackColor = lightColor;
            this.myImageBox.BackColor = lightColor;

            this.searchTextBox.ForeColor = darkColor;
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchUser(searchTextBox.Text);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchUser(searchTextBox.Text);
        }

        private void searchUser(string username)
        {
            //todo
        }

        private void chatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendChatMessage(chatTextBox.Text);
            }
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
            client.sendMessage(chatMessage);
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

        private void myNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ( isIDAvailable )
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

        private void chatTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (isFirstChatClick)
            {
                isFirstChatClick = false;
                chatTextBox.Clear();
                this.chatTextBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void searchTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (isFirstSearchClick)
            {
                isFirstSearchClick = false;
                searchTextBox.Clear();
                this.searchTextBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void myNameTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (isFirstMyNameClick)
            {
                isFirstMyNameClick = false;
                myNameTextBox.Clear();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "ENTER";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "LEAVE";
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isRegister)
                return;
            sendChatMessage("SEARCHID" + myNameTextBox.Text.Trim() + ':' + searchTextBox.Text.Trim());
        }

        private void myNameTextBox_TextChanged(object sender, EventArgs e)
        {
            sendChatMessage("AVAILABLEID:" + myNameTextBox.Text.Trim());
        }
    }
}
