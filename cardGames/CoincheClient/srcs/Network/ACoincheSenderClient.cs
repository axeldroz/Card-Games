﻿using Common.NetworkUtils.Packets;
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
                Descr = clientInfo.name,
                Bet = _bet
            };
            Common.IO.OutputManager.Debug.DisplayVar("Bet.Points", pack.Bet.points + "");
            NetworkComms.SendObject<Packet05Bet>
                ("BetAnswer", serverInfo.ip, serverInfo.port, pack);
            Common.IO.OutputManager.Debug.Display("ACoincheSenderClient", "SendBetAnswer() : sended !");
        } 

        public void SendPlayingCardAnswer(Common.GameUtils.Card _card)
        {
            Packet06Card pack = new Packet06Card()
            {
                Descr = clientInfo.name,
                Card = _card
            };
            NetworkComms.SendObject<Packet06Card>
                ("PlayingCardAnswer", serverInfo.ip, serverInfo.port, pack);
        }
    }
}
