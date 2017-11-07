using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    public struct Bet
    {
        public string suit; // couleur
        public int points; // point que l'on veut parier
        public Player player; // player qui parie
        public Team team; // team qui parie
        public bool coinched;
        public bool surcoinched;
        public int id;
    }
}