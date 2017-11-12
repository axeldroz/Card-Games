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

        public void EventPlayerAdded(Player player, Team team)
        {
            try
            {
                server.InformTeam(player, team);
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
                Deck.Mix();
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
            Player nextPlayer = NextPlayerBet(player);
            Common.IO.OutputManager.Debug.DisplayVar("nextPlayer is null", nextPlayer == null);
            //server.SendCards(nextPlayer); // always before bet
            if (nextPlayer != null)
                server.AskBet(nextPlayer, _bet);
            else
            {
                Player firstPlayer = team.First().Player.First();
                RoundDeck.Asset = bet.suit;
                //Player firstPlayer = bet.player;
                server.AskPlayCard(firstPlayer, RoundDeck);
            }
        }

        public void EventCardAdded(Player player)
        {
            Common.IO.OutputManager.Debug.Display("ARoomEventManager", "EventCardAdded() : called");
            Player nextPlayer = NextPlayerPlayingCard(player);
            Common.IO.OutputManager.Debug.DisplayVar("nextPlayer is null", nextPlayer == null);
            if (nextPlayer != null)
                server.AskPlayCard(nextPlayer, RoundDeck);
            else
            {
                //Player firstPlayer = team.First().Player.First();
                tourPlayingCard = 0;
                Player firstPlayer = RoundDeck.AddPointToTeams();
                RoundDeck.ClearTable();
                if (firstPlayer != null && firstPlayer.Deck.cards.Count > 0)
                    server.AskPlayCard(firstPlayer, RoundDeck);
                else
                {
                    // On recommence les paris
                    DisplayScores();
                    bet = new Bet();
                    Deck.ReGenerate();
                    Deck.Distrib(Team, 2);
                    server.AskBet(Team.First().Player.First(), bet);
                    // jeu finis et on compte les points
                }
            }
        }
    }
}
