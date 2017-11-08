using CoincheServer.Network;
using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Table
{
    public abstract class ATableEventManager : ATableRootManager
    {
        public ATableEventManager(CServer _server) : base(_server)
        {

        }

        public void EventPlayerAdded(Player player)
        {
            if (FindTeamAvailable() == null)
            {
                IsReady = true; // The game is ready
                Console.WriteLine("Table with teams " + team.First().Name + " and " + team.Last().Name + " is about to start playing ...");
                var firstPlayer = team.First().Player.First();
                server.AskBet(firstPlayer, bet);
                firstPlayer.HasPlay = true;
            }
        }
    }
}
