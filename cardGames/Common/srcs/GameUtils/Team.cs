using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    public class Team
    {
        private int id;
        private string name;
        private List<Player> player;
        private int score;
        public bool full;

        public Team()
        {
            id = 0;
            name = "";
            player = new List<Player>();
            score = 0;
            full = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Player { get; set; }
        public int Score { get; set; }
        public bool Full { get; set; }

    }
}
