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
    public partial class GameInviteRequest : Form
    {
        private SocketMessage socketMessage;

        public GameInviteRequest(SocketMessage socketMessage)
        {
            InitializeComponent();

            this.socketMessage = socketMessage;
            this.label1.Text =
                $"{this.socketMessage.SenderUsername.ToString()} has invited you to a game of {this.socketMessage.Payload.ToString()}";
        }

        public GameInviteRequest()
        {
            InitializeComponent();
        }

        private void btn_refuse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            SocketMessage sm = new SocketMessage.Builder()
                .SetType("gameStart")
                .SetPayload(socketMessage.Payload)
                .SetReceiverId(socketMessage.SenderId)
                .Build();

            SocketService.Instance.SendData(sm);
            this.Close();
        }
    }
}
