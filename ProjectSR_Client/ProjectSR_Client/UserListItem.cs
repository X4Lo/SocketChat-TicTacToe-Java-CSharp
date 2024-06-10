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

namespace ProjectSR_Client
{
    public partial class UserListItem : UserControl
    {
        private String Id { get; set; }
        private String Username { get; set; }

        public UserListItem(String id, String username)
        {
            InitializeComponent();

            this.Id = id;
            this.Username = username;

            this.label1.Text = this.Username;

        }

        public UserListItem()
        {
            InitializeComponent();
        }

        private void UserListItem_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (this.Username != SocketService.Instance.Username)
            {
                GameInviteForm gameInviteForm = new GameInviteForm(this.Username, this.Id);
                gameInviteForm.Show();
            }
        }
    }
}
