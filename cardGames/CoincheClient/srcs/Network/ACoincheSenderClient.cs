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
        public void SendLoginAnswer()
        {
            Packet01LoginRequest pack = new Packet01LoginRequest();
            pack.name = this.clientInfo.name;
            NetworkComms.SendObject<Packet01LoginRequest>
                ("LoginRequest", serverInfo.ip, serverInfo.port, pack);
        }
        public void SendWaitGameRequest()
        {
            Packet03WaitGameRequest pack = new Packet03WaitGameRequest()
            {
            };
            NetworkComms.SendObject<Packet03WaitGameRequest>
                ("WaitGameRequest", serverInfo.ip, serverInfo.port, pack);
        }

        public void SendBetAnswer(Common.GameUtils.Bet _bet)
        {
            Packet05Bet pack = new Packet05Bet()
            {
                descr = clientInfo.name,
                bet = _bet
            };
            NetworkComms.SendObject<Packet05Bet>
                ("BetAnswer", serverInfo.ip, serverInfo.port, pack);
        }

        public void SendPlayingCardAnswer(Common.GameUtils.Card _card)
        {
            Packet06Card pack = new Packet06Card()
            {
                descr = clientInfo.name,
                card = _card
            };
            NetworkComms.SendObject<Packet06Card>
                ("PlayingCardAnswer", serverInfo.ip, serverInfo.port, pack);
        }
    }
}
