namespace chatRoomClient
{
    partial class VoiceForm
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
            this.remoteImageBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hangupButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.remoteImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // remoteImageBox
            // 
            this.remoteImageBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.remoteImageBox.Location = new System.Drawing.Point(77, 19);
            this.remoteImageBox.Margin = new System.Windows.Forms.Padding(0);
            this.remoteImageBox.Name = "remoteImageBox";
            this.remoteImageBox.Size = new System.Drawing.Size(128, 128);
            this.remoteImageBox.TabIndex = 0;
            this.remoteImageBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hangupButton
            // 
            this.hangupButton.BackColor = System.Drawing.Color.Crimson;
            this.hangupButton.FlatAppearance.BorderSize = 0;
            this.hangupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hangupButton.Location = new System.Drawing.Point(77, 196);
            this.hangupButton.Name = "hangupButton";
            this.hangupButton.Size = new System.Drawing.Size(128, 37);
            this.hangupButton.TabIndex = 2;
            this.hangupButton.UseVisualStyleBackColor = false;
            this.hangupButton.Click += new System.EventHandler(this.hangupButton_Click);
            // 
            // VoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.hangupButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remoteImageBox);
            this.Name = "VoiceForm";
            this.Text = "VoiceForm";
            ((System.ComponentModel.ISupportInitialize)(this.remoteImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox remoteImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hangupButton;
    }
}