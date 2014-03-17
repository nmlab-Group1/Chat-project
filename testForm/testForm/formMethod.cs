using System;
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
                Action colorAction = () => richTextBox1.SelectionColor = Color.Black;
                Action textAction = () => richTextBox1.AppendText(words[1] + ": " + DateTime.Now.ToLocalTime() + '\n');
                richTextBox1.Invoke(colorAction);
                richTextBox1.Invoke(textAction);
                Action colorAction2 = () => richTextBox1.SelectionColor = Color.FromArgb(Convert.ToInt32(words[2]));
                Action textAction2 = () => richTextBox1.AppendText("    " + words[3] + '\n');
                richTextBox1.Invoke(colorAction2);
                richTextBox1.Invoke(textAction2);
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
                
                Action colorAction = () => richTextBox1.SelectionColor = Color.Black;
                Action textAction = () => richTextBox1.AppendText(words[1] + ": " + DateTime.Now.ToLocalTime() + '\n');
                richTextBox1.Invoke(colorAction);
                richTextBox1.Invoke(textAction);
                Action textAction1 = () => richTextBox1.AppendText("    ");
                richTextBox1.Invoke(textAction1);
                //printEmoticon(Convert.ToInt32(words[2]));

                picThread = new Thread(new ThreadStart(copy));
                picThread.SetApartmentState(ApartmentState.STA);
                picThread.Start();
                
                //richTextBox1.ReadOnly = false;
                Action paste = () => richTextBox1.Paste();
                richTextBox1.Invoke(paste);
                //richTextBox1.ReadOnly = true;

                Action textAction2 = () => richTextBox1.AppendText("\n");
                richTextBox1.Invoke(textAction2);
            }

            else if (words[0].Equals("WELCOME"))
            {// WELCOME:sID
                Action colorAction = () => richTextBox1.SelectionColor = Color.Black;
                Action textAction = () => richTextBox1.AppendText(words[1] + " joined in\n");
                richTextBox1.Invoke(colorAction);
                richTextBox1.Invoke(textAction);
            }

            else if (words[0].Equals("NEWROOM"))
            {// NEWROOM:roomID:sID:sID:...
                if (words.Length == 3)
                {
                    // goto new tab with title (client.sID + " and " + words[1])
                }
                else
                {
                    // goto new tab with title (New room)
                }
                client.roomIDList.Add(Convert.ToInt32(words[2]));
                // client.activeRoom = ????;
            }

            else if (words[0].Equals("REGNEWUSER"))
            {// REGNEWUSER:ID
                client.ID = Convert.ToInt32(words[1]);
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

        private void changeTheme()
        {
            //this.BackColor = System.Drawing.SystemColors.Control;

            this.BackColor = backgroundColor;

            this.myNameTextBox.BackColor = lightColor;
            this.myImageBox.BackColor = lightColor;

            this.searchTextBox.ForeColor = darkColor;
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
                //emoticonImages[i] = Image.FromFile("D:\\roger\\nmlab\\GitHub_Roger\\Chat-project\\testForm\\icon\\meep\\" + (i+1).ToString() + ".png");
                emoticonButtons[i].BackgroundImage = emoticonImages[i];
                emoticonButtons[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                emoticonButtons[i].Tag = i;
                emoticonButtons[i].Click += new System.EventHandler(emoticonButtonsClick);
            }
        }

        private void printEmoticon(int emoticonIndex)   //index from 0
        {
            // Action textAction2 = () => richTextBox1.AppendText("    " + words[3] + '\n');
            Clipboard.SetImage(emoticonImages[emoticonIndex]);
            //richTextBox1.ReadOnly = false;
            //Action paste = () => richTextBox1.Paste();
            //richTextBox1.Invoke(paste);
            //richTextBox1.ReadOnly = true;
            Clipboard.Clear();
            Action textAction = () => richTextBox1.AppendText("4352345\n");
            richTextBox1.Invoke(textAction);

            /*
            Clipboard.SetImage(emoticonImages[emoticonIndex]);
            richTextBox1.ReadOnly = false;
            richTextBox1.Paste();
            richTextBox1.ReadOnly = true;
            Clipboard.Clear();*/
        }

        Thread picThread;

        private void copy()
        {
            //Clipboard.Clear();
            Clipboard.SetImage(emoticonImages[3]);
            picThread.Abort();
        }
    }
}
