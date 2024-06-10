using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSR_Client.Classes
{
    public class Game
    {
        private string id;
        private string type;

        private string player1_id;
        private string player1_username;
        private string player1_sign;

        private string player2_id;
        private string player2_username;
        private string player2_sign;

        private string turnId;
        private string winner;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Player1_Id
        {
            get { return player1_id; }
            set { player1_id = value; }
        }

        public string Player1_Username
        {
            get { return player1_username; }
            set { player1_username = value; }
        }

        public string Player1_Sign
        {
            get { return player1_sign; }
            set { player1_sign = value; }
        }

        public string Player2_Id
        {
            get { return player2_id; }
            set { player2_id = value; }
        }

        public string Player2_Username
        {
            get { return player2_username; }
            set { player2_username = value; }
        }

        public string Player2_Sign
        {
            get { return player2_sign; }
            set { player2_sign = value; }
        }

        public string TurnId
        {
            get { return turnId; }
            set { turnId = value; }
        }

        public string Winner
        {
            get { return winner; }
            set { winner = value; }
        }

    }
}
