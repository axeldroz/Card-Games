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
            try
            {
                if (FindTeamAvailable() == null)
                {
                    IsReady = true; // The game is ready
                    Console.WriteLine("Table with teams " + team.First().Name + " and " + team.Last().Name + " is about to start playing ...");
                    var firstPlayer = team.First().Player.First();
                    bet = new Bet();
                    server.AskBet(firstPlayer, bet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EventBetAdded(Player player)
        {

        }
    }
}
