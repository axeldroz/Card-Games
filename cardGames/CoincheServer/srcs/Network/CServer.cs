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
        public void AskABet(Common.GameUtils.Player player, Common.GameUtils.Bet bet)
        {
            SendBetRequest(player.Connection, bet);
        }

        public void AskPlayCard(Common.GameUtils.Player player)
        {
            SendPlayingCardRequest(player.Connection, player.Deck);
        }

    }
}
