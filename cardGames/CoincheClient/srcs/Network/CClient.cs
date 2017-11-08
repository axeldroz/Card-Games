using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheClient.Network
{
    public class CClient : ACoincheSenderClient
    {
        public CClient(string _ip, int _port) : base(_ip, _port)
        {
            InitSending(this);
            Ping();
        }

        /*
         * Explicit functions
         */
        public void Login()
        {
            string name;

            name = Common.IO.InputManager.Client.CreateLogin();
            clientInfo.name = name;
            SendLoginRequest(clientInfo.name);
            Console.WriteLine("Client sended LoginRequest");
        }

        public void WaitGame()
        {
            SendWaitGameRequest();
        }

        public void Bet()
        {
            Common.GameUtils.Bet bet;

            Console.WriteLine("CClient.Bet()");
            bet = Common.IO.InputManager.Client.CreateBet();
            SendBetAnswer(bet);
        }

        /* to finish */
        public void PlayCard()
        {
            Common.GameUtils.Card card;
        }
    }
}
