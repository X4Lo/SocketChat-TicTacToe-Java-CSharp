using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSR_Client.Services
{
    public partial class GameInviteForm : Form
    {
        private String username;
        private String userId;

        public GameInviteForm(String username, String userId)
        {
            InitializeComponent();

            this.username = username;
            this.userId = userId;
            label1.Text = $"Invite to {username} a game:";
        }
        public GameInviteForm()
        {
            InitializeComponent();
        }

        private void GameInviteForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            SocketMessage sm = new SocketMessage.Builder()
                .SetType("gameInvite")
                .SetReceiverId(this.userId)
                .SetPayload(this.comboBox1.SelectedItem.ToString())
                .Build();

            SocketService.Instance.SendData(sm);
            this.Close();
        }
    }
}
