﻿
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace chatRoomClient
{
    public partial class Form1 : Form
    {
        bool isSearchTextBoxEmpty;
        bool isChatTextBoxNotFocusedAndEmpty;
        bool isMyNameNotFocusedAndEmpty;

        bool isIDAvailable;
        bool isRegister;

        Color backgroundColor;
        Color lightColor;
        Color darkColor;

        int emoticonButtonNum;
        Image[] emoticonImages;

        Image defaultUserImage;
        Image chatImage;
        Image folderImage;
        Image micImage;

        chatSocket client = null;
        StringHandler msgHandler;

        public Form1()
        {
            InitializeComponent();

            isSearchTextBoxEmpty = true;
            isChatTextBoxNotFocusedAndEmpty = true;
            isMyNameNotFocusedAndEmpty = true;

            isIDAvailable = false;
            isRegister = false;

            backgroundColor = System.Drawing.Color.PaleTurquoise;
            lightColor = System.Drawing.Color.Azure;
            darkColor = System.Drawing.Color.LightSeaGreen;
            //loadTheme();

            emoticonButtonNum = 32;
            emoticonImages = new System.Drawing.Image[emoticonButtonNum];
            for (int i = 0; i < emoticonButtonNum; ++i)
            {
                emoticonImages[i] = (Image)Properties.Resources.ResourceManager.GetObject("_" + (i+1).ToString());
            }
            genEmoticonButtons();

            defaultUserImage = global::chatRoomClient.Properties.Resources.defaultImage;
            chatImage = global::chatRoomClient.Properties.Resources.chatBlack;
            folderImage = global::chatRoomClient.Properties.Resources.folder;
            micImage = global::chatRoomClient.Properties.Resources.mic;

            msgHandler = parseReceiveMessage;
            
            client = chatSocket.connect();
            client.newListener(parseReceiveMessage);

            userListTable.Visible = false;
            this.ActiveControl = myNameTextBox;     //focus on myName
        }
        //
        // myNameTextBox
        //
        private void myNameTextBox_Enter(object sender, EventArgs e)
        {
            if (isMyNameNotFocusedAndEmpty)
            {
                isMyNameNotFocusedAndEmpty = false;
                myNameTextBox.Clear();
            }
        }

        private void myNameTextBox_Leave(object sender, EventArgs e)
        {
            if (myNameTextBox.Text.Trim().Length == 0)
            {
                this.myNameTextBox.Text = "請輸入暱稱";
                isMyNameNotFocusedAndEmpty = true;
            }
        }

        private void myNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isIDAvailable)
                {
                    myNameTextBox.Text = myNameTextBox.Text.Trim();
                    client.sendMessage("WELCOME:" + client.ID + ':' + myNameTextBox.Text);
                    isRegister = true;
                    myNameTextBox.Enabled = false;
                    this.myNameTextBox.BackColor = backgroundColor;
                    this.ActiveControl = myImageBox;
                }
                else
                {
                    if (myNameTextBox.Text.Trim().Length == 0)
                        MessageBox.Show("請輸入暱稱");
                    else
                        MessageBox.Show("\"" + myNameTextBox.Text + "\" 有人用過了");
                }
            }
        }

        private void myNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (myNameTextBox.Text.Trim().Length != 0)
                client.sendMessage("AVAILABLEID:" + client.ID + ':' + myNameTextBox.Text.Trim());
            else
            {
                isIDAvailable = false;
                this.availableIDpictureBox.BackgroundImage = global::chatRoomClient.Properties.Resources.cross;
            }
        }
        // 
        // searchTextBox
        // 
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (isSearchTextBoxEmpty)
            {
                searchTextBox.Clear();
                this.searchTextBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (isSearchTextBoxEmpty)
            {
                this.searchTextBox.ForeColor = System.Drawing.Color.Gray;
                this.searchTextBox.Text = "search user";
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isRegister)
                return;

            if (searchTextBox.Text.Trim().Length != 0)
                isSearchTextBoxEmpty = false;
            else
                isSearchTextBoxEmpty = true;

            if (searchTextBox.ForeColor == System.Drawing.Color.Gray)
                isSearchTextBoxEmpty = true;

            if (!isSearchTextBoxEmpty)
                client.sendMessage("SEARCHID:" + client.ID + ':' + searchTextBox.Text.Trim());
        }
        // 
        // chatTextBox
        // 
        private void chatTextBox_Enter(object sender, EventArgs e)
        {
            if (isChatTextBoxNotFocusedAndEmpty)
            {
                isChatTextBoxNotFocusedAndEmpty = false;
                chatTextBox.Clear();
                this.chatTextBox.ForeColor = client.color;
            }
        }

        private void chatTextBox_Leave(object sender, EventArgs e)
        {
            if (chatTextBox.Text.Trim().Length == 0)
            {
                this.chatTextBox.ForeColor = System.Drawing.Color.Gray;
                this.chatTextBox.Text = "type your message here";
                isChatTextBoxNotFocusedAndEmpty = true;
            }
        }

        private void chatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRegister)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                String msg = "MESSAGE:" + client.activeRoom + ":" + client.ID + ":" + client.color.ToArgb() + ":" + chatTextBox.Text;
                // room?
                client.sendMessage(msg);
                chatTextBox.Clear();
            }
        }

        //
        // others
        //

        private void myImageBox_Click(object sender, EventArgs e)
        {
            if (!isRegister)
                return;

            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(fd.FileName);
                int fileLength = (int)fs.Length;
                Byte[] buffer = new Byte[fileLength];
                fs.Read(buffer, 0, fileLength);
                myImageBox.BackgroundImage = Image.FromStream(fs);
                fs.Close();

                client.sendMessage("IDPHOTO:" + client.ID + ':' + fileLength);
                fileToServer(buffer);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }

        private void emoticonPanelButton_Click(object sender, EventArgs e)
        {
            if (emoticonFlowPanel.Visible == false)
            {
                emoticonFlowPanel.Visible = true;
                this.ActiveControl = emoticonFlowPanel;
            }
            else
                emoticonFlowPanel.Visible = false;
        }

        private void emoticonButtonsClick(object sender, EventArgs e)
        {
            //global::chatRoomClient.Properties.Resources._02;// Image.FromFile("D:\\roger\\nmlab\\testWindowsForm\\icon\\tuzki\\05.gif");
            //Image emotionImg = this.ActiveControl.BackgroundImage;
            //printEmoticon((int)this.ActiveControl.Tag);
            client.sendMessage("PIC:" + client.activeRoom + ":" + client.ID + ":" + ActiveControl.Tag.ToString());
            emoticonFlowPanel.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (this.tabControl1.SelectedTab == newRoomTab)
            {
                client.sendMessage("NEWROOM:" + client.ID);
            }
            else if (this.tabControl1.SelectedTab == lobbyTab)
                client.activeRoom = 0;*/
            client.activeRoom = (int)this.tabControl1.SelectedTab.Tag;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.sendMessage("SHUTDOWN:" + client.sID);
            client.socket.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //client.sendMessage("SHUTDOWN:" + client.sID);
        }

        private void textColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                client.color = cd.Color;
            textColorButton.BackColor = cd.Color;
        }
    }
}
