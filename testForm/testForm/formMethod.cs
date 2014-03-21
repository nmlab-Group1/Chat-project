﻿using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace chatRoomClient
{
    public partial class Form1 : Form
    {
        public String parseReceiveMessage(String msg)
        {
            char[] del = { ':' };
            String[] words = msg.Split(del);

            // richTextBox1.Text = msg;

            if (words[0].Equals("MESSAGE"))
            {// MESSAGE:sendersID:color:message
                if (client.activeRoom == 0)
                {
                    Action colorAction = () => richTextBox1.SelectionColor = Color.Black;
                    Action textAction = () => richTextBox1.AppendText(words[1] + ": " + DateTime.Now.ToLocalTime() + '\n');
                    richTextBox1.Invoke(colorAction);
                    richTextBox1.Invoke(textAction);
                    Action colorAction2 = () => richTextBox1.SelectionColor = Color.FromArgb(Convert.ToInt32(words[2]));
                    Action textAction2 = () => richTextBox1.AppendText("    " + words[3] + '\n');
                    richTextBox1.Invoke(colorAction2);
                    richTextBox1.Invoke(textAction2);
                }
                else
                {
                    foreach (chatRoom room in client.roomList)
                    {
                        if (room.ID == client.activeRoom)
                        {
                            room.text.SelectionColor = Color.Black;
                            room.text.AppendText(words[1] + ": " + DateTime.Now.ToLocalTime() + '\n');
                            room.text.SelectionColor = Color.FromArgb(Convert.ToInt32(words[2]));
                            room.text.AppendText("    " + words[3] + '\n');
                        }
                    }
                }
            }

            else if (words[0].Equals("AVAILABLEID"))
            {// AVAILABLEID:USED or AVAILABLEID:USABLE
                if (words[1].Equals("USABLE"))
                {
                    isIDAvailable = true;
                    this.availableIDpictureBox.BackgroundImage = global::chatRoomClient.Properties.Resources.tick;
                }
                else if (words[1].Equals("USED"))
                {
                    isIDAvailable = false;
                    this.availableIDpictureBox.BackgroundImage = global::chatRoomClient.Properties.Resources.cross;
                }
            }

            else if (words[0].Equals("IDPHOTO"))
            {// IDPHOTO:senderID:fileLength
                Byte[] buffer = new Byte[Convert.ToInt32(words[2])];
                fileFromServer(buffer);
                // paste the image
                String fileName = "tempFile" + client.GetHashCode();
                File.WriteAllBytes(fileName, buffer);
                FileStream fs = File.OpenRead(fileName);
                myImageBox.Image = Image.FromStream(fs);
                fs.Close();
            }

            else if (words[0].Equals("FILE"))
            {// FILE:senderID:fileLength
                Byte[] buffer = new Byte[Convert.ToInt32(words[2])];
                fileFromServer(buffer);

                SaveFileDialog sd = new SaveFileDialog();
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sd.FileName, buffer);
                }
            }

            else if (words[0].Equals("SEARCHLISTUPDATE"))
            {// SEARCHLISTUPDATE:sID:sID:...

            }

            else if (words[0].Equals("SECRETMESSAGE"))
            {// SECRETMESSAGE:sendersID:message
                MessageBox.Show(words[1] + " sent you secret message" +
                    DateTime.Now.ToLocalTime() + '\n' + words[2]);
            }

            else if (words[0].Equals("PIC"))
            {// PIC:sendersID:index
                picThread = new Thread( () => printEmotion(words[1], Convert.ToInt32(words[2])) );
                picThread.SetApartmentState(ApartmentState.STA);
                picThread.Start();
            }

            else if (words[0].Equals("WELCOME"))
            {// WELCOME:ID:sID:count:ID:sID:...
                Action colorAction = () => richTextBox1.SelectionColor = Color.Black;
                Action textAction = () => richTextBox1.AppendText(words[2] + " joined in\n");
                richTextBox1.Invoke(colorAction);
                richTextBox1.Invoke(textAction);

                if (words[2].Equals(myNameTextBox.Text))
                {
                    client.sID = words[2];

                    for (int col = 0; col < this.userListTable.ColumnCount; ++col)
                    {
                        Control ctrl = this.userListTable.GetControlFromPosition(col, 0);
                        Action remove = () => this.userListTable.Controls.Remove(ctrl);
                        this.userListTable.Invoke(remove);
                    }
                    Action removeAt = () => this.userListTable.RowStyles.RemoveAt(0);
                    Action subRowCount = () => this.userListTable.RowCount--;
                    Action resize = () => this.userListTable.Size = new Size(247, this.userListTable.RowCount * 48);
                    this.userListTable.Invoke(removeAt);
                    this.userListTable.Invoke(subRowCount);
                    this.userListTable.Invoke(resize);

                    Action visibleAction = () => this.userListTable.Visible = true;
                    this.userListTable.Invoke(visibleAction);
                }

                int count = Convert.ToInt32(words[3]);
                for (int i = 0; i < count; ++i)
                {
                    bool found = false;
                    foreach (userGUI user in client.userList)
                    {
                        if (words[2 * i + 5].Equals(user.sID))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        userGUI newUser = new userGUI(Convert.ToInt32(words[2 * i + 4]), words[2 * i + 5]);
                        client.userList.Add(newUser);

                        if (!words[2 * i + 5].Equals(myNameTextBox.Text))
                        {
                            Action addRowCount = () => this.userListTable.RowCount++;
                            Action addPic = () => this.userListTable.Controls.Add(newUser.userPic, 0, this.userListTable.RowCount - 1);
                            Action addPanel = () => this.userListTable.Controls.Add(newUser.infoPanel, 1, this.userListTable.RowCount - 1);
                            Action addRow = () => this.userListTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
                            Action resize = () => this.userListTable.Size = new Size(247, this.userListTable.RowCount * 48);
                            this.userListTable.Invoke(addRowCount);
                            this.userListTable.Invoke(addPic);
                            this.userListTable.Invoke(addPanel);
                            this.userListTable.Invoke(addRow);
                            this.userListTable.Invoke(resize);
                        }
                    }
                }
            }

            else if (words[0].Equals("NEWROOM"))
            {// NEWROOM:roomID:roomsID
                chatRoom newRoom = new chatRoom(Convert.ToInt32(words[1]), words[2]);

                Action insertTab = () => this.tabControl1.TabPages.Insert(tabControl1.TabPages.Count - 1, newRoom.newRoom);
                Action selectTab = () => this.tabControl1.SelectedTab = newRoom.newRoom;
                this.tabControl1.Invoke(insertTab);
                this.tabControl1.Invoke(selectTab);

                client.roomList.Add(new chatRoom(Convert.ToInt32(words[1]), words[2]));
                client.activeRoom = Convert.ToInt32(words[1]);
            }

            else if (words[0].Equals("REGNEWUSER"))
            {// REGNEWUSER:ID
                client.ID = Convert.ToInt32(words[1]);
                chatTextBox.Enabled = true;
                searchTextBox.Enabled = true;
                myImageBox.Enabled = true;
                emoticonPanelButton.Enabled = true;
                textColorButton.Enabled = true;
                chatButton3.Enabled = true;
            }

            return "";
        }

        private void fileFromServer(Byte[] buffer)
        {
            int received = 0;
            while (received < buffer.Length)
                received += client.socket.Receive(buffer, received, buffer.Length - received, System.Net.Sockets.SocketFlags.None);
        }

        private void fileToServer(Byte[] buffer)
        {
            int sent = 0;
            while (sent < buffer.Length)
                sent += client.socket.Send(buffer, sent, buffer.Length - sent, System.Net.Sockets.SocketFlags.None);
        }

        private void loadTheme()
        {
            //this.BackColor = System.Drawing.SystemColors.Control;

            this.BackColor = backgroundColor;

            this.myNameTextBox.BackColor = lightColor;
            this.myImageBox.BackColor = lightColor;
            this.searchTextBox.BackColor = lightColor;
            this.chatTextBox.BackColor = lightColor;
            this.outUserListPanel.BackColor = lightColor;

            this.emoticonPanelButton.BackColor = darkColor;
        }

        private void genEmoticonButtons()
        {
            int buttonWidth = 48;
            int buttonLength = 48;
            int i = 0;

            System.Windows.Forms.Button[] emoticonButtons = new System.Windows.Forms.Button[buttonNum];
            //System.Drawing.Image[] emoticonImages = new System.Drawing.Image[buttonNum];
            for (i = 0; i < buttonNum; ++i)
            {
                emoticonButtons[i] = new System.Windows.Forms.Button();
                emoticonFlowPanel.Controls.Add(emoticonButtons[i]);
                emoticonButtons[i].Size = new System.Drawing.Size(buttonWidth, buttonLength);
                emoticonButtons[i].Name = "emoticonButtons_" + i.ToString();
                emoticonButtons[i].TabIndex = 0;
                emoticonButtons[i].BackColor = System.Drawing.Color.White;
                emoticonButtons[i].FlatAppearance.BorderSize = 0;
                emoticonButtons[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                emoticonButtons[i].Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                emoticonButtons[i].BackgroundImage = emoticonImages[i];
                emoticonButtons[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                emoticonButtons[i].Tag = i;
                emoticonButtons[i].Click += new System.EventHandler(emoticonButtonsClick);
            }
        }

        Thread picThread;

        private void printEmotion(String sID, int index)
        {
            Action colorAction = () => richTextBox1.SelectionColor = Color.Black;
            Action textAction = () => richTextBox1.AppendText(sID + ": " + DateTime.Now.ToLocalTime() + "\n    ");
            Clipboard.SetImage(emoticonImages[index]);
            Action paste = () => richTextBox1.Paste();
            Action textAction2 = () => richTextBox1.AppendText("\n");
            richTextBox1.Invoke(colorAction);
            richTextBox1.Invoke(textAction);
            richTextBox1.Invoke(paste);
            richTextBox1.Invoke(textAction2);
            picThread.Abort();
        }
    }
}
