using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

namespace chatRoomClient
{
    public partial class Form1 : Form
    {
        bool isFirstSearchClick;
        bool isFirstChatClick;
        bool isFirstMyNameClick;
        
        Color backgroundColor;
        Color lightColor;
        Color darkColor;


        public Form1()
        {
            InitializeComponent();

            this.ActiveControl = myNameTextBox;     //focus on myName
            isFirstSearchClick = true;
            isFirstChatClick = true;
            isFirstMyNameClick = true;
            
            backgroundColor = System.Drawing.Color.PaleTurquoise;
            lightColor = System.Drawing.Color.Azure;
            darkColor = System.Drawing.Color.LightSeaGreen;
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

        private void sendChatMessage(string chatMessage)
        {
            //todo
        }

        private void myImageBox_Click(object sender, EventArgs e)
        {
            //todo
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void myNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ( registerMyName(myNameTextBox.Text) == true )
                {
                    myNameTextBox.Enabled = false;
                    this.myNameTextBox.BackColor = backgroundColor;
                }
                else
                {
                    MessageBox.Show("\"" + myNameTextBox.Text + "\" has been registered by someone else.");
                }
            }
        }

        private bool registerMyName(string myName)
        {
            //todo;
            return true;
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
    }
}
