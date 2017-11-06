using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.srcs.GameUtils
{
    public class Player
    {
        private int id;
        private string name;
        private int score;
        private int teamscore;
        private int status; // 0 = afk, 1 = ready for a game
        private Deck deck;
        private Team team;

        public Player()
        {
            id = 0;
            name = "";
            score = 0;
            teamscore = 0;
            status = 0;
            deck = null;
            team = null;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Teamscore { get; set; }
        public int Status { get; set; }
        public Deck Deck { get; set; }
        public Team Team { get; set; }
        
    }
}
