using CoincheServer.Network;
using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Table
{
    public abstract class ATableActionManager : ATableEventManager
    {
        public ATableActionManager(CServer _server) : base(_server)
        {

        }

        public void DoAddPlayer(Player player)
        {
            Team tmp = FindTeamAvailable();
            if (tmp != null) // Check if the team is not full.
            {
                Console.WriteLine("TableActionManager.DoAddPLayer()");
                tmp.Player.Add(player);
                Console.WriteLine("Player " + player.Name + "has join the team " + tmp.Name + "!");
                if (tmp.Player.Count == 2)
                {
                    tmp.Full = true; // the team is full.
                }
                EventPlayerAdded(player);
            }
            else
            {
                throw new Exception("Error: Couldn't add new player, teams are full or null");
            }
        }

        public void DoAddCard(Player player)
        {

        }

        public void DoAddBet(Player player, Bet newBet)
        {
            bet = newBet;
            EventBetAdded(player);
        }
    }
}
