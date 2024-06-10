using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSR_Client.Classes
{
    public class XO : Game
    {
        private List<string> data;

        private string[] matrice;
        public XO()
        {
        }
        public List<string> Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
