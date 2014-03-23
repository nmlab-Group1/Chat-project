using System;
using System.Drawing;
using System.Windows.Forms;

using ATLH323Lib;

namespace chatRoomClient
{
    public partial class VoiceForm : Form
    {
        H323Class h323;

        string localIP;
        string remoteIP;
        string remoteSID;
        Image remoteImage;

        public VoiceForm(string _localIP, string _remoteSID)//, Image _remoteImage)  //calling
        {
            InitializeComponent();

            localIP = _localIP;
            remoteIP = "";
            remoteSID = _remoteSID;
            remoteImage = global::chatRoomClient.Properties.Resources.defaultImage;

            remoteImageBox.BackgroundImage = remoteImage;
            label1.Text = remoteSID;

            h323 = new H323Class();

            h323.EnumSoundRx(); // 檢查語音輸入裝置
            h323.EnumSoundTx(); // 檢查語音輸出裝置
            h323.AutoAnswer = true;         // 自動答話
            h323.SilenceDetection = true;   // 靜音偵測

            h323.RemoteHost = localIP;
            h323.Listen();
        }

        public VoiceForm(string _localIP, string _remoteIP, string _remoteSID)//, Image _remoteImage)  //called
        {
            InitializeComponent();

            localIP = _localIP;
            remoteIP = _remoteIP;
            remoteSID = _remoteSID;
            remoteImage = global::chatRoomClient.Properties.Resources.defaultImage;

            remoteImageBox.BackgroundImage = remoteImage;
            label1.Text = remoteSID;

            h323 = new H323Class();

            h323.EnumSoundRx(); // 檢查語音輸入裝置
            h323.EnumSoundTx(); // 檢查語音輸出裝置
            h323.AutoAnswer = true;         // 自動答話
            h323.SilenceDetection = true;   // 靜音偵測

            h323.RemoteHost = remoteIP;
            hangupButton.BackColor = Color.Green;
        }

        private void hangupButton_Click(object sender, EventArgs e)
        {
            if (hangupButton.BackColor == Color.Green)
            {
                h323.Connect();
                hangupButton.BackColor = Color.Crimson;
            }
            else
            {
                h323.Hangup();
                this.Close();
            }
        }
    }
}
