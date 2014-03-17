
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
            
            client = chatSocket.connect();
            client.newListener(parseReceiveMessage);
        }

        private void changeTheme()
        {
            //this.BackColor = System.Drawing.SystemColors.Control;

            this.BackColor = backgroundColor;

            this.myNameTextBox.BackColor = lightColor;
            this.myImageBox.BackColor = lightColor;

            this.searchTextBox.ForeColor = darkColor;
        }
        
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
                }
                else if (words[1].Equals("USED"))
                {
                    isIDAvailable = false;
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
                if(sd.ShowDialog() == DialogResult.OK)
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
                // richTextBox1.AppendText("    ");
                // pic here
                // richTextBox1.AppendText("\n");
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
            while(received < buffer.Length)
                received += client.socket.Receive(buffer, received, buffer.Length - received, System.Net.Sockets.SocketFlags.None);
        }

        private void fileToServer(Byte[] buffer)
        {
            int sent = 0;
            while (sent < buffer.Length)
                sent += client.socket.Send(buffer, sent, buffer.Length - sent, System.Net.Sockets.SocketFlags.None);
        }

    }
}
