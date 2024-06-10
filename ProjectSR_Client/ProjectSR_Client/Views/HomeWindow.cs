using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectSR_Client.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectSR_Client
{
    public partial class HomeWindow : Form
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_title.Text = $"Welcome {SocketService.Instance.Username} !";
        }

        private void Form1_Leave(object sender, EventArgs e)
        {

        }

        private void HomeWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = SocketService.Instance.Username;
            string message = textBox1.Text;
            string formattedMessage = $"{username}: {message}\n";

            //richTextBox1.AppendText(formattedMessage);

            //int start = richTextBox1.Text.LastIndexOf(formattedMessage);
            //int usernameLength = username.Length;

            //// Select the username text
            //richTextBox1.Select(start, usernameLength);

            //// Set the selected text to bold
            //richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);

            //// Reset the selection to the end for further typing or appending
            //richTextBox1.Select(richTextBox1.TextLength, 0);
            //richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);

            SocketMessage sm = new SocketMessage();
            sm.SenderId = SocketService.Instance.Id;
            sm.SenderUsername = SocketService.Instance.Username;
            sm.Type = "chat";
            sm.Payload = message;
            SocketService.Instance.SendData(sm);

            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameInviteRequest request = new GameInviteRequest();
            request.Show();
        }
    }
}
