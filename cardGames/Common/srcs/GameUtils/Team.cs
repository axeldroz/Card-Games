using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.srcs.GameUtils
{
    public class Team
    {
        private int id;
        private string name;
        private Player player1;
        private Player player2;
        private int score;
        public bool full;

        public Team()
        {
            id = 0;
            name = "";
            player1 = null;
            player2 = null;
            score = 0;
            full = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Score { get; set; }
        public bool Full { get; set; }

    }
}
