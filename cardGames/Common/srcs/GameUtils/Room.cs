using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    public class Room
    {
        List<Player> waitingPlayers;
        public Room()
        {
            waitingPlayers = new List<Player>();
        }
        public List<Player> WaitingPlayers
        {
            get
            {
                return (waitingPlayers);
            }
        }

        public void Add(Player player)
        {
            waitingPlayers.Add(player);
        }
    }
}
