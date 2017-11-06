using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.srcs.GameUtils
{
    public struct Card
    {
        public string suit; // couleur
        public string number;
        public Player player; // player qui joue la carte
        public int point; // point que vaut la carte
    }
}
