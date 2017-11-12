using Common.NetworkUtils.Packets;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheClient.Network
{
    public abstract class ACoincheSenderClient : ACoincheConnectionClient
    {
        public ACoincheSenderClient(string _ip, int _port) : base(_ip, _port)
        {

        }

        protected void InitSending(CClient _client)
        {
            InitConnection(_client);
        }

        /*
         * Following function is about sending packet
         */
        public void SendLoginRequest(string _name)
        {
            Packet01LoginRequest pack = new Packet01LoginRequest()
            {
                Name = _name
            };
            NetworkComms.SendObject<Packet01LoginRequest>
                ("LoginRequest", serverInfo.Ip, serverInfo.Port, pack);
        }
        public void SendWaitGameRequest()
        {
            Packet03WaitGameRequest pack = new Packet03WaitGameRequest()
            {
            };
            NetworkComms.SendObject<Packet03WaitGameRequest>
                ("WaitGameRequest", serverInfo.Ip, serverInfo.Port, pack);
        }

        public void SendBetAnswer(Common.GameUtils.Bet _bet)
        {
            Packet05Bet pack = new Packet05Bet()
            {
                Descr = clientInfo.name,
                Bet = _bet
            };
            Common.IO.OutputManager.Debug.DisplayVar("Bet.Points", pack.Bet.points + "");
            NetworkComms.SendObject<Packet05Bet>
                ("BetAnswer", serverInfo.Ip, serverInfo.Port, pack);
            Common.IO.OutputManager.Debug.Display("ACoincheSenderClient", "SendBetAnswer() : sended !");
        } 

        public void SendPlayingCardAnswer(int cardId)
        {
            Packet08CardId pack = new Packet08CardId
            {
                CardId = cardId
            };
            NetworkComms.SendObject<Packet08CardId>
                ("PlayingCardAnswer", serverInfo.Ip, serverInfo.Port, pack);
        }
    }
}
