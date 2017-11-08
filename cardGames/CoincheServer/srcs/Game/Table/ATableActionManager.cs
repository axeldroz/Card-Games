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
            if (tmp == null && IsReady == false) // Check if a Team is available.
            {
                IsReady = true;
                var firstPlayer = team.First().Player.First();
                server.AskBet(firstPlayer, bet);
            }
            else if (tmp.Player.Count < 2) // Check if the team is not full.
            {
                tmp.Player.Add(player);
                Console.WriteLine("Player " + player.Name + "has join the team " + tmp.Name + "!");
                if (tmp.Player.Count == 2)
                {
                    tmp.Full = true; // the team is full.
                }
            }
        }

        public void DoAddCard(Player player)
        {

        }
    }
}
