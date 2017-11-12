using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Network
{
    public class CServer : ACoincheSenderServer
    {
        public CServer(string _ip, int _port) : base(_ip, _port)
        {
            InitSending(this);
        }

        /*
         * Function For TableManager Caller
         */ 
        public void AskBet(Common.GameUtils.Player player, Common.GameUtils.Bet bet)
        {
            Common.IO.OutputManager.Debug.Display("CServer", "AskBet() : called");
            Console.WriteLine("CardCount=" + player.Deck.cards.Count + "");
            if (bet.points == 0)
            {
                Common.IO.OutputManager.Debug.Display("Problem bet = 0");
                SendBetRequest(player.Connection, new Common.GameUtils.Bet(), player.Deck.cards);
            }
            else
            {
                SendBetRequest(player.Connection, bet, player.Deck.cards);
            }
        }

        public void SendCards(Player p)
        {
            SendCardsAnswer(p.Connection, p.Deck);
        }

        public void AskPlayCard(Common.GameUtils.Player player, Round deckRound)
        {
            SendPlayingCardRequest(player.Connection, player.Deck, deckRound);
            Common.IO.OutputManager.Debug.DisplayVar("CServer : deckRound.Count", deckRound.cards.Count + "");

        }

        public void InformTeam(Player player, Team team)
        {
            SendTeamInformation(player.Connection, team);
        }

    }
}
