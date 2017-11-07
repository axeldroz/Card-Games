using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.NetworkUtils.Packets;
using NetworkCommsDotNet.Connections;

namespace CoincheServer.Network
{
    public abstract class ACoincheSenderServer : ACoincheConnectionServer
    {
        public ACoincheSenderServer(string _ip, int _port) : base(_ip, _port)
        {
            
        }

        protected void InitSending(CServer _serv)
        {
            InitConnection(_serv);
        }

        /*
         * Following function is about sending packet
         */
        public void SendLoginAnswer(Connection c, bool accepted)
        {
            Packet02LoginAnswer pack = new Packet02LoginAnswer()
            {
                accepted = true
            };
            c.SendObject<Packet02LoginAnswer>("LoginAnswer", pack);
        }

        public void SendWaitGameAnswer(Connection c, bool accepted)
        {
            Packet04WaitGameAnswer pack = new Packet04WaitGameAnswer()
            {
                accepted = true
            };
            c.SendObject<Packet04WaitGameAnswer>("WaitGameAnswer", pack);
        }
        public void SendFirstBetRequest(Connection c, Common.GameUtils.Bet bet)
        {
            Packet05Bet pack = new Packet05Bet()
            {
                descr = Common.IO.Messages.Server.BetRequest,
                bet = bet
            };
            c.SendObject<Packet05Bet>("FirstBetRequest", pack);
        }
        public void SendBetRequest(Connection c, Common.GameUtils.Bet bet)
        {
            Packet05Bet pack = new Packet05Bet()
            {
                descr = Common.IO.Messages.Server.BetRequest,
                bet = bet
            };
            c.SendObject<Packet05Bet>("BetRequest", pack);
        }
        public void SendBetAccepted(Connection c, Common.GameUtils.Bet bet)
        {
            Packet05Bet pack = new Packet05Bet()
            {
                descr = Common.IO.Messages.Server.BetRequest,
                bet = bet
            };
            c.SendObject<Packet05Bet>("BetAccepted", pack);
        }
        public void SendPlayingCardRequest(Connection c, Common.GameUtils.Deck _deck)
        {
            Packet07Deck pack = new Packet07Deck()
            {
                descr = Common.IO.Messages.Server.BetRequest,
                deck = _deck
            };
            c.SendObject<Packet07Deck>("PlayingCardRequest", pack);
        }
    }
}