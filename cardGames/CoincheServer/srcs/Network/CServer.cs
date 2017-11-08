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
            if (bet.points == 0)
            {
                Common.IO.OutputManager.Debug.Display("Problem bet = 0");
                SendBetRequest(player.Connection, new Common.GameUtils.Bet());
            }
            else
            {
                SendBetRequest(player.Connection, bet);
            }
        }   

        public void AskPlayCard(Common.GameUtils.Player player)
        {
            SendPlayingCardRequest(player.Connection, player.Deck);
        }

    }
}
