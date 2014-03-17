
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace chatRoomClient
{
    public partial class Form1 : Form
    {
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
                    client.sendMessage("WELCOME:" + client.ID + ':' + myNameTextBox.Text);
                    isRegister = true;
                    myNameTextBox.Enabled = false;
                    this.myNameTextBox.BackColor = backgroundColor;
                    this.ActiveControl = myImageBox;
                }
                else
                {
                    MessageBox.Show("\"" + myNameTextBox.Text + "\" 有人用過了");
                }
            }
        }

        private void myNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!myNameTextBox.Text.Trim().Equals(""))
                client.sendMessage("AVAILABLEID:" + client.ID + ':' + myNameTextBox.Text.Trim());
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
            if (isChatTextBoxEmpty)
            {
                isChatTextBoxEmpty = false;
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
                isChatTextBoxEmpty = true;
            }
        }
        
        private void chatTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRegister)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                String msg = "MESSAGE:" + '0' + ':' + client.ID + ':' + client.color.ToArgb() + ':' + chatTextBox.Text;
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

        private void changeColor(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                client.color = cd.Color;
            textColorButton.BackColor = cd.Color;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }
    }
}
