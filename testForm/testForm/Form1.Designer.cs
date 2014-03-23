namespace chatRoomClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textColorButton = new System.Windows.Forms.Button();
            this.emoticonPanelButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.chatButton3 = new System.Windows.Forms.Button();
            this.myInfoPanel = new System.Windows.Forms.Panel();
            this.availableIDpictureBox = new System.Windows.Forms.PictureBox();
            this.myNameTextBox = new System.Windows.Forms.TextBox();
            this.myImageBox = new System.Windows.Forms.PictureBox();
            this.chatRoomPanel = new System.Windows.Forms.Panel();
            this.emoticonFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lobbyTab = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.newRoomTab = new System.Windows.Forms.TabPage();
            this.outUserListPanel = new System.Windows.Forms.Panel();
            this.userListTable = new System.Windows.Forms.TableLayoutPanel();
            this.userPic = new System.Windows.Forms.PictureBox();
            this.userInfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.buttonHandle = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sIDLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.formTable.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.myInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableIDpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myImageBox)).BeginInit();
            this.chatRoomPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.lobbyTab.SuspendLayout();
            this.outUserListPanel.SuspendLayout();
            this.userListTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.userInfoTable.SuspendLayout();
            this.buttonHandle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // formTable
            // 
            this.formTable.ColumnCount = 2;
            this.formTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.formTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formTable.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.formTable.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.formTable.Controls.Add(this.myInfoPanel, 0, 0);
            this.formTable.Controls.Add(this.chatRoomPanel, 1, 0);
            this.formTable.Controls.Add(this.outUserListPanel, 0, 1);
            this.formTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTable.Location = new System.Drawing.Point(0, 0);
            this.formTable.Name = "formTable";
            this.formTable.RowCount = 3;
            this.formTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.formTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.formTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.formTable.Size = new System.Drawing.Size(784, 562);
            this.formTable.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.searchTextBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 533);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(250, 26);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.Azure;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTextBox.Enabled = false;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.searchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.searchTextBox.Location = new System.Drawing.Point(3, 2);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(247, 22);
            this.searchTextBox.TabIndex = 2;
            this.searchTextBox.Text = "search user";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.Controls.Add(this.textColorButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.emoticonPanelButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chatTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chatButton3, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(259, 533);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(522, 26);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // textColorButton
            // 
            this.textColorButton.BackColor = System.Drawing.Color.Black;
            this.textColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textColorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textColorButton.Enabled = false;
            this.textColorButton.FlatAppearance.BorderSize = 0;
            this.textColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textColorButton.Location = new System.Drawing.Point(473, 4);
            this.textColorButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.textColorButton.Name = "textColorButton";
            this.textColorButton.Size = new System.Drawing.Size(20, 20);
            this.textColorButton.TabIndex = 3;
            this.textColorButton.UseVisualStyleBackColor = false;
            this.textColorButton.Click += new System.EventHandler(this.textColorButton_Click);
            // 
            // emoticonPanelButton
            // 
            this.emoticonPanelButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.emoticonPanelButton.BackgroundImage = global::chatRoomClient.Properties.Resources.FHgF1mrAc_e;
            this.emoticonPanelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emoticonPanelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emoticonPanelButton.Enabled = false;
            this.emoticonPanelButton.FlatAppearance.BorderSize = 0;
            this.emoticonPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emoticonPanelButton.Location = new System.Drawing.Point(447, 4);
            this.emoticonPanelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.emoticonPanelButton.Name = "emoticonPanelButton";
            this.emoticonPanelButton.Size = new System.Drawing.Size(20, 20);
            this.emoticonPanelButton.TabIndex = 2;
            this.emoticonPanelButton.UseVisualStyleBackColor = false;
            this.emoticonPanelButton.Click += new System.EventHandler(this.emoticonPanelButton_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.BackColor = System.Drawing.Color.Azure;
            this.chatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatTextBox.Enabled = false;
            this.chatTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chatTextBox.ForeColor = System.Drawing.Color.Gray;
            this.chatTextBox.Location = new System.Drawing.Point(3, 3);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(438, 22);
            this.chatTextBox.TabIndex = 1;
            this.chatTextBox.Text = "type your message here";
            this.chatTextBox.Enter += new System.EventHandler(this.chatTextBox_Enter);
            this.chatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatTextBox_KeyDown);
            this.chatTextBox.Leave += new System.EventHandler(this.chatTextBox_Leave);
            // 
            // chatButton3
            // 
            this.chatButton3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.chatButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatButton3.Enabled = false;
            this.chatButton3.FlatAppearance.BorderSize = 0;
            this.chatButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatButton3.Location = new System.Drawing.Point(499, 4);
            this.chatButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.chatButton3.Name = "chatButton3";
            this.chatButton3.Size = new System.Drawing.Size(20, 20);
            this.chatButton3.TabIndex = 4;
            this.chatButton3.UseVisualStyleBackColor = false;
            // 
            // myInfoPanel
            // 
            this.myInfoPanel.Controls.Add(this.availableIDpictureBox);
            this.myInfoPanel.Controls.Add(this.myNameTextBox);
            this.myInfoPanel.Controls.Add(this.myImageBox);
            this.myInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myInfoPanel.Location = new System.Drawing.Point(3, 3);
            this.myInfoPanel.Name = "myInfoPanel";
            this.myInfoPanel.Size = new System.Drawing.Size(250, 122);
            this.myInfoPanel.TabIndex = 4;
            // 
            // availableIDpictureBox
            // 
            this.availableIDpictureBox.BackgroundImage = global::chatRoomClient.Properties.Resources.cross;
            this.availableIDpictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.availableIDpictureBox.Location = new System.Drawing.Point(224, 21);
            this.availableIDpictureBox.Name = "availableIDpictureBox";
            this.availableIDpictureBox.Size = new System.Drawing.Size(26, 26);
            this.availableIDpictureBox.TabIndex = 2;
            this.availableIDpictureBox.TabStop = false;
            // 
            // myNameTextBox
            // 
            this.myNameTextBox.BackColor = System.Drawing.Color.Azure;
            this.myNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myNameTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.myNameTextBox.Location = new System.Drawing.Point(107, 21);
            this.myNameTextBox.Name = "myNameTextBox";
            this.myNameTextBox.Size = new System.Drawing.Size(111, 26);
            this.myNameTextBox.TabIndex = 1;
            this.myNameTextBox.Text = "請輸入暱稱";
            this.myNameTextBox.TextChanged += new System.EventHandler(this.myNameTextBox_TextChanged);
            this.myNameTextBox.Enter += new System.EventHandler(this.myNameTextBox_Enter);
            this.myNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myNameTextBox_KeyDown);
            this.myNameTextBox.Leave += new System.EventHandler(this.myNameTextBox_Leave);
            // 
            // myImageBox
            // 
            this.myImageBox.BackColor = System.Drawing.Color.Transparent;
            this.myImageBox.BackgroundImage = global::chatRoomClient.Properties.Resources.defaultImage;
            this.myImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.myImageBox.Enabled = false;
            this.myImageBox.Location = new System.Drawing.Point(21, 21);
            this.myImageBox.Name = "myImageBox";
            this.myImageBox.Size = new System.Drawing.Size(80, 80);
            this.myImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myImageBox.TabIndex = 0;
            this.myImageBox.TabStop = false;
            this.myImageBox.Click += new System.EventHandler(this.myImageBox_Click);
            // 
            // chatRoomPanel
            // 
            this.chatRoomPanel.Controls.Add(this.emoticonFlowPanel);
            this.chatRoomPanel.Controls.Add(this.tabControl1);
            this.chatRoomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatRoomPanel.Location = new System.Drawing.Point(259, 3);
            this.chatRoomPanel.Name = "chatRoomPanel";
            this.formTable.SetRowSpan(this.chatRoomPanel, 2);
            this.chatRoomPanel.Size = new System.Drawing.Size(522, 524);
            this.chatRoomPanel.TabIndex = 1;
            // 
            // emoticonFlowPanel
            // 
            this.emoticonFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.emoticonFlowPanel.AutoScroll = true;
            this.emoticonFlowPanel.BackColor = System.Drawing.Color.White;
            this.emoticonFlowPanel.Location = new System.Drawing.Point(313, 332);
            this.emoticonFlowPanel.Name = "emoticonFlowPanel";
            this.emoticonFlowPanel.Size = new System.Drawing.Size(209, 192);
            this.emoticonFlowPanel.TabIndex = 4;
            this.emoticonFlowPanel.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.lobbyTab);
            this.tabControl1.Controls.Add(this.newRoomTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(522, 524);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // lobbyTab
            // 
            this.lobbyTab.AllowDrop = true;
            this.lobbyTab.BackColor = System.Drawing.Color.Azure;
            this.lobbyTab.Controls.Add(this.richTextBox1);
            this.lobbyTab.Location = new System.Drawing.Point(4, 29);
            this.lobbyTab.Name = "lobbyTab";
            this.lobbyTab.Padding = new System.Windows.Forms.Padding(3);
            this.lobbyTab.Size = new System.Drawing.Size(514, 491);
            this.lobbyTab.TabIndex = 0;
            this.lobbyTab.Tag = 0;
            this.lobbyTab.Text = "Lobby";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Azure;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(508, 485);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // newRoomTab
            // 
            this.newRoomTab.AllowDrop = true;
            this.newRoomTab.AutoScroll = true;
            this.newRoomTab.BackColor = System.Drawing.Color.Azure;
            this.newRoomTab.Location = new System.Drawing.Point(4, 29);
            this.newRoomTab.Name = "newRoomTab";
            this.newRoomTab.Padding = new System.Windows.Forms.Padding(3);
            this.newRoomTab.Size = new System.Drawing.Size(514, 491);
            this.newRoomTab.TabIndex = 1;
            this.newRoomTab.Text = "New Room";
            // 
            // outUserListPanel
            // 
            this.outUserListPanel.AutoScroll = true;
            this.outUserListPanel.BackColor = System.Drawing.Color.Azure;
            this.outUserListPanel.Controls.Add(this.userListTable);
            this.outUserListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outUserListPanel.Location = new System.Drawing.Point(6, 131);
            this.outUserListPanel.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.outUserListPanel.Name = "outUserListPanel";
            this.outUserListPanel.Size = new System.Drawing.Size(247, 396);
            this.outUserListPanel.TabIndex = 2;
            // 
            // userListTable
            // 
            this.userListTable.ColumnCount = 2;
            this.userListTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.userListTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.userListTable.Controls.Add(this.userPic, 0, 0);
            this.userListTable.Controls.Add(this.userInfoTable, 1, 0);
            this.userListTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.userListTable.Location = new System.Drawing.Point(0, 0);
            this.userListTable.Name = "userListTable";
            this.userListTable.RowCount = 1;
            this.userListTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.userListTable.Size = new System.Drawing.Size(247, 48);
            this.userListTable.TabIndex = 0;
            // 
            // userPic
            // 
            this.userPic.BackColor = System.Drawing.Color.White;
            this.userPic.BackgroundImage = global::chatRoomClient.Properties.Resources.pencil_2;
            this.userPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPic.Location = new System.Drawing.Point(0, 0);
            this.userPic.Margin = new System.Windows.Forms.Padding(0);
            this.userPic.Name = "userPic";
            this.userPic.Size = new System.Drawing.Size(48, 48);
            this.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPic.TabIndex = 2;
            this.userPic.TabStop = false;
            this.userPic.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // userInfoTable
            // 
            this.userInfoTable.ColumnCount = 1;
            this.userInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userInfoTable.Controls.Add(this.buttonHandle, 0, 1);
            this.userInfoTable.Controls.Add(this.sIDLabel, 0, 0);
            this.userInfoTable.Location = new System.Drawing.Point(48, 0);
            this.userInfoTable.Margin = new System.Windows.Forms.Padding(0);
            this.userInfoTable.Name = "userInfoTable";
            this.userInfoTable.RowCount = 2;
            this.userInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.userInfoTable.Size = new System.Drawing.Size(199, 48);
            this.userInfoTable.TabIndex = 3;
            // 
            // buttonHandle
            // 
            this.buttonHandle.Controls.Add(this.button1);
            this.buttonHandle.Controls.Add(this.button2);
            this.buttonHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHandle.Location = new System.Drawing.Point(0, 24);
            this.buttonHandle.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHandle.Name = "buttonHandle";
            this.buttonHandle.Size = new System.Drawing.Size(199, 24);
            this.buttonHandle.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 16);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(25, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(16, 16);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // sIDLabel
            // 
            this.sIDLabel.AutoSize = true;
            this.sIDLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sIDLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.sIDLabel.Location = new System.Drawing.Point(3, 3);
            this.sIDLabel.Margin = new System.Windows.Forms.Padding(3);
            this.sIDLabel.Name = "sIDLabel";
            this.sIDLabel.Size = new System.Drawing.Size(193, 18);
            this.sIDLabel.TabIndex = 6;
            this.sIDLabel.Text = "User 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 562);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.formTable);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.formTable.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.myInfoPanel.ResumeLayout(false);
            this.myInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableIDpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myImageBox)).EndInit();
            this.chatRoomPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.lobbyTab.ResumeLayout(false);
            this.outUserListPanel.ResumeLayout(false);
            this.userListTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.userInfoTable.ResumeLayout(false);
            this.userInfoTable.PerformLayout();
            this.buttonHandle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel formTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel outUserListPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage lobbyTab;
        private System.Windows.Forms.TabPage newRoomTab;
        private System.Windows.Forms.Panel myInfoPanel;
        private System.Windows.Forms.TableLayoutPanel userListTable;
        private System.Windows.Forms.PictureBox userPic;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Button textColorButton;
        private System.Windows.Forms.Button emoticonPanelButton;
        private System.Windows.Forms.Button chatButton3;
        private System.Windows.Forms.PictureBox myImageBox;
        private System.Windows.Forms.TextBox myNameTextBox;
        private System.Windows.Forms.TableLayoutPanel userInfoTable;
        private System.Windows.Forms.Label sIDLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox availableIDpictureBox;
        private System.Windows.Forms.FlowLayoutPanel buttonHandle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel chatRoomPanel;
        private System.Windows.Forms.FlowLayoutPanel emoticonFlowPanel;
    }
}

