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
            this.searchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.emoticonButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.chatEnterButton = new System.Windows.Forms.Button();
            this.userListPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.emoticonPanel = new System.Windows.Forms.Panel();
            this.emoticonTable = new System.Windows.Forms.TableLayoutPanel();
            this.emoticonButton2 = new System.Windows.Forms.Button();
            this.emoticonButton1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myInfoPanel = new System.Windows.Forms.Panel();
            this.myNameTextBox = new System.Windows.Forms.TextBox();
            this.myImageBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.formTable.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.userListPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.emoticonPanel.SuspendLayout();
            this.emoticonTable.SuspendLayout();
            this.myInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myImageBox)).BeginInit();
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
            this.formTable.Controls.Add(this.userListPanel, 0, 1);
            this.formTable.Controls.Add(this.tabControl1, 1, 0);
            this.formTable.Controls.Add(this.myInfoPanel, 0, 0);
            this.formTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTable.Location = new System.Drawing.Point(0, 0);
            this.formTable.Name = "formTable";
            this.formTable.RowCount = 3;
            this.formTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.formTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.formTable.Size = new System.Drawing.Size(784, 562);
            this.formTable.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Controls.Add(this.searchTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.searchButton, 1, 0);
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
            this.searchTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.searchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.searchTextBox.Location = new System.Drawing.Point(3, 2);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(221, 22);
            this.searchTextBox.TabIndex = 2;
            this.searchTextBox.Text = "search user";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.searchButton.BackgroundImage = global::chatRoomClient.Properties.Resources.search;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(230, 4);
            this.searchButton.Margin = new System.Windows.Forms.Padding(6, 4, 0, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(20, 20);
            this.searchButton.TabIndex = 1;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.emoticonButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chatTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chatEnterButton, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(259, 533);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(522, 26);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(473, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // emoticonButton
            // 
            this.emoticonButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.emoticonButton.BackgroundImage = global::chatRoomClient.Properties.Resources.FHgF1mrAc_e;
            this.emoticonButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emoticonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emoticonButton.FlatAppearance.BorderSize = 0;
            this.emoticonButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emoticonButton.Location = new System.Drawing.Point(447, 4);
            this.emoticonButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.emoticonButton.Name = "emoticonButton";
            this.emoticonButton.Size = new System.Drawing.Size(20, 20);
            this.emoticonButton.TabIndex = 2;
            this.emoticonButton.UseVisualStyleBackColor = false;
            this.emoticonButton.Click += new System.EventHandler(this.emoticonButton_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.BackColor = System.Drawing.Color.Azure;
            this.chatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
            // chatEnterButton
            // 
            this.chatEnterButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.chatEnterButton.FlatAppearance.BorderSize = 0;
            this.chatEnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatEnterButton.Location = new System.Drawing.Point(499, 4);
            this.chatEnterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.chatEnterButton.Name = "chatEnterButton";
            this.chatEnterButton.Size = new System.Drawing.Size(20, 20);
            this.chatEnterButton.TabIndex = 4;
            this.chatEnterButton.UseVisualStyleBackColor = false;
            // 
            // userListPanel
            // 
            this.userListPanel.AutoScroll = true;
            this.userListPanel.BackColor = System.Drawing.Color.Azure;
            this.userListPanel.Controls.Add(this.tableLayoutPanel4);
            this.userListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userListPanel.Location = new System.Drawing.Point(6, 131);
            this.userListPanel.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.userListPanel.Name = "userListPanel";
            this.userListPanel.Size = new System.Drawing.Size(247, 396);
            this.userListPanel.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(247, 99);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::chatRoomClient.Properties.Resources.pencil_2;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(48, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(199, 48);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "User 1";
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(259, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.formTable.SetRowSpan(this.tabControl1, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(522, 524);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.BackColor = System.Drawing.Color.Azure;
            this.tabPage1.Controls.Add(this.emoticonPanel);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(514, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lobby";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Azure;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(508, 485);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // emoticonPanel
            // 
            this.emoticonPanel.BackColor = System.Drawing.Color.White;
            this.emoticonPanel.Controls.Add(this.emoticonTable);
            this.emoticonPanel.Location = new System.Drawing.Point(319, 296);
            this.emoticonPanel.Name = "emoticonPanel";
            this.emoticonPanel.Size = new System.Drawing.Size(192, 192);
            this.emoticonPanel.TabIndex = 1;
            this.emoticonPanel.Visible = false;
            // 
            // emoticonTable
            // 
            this.emoticonTable.ColumnCount = 4;
            this.emoticonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.Controls.Add(this.emoticonButton2, 1, 0);
            this.emoticonTable.Controls.Add(this.emoticonButton1, 0, 0);
            this.emoticonTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.emoticonTable.Location = new System.Drawing.Point(0, 0);
            this.emoticonTable.Name = "emoticonTable";
            this.emoticonTable.RowCount = 8;
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.emoticonTable.Size = new System.Drawing.Size(192, 192);
            this.emoticonTable.TabIndex = 0;
            // 
            // emoticonButton2
            // 
            this.emoticonButton2.BackgroundImage = global::chatRoomClient.Properties.Resources._02;
            this.emoticonButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emoticonButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emoticonButton2.FlatAppearance.BorderSize = 0;
            this.emoticonButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emoticonButton2.Location = new System.Drawing.Point(48, 0);
            this.emoticonButton2.Margin = new System.Windows.Forms.Padding(0);
            this.emoticonButton2.Name = "emoticonButton2";
            this.emoticonButton2.Size = new System.Drawing.Size(48, 48);
            this.emoticonButton2.TabIndex = 1;
            this.emoticonButton2.UseVisualStyleBackColor = true;
            this.emoticonButton2.Click += new System.EventHandler(this.emoticon_click);
            // 
            // emoticonButton1
            // 
            this.emoticonButton1.BackgroundImage = global::chatRoomClient.Properties.Resources._01;
            this.emoticonButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emoticonButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emoticonButton1.FlatAppearance.BorderSize = 0;
            this.emoticonButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emoticonButton1.Location = new System.Drawing.Point(0, 0);
            this.emoticonButton1.Margin = new System.Windows.Forms.Padding(0);
            this.emoticonButton1.Name = "emoticonButton1";
            this.emoticonButton1.Size = new System.Drawing.Size(48, 48);
            this.emoticonButton1.TabIndex = 0;
            this.emoticonButton1.UseVisualStyleBackColor = true;
            this.emoticonButton1.Click += new System.EventHandler(this.emoticon_click);
            // 
            // tabPage2
            // 
            this.tabPage2.AllowDrop = true;
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.Azure;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(514, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "+";
            // 
            // myInfoPanel
            // 
            this.myInfoPanel.Controls.Add(this.myNameTextBox);
            this.myInfoPanel.Controls.Add(this.myImageBox);
            this.myInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myInfoPanel.Location = new System.Drawing.Point(3, 3);
            this.myInfoPanel.Name = "myInfoPanel";
            this.myInfoPanel.Size = new System.Drawing.Size(250, 122);
            this.myInfoPanel.TabIndex = 4;
            // 
            // myNameTextBox
            // 
            this.myNameTextBox.BackColor = System.Drawing.Color.Azure;
            this.myNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myNameTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.myNameTextBox.Location = new System.Drawing.Point(107, 21);
            this.myNameTextBox.Name = "myNameTextBox";
            this.myNameTextBox.Size = new System.Drawing.Size(140, 22);
            this.myNameTextBox.TabIndex = 1;
            this.myNameTextBox.Text = "請輸入暱稱";
            this.myNameTextBox.TextChanged += new System.EventHandler(this.myNameTextBox_TextChanged);
            this.myNameTextBox.Enter += new System.EventHandler(this.myNameTextBox_Enter);
            this.myNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myNameTextBox_KeyDown);
            this.myNameTextBox.Leave += new System.EventHandler(this.myNameTextBox_Leave);
            // 
            // myImageBox
            // 
            this.myImageBox.BackColor = System.Drawing.Color.Azure;
            this.myImageBox.BackgroundImage = global::chatRoomClient.Properties.Resources.eraser;
            this.myImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.myImageBox.Location = new System.Drawing.Point(21, 21);
            this.myImageBox.Name = "myImageBox";
            this.myImageBox.Size = new System.Drawing.Size(80, 80);
            this.myImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myImageBox.TabIndex = 0;
            this.myImageBox.TabStop = false;
            this.myImageBox.Click += new System.EventHandler(this.myImageBox_Click);
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
            this.formTable.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.userListPanel.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.emoticonPanel.ResumeLayout(false);
            this.emoticonTable.ResumeLayout(false);
            this.myInfoPanel.ResumeLayout(false);
            this.myInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel formTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel userListPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel myInfoPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button emoticonButton;
        private System.Windows.Forms.Button chatEnterButton;
        private System.Windows.Forms.PictureBox myImageBox;
        private System.Windows.Forms.TextBox myNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel emoticonPanel;
        private System.Windows.Forms.TableLayoutPanel emoticonTable;
        private System.Windows.Forms.Button emoticonButton2;
        private System.Windows.Forms.Button emoticonButton1;
    }
}

