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
                Deck.Distrib(team, 2);
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
            if (nextPlayer != null)
                server.AskBet(nextPlayer, _bet);
            else
            {
                Player firstPlayer = team.First().Player.First();
                //Player firstPlayer = bet.player;
                server.AskPlayCard(firstPlayer, DeckRound);
            }
        }

        public void EventCardAdded(Player player)
        {
            Common.IO.OutputManager.Debug.Display("ARoomEventManager", "EventCardAdded() : called");
            Player nextPlayer = NextPlayer(player);
            Common.IO.OutputManager.Debug.DisplayVar("nextPlayer is null", nextPlayer == null);
            if (nextPlayer != null)
                server.AskPlayCard(nextPlayer, DeckRound);
            else
            {
                Player firstPlayer = team.First().Player.First();
                //DeckRound.Clear();
                if (firstPlayer.Deck.cards.Count > 0)
                    server.AskPlayCard(firstPlayer, DeckRound);
                else
                {
                    // jeu finis et on compte les points
                }
            }
        }
    }
}
