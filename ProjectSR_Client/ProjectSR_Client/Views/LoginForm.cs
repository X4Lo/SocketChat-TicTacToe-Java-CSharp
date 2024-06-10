using System;
using System.Windows.Forms;
using ProjectSR_Client.Services;

namespace ProjectSR_Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SocketService.Instance.MainWindow = new HomeWindow();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String formatedUsername = tbox_username.Text.Trim();
            if (string.IsNullOrWhiteSpace(formatedUsername))
            {
                MessageBox.Show("Please enter a valid username!");
            }
            else
            {
                String ip = tbox_ip.Text.Trim();
                int port = Int16.Parse(tbox_port.Text.Trim());

                SocketService.Instance.Username = formatedUsername;
                Boolean restult = SocketService.Instance.doConnect(ip, port);

                if (!restult)
                {
                    MessageBox.Show("Cannot connect to the server!");
                }
                else
                {
                    SocketService.Instance.MainWindow.Show();
                    this.Hide();
                }
            }
        }
    }
}
