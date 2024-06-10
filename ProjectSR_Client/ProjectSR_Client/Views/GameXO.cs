using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectSR_Client.Classes;
using ProjectSR_Client.Services;

namespace ProjectSR_Client.Views
{
    public partial class GameXO : Form
    {
        private XO game;
        private String currentUserId;
        private String currentUserSign;

        private String otherPlayerId;
        private String otherPlayerName;

        public GameXO(XO game)
        {
            InitializeComponent();

            this.game = game;
            this.currentUserId = SocketService.Instance.Id;

            if (currentUserId == game.Player1_Id)
            {
                currentUserSign = game.Player1_Sign;
                otherPlayerId = game.Player2_Id;
                otherPlayerName = game.Player2_Username;
            }
            else
            {
                currentUserSign = game.Player2_Sign;
                otherPlayerId = game.Player1_Id;
                otherPlayerName = game.Player1_Username;
            }

            if (currentUserId == game.TurnId)
            {
                label_turn.Text = "Its your turn";
                label_turn.ForeColor = Color.LawnGreen;
            }
            else
            {

                label_turn.Text = $"Its {otherPlayerName}'s turn";
                label_turn.ForeColor = Color.Crimson;
            }

            label_sign.Text = $"You are: {currentUserSign}";

            b1.Text = b2.Text = b3.Text = b4.Text = b5.Text = b6.Text = b7.Text = b8.Text = b9.Text = "";
        }

        public GameXO()
        {
            InitializeComponent();
        }

        public void updateGame(XO game)
        {
            this.game = game;

            if (currentUserId == game.TurnId)
            {
                label_turn.Text = "Its your turn";
                label_turn.ForeColor = Color.LawnGreen;
            }
            else
            {

                label_turn.Text = $"Its {otherPlayerName}'s turn";
                label_turn.ForeColor = Color.Crimson;
            }

            if (game.Winner != "")
            {
                label_turn.ForeColor = Color.Gold;
                if (game.Winner == "Draw")
                {
                    label_turn.ForeColor = Color.Gold;
                    label_turn.Text = "Its a draw !!!";
                }
                else
                {
                    label_turn.ForeColor = Color.LawnGreen;
                    label_turn.Text = game.Winner + " Won !!!!";
                }
            }

            // update buttons text
            b1.Text = game.Data[0];
            b2.Text = game.Data[1];
            b3.Text = game.Data[2];
            b4.Text = game.Data[3];
            b5.Text = game.Data[4];
            b6.Text = game.Data[5];
            b7.Text = game.Data[6];
            b8.Text = game.Data[7];
            b9.Text = game.Data[8];
        }

        private void play(int index)
        {
            if (currentUserId == game.TurnId && game.Winner == "")
            {

                SocketMessage sm = new SocketMessage.Builder()
                    .SetType("gamePlay")
                    .SetPayload(game.Id)
                    .SetReceiverId(index.ToString())
                    .Build();

                SocketService.Instance.SendData(sm);
            }
        }

        private void GameXO_Load(object sender, EventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(0);
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(1);
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(2);
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(3);
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(4);
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(5);
            }
        }

        private void b7_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(6);
            }
        }

        private void b8_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(7);
            }
        }

        private void b9_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                play(8);
            }
        }
    }
}
