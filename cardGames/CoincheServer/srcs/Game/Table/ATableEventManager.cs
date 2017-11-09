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
                    EventGameIsReady();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EventGameIsReady()
        {
            try
            {
                IsReady = true; // The game is ready
                Console.WriteLine("Table with teams " + team.First().Name + " and " + team.Last().Name + " is about to start playing ...");
                Deck.Generate();
                Deck.Distrib(team);
                var firstPlayer = team.First().Player.First();
                bet = new Bet();
                server.AskBet(firstPlayer, bet);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.ToString());
            }
        }

        public void EventBetAdded(Player player, Bet _bet)
        {
            Common.IO.OutputManager.Debug.Display("ARoomEventManager", "EventAddBet() : called");
            Player nextPlayer = NextPlayer(player);
            Common.IO.OutputManager.Debug.DisplayVar("nextPlayer is null", nextPlayer == null);
            //server.SendCards(nextPlayer); // always before bet
            server.AskBet(nextPlayer, _bet);
        }
    }
}
