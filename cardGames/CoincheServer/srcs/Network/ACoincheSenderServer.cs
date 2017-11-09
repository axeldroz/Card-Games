﻿using System;
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
                Accepted = true
            };
            c.SendObject<Packet02LoginAnswer>("LoginAnswer", pack);
        }

        public void SendWaitGameAnswer(Connection c, bool accepted)
        {
            Packet04WaitGameAnswer pack = new Packet04WaitGameAnswer()
            {
                Accepted = true
            };
            c.SendObject<Packet04WaitGameAnswer>("WaitGameAnswer", pack);
        }
        public void SendFirstBetRequest(Connection c, Common.GameUtils.Bet bet)
        {
            Packet05Bet pack = new Packet05Bet()
            {
                Descr = Common.IO.Messages.Server.BetRequest,
                Bet = bet
            };
            c.SendObject<Packet05Bet>("FirstBetRequest", pack);
        }
        public void SendBetRequest(Connection c, Common.GameUtils.Bet _bet, List<Common.GameUtils.Card> _cards)
        {
            Common.IO.OutputManager.Debug.Display("CServerSender", "SendBetRequest() : called");
            Packet05Bet pack = new Packet05Bet()
            {
                Descr = Common.IO.Messages.Server.BetRequest,
                Bet = _bet,
                    Cards = _cards
                };
            Console.WriteLine("CardCount2=" + pack.Cards.Count + "");
            try
            {
                c.SendObject<Packet05Bet>("BetRequest", pack);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException : " + ex.ToString());
                throw ex;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.ToString());
            }
        }
        public void SendBetAccepted(Connection c, Common.GameUtils.Bet bet)
        {
            Packet05Bet pack = new Packet05Bet()
            {
                Descr = Common.IO.Messages.Server.BetRequest,
                Bet = bet
            };
            c.SendObject<Packet05Bet>("BetAccepted", pack);
        }
        public void SendPlayingCardRequest(Connection c, Common.GameUtils.Deck _deck, Common.GameUtils.Deck _deckRound)
        {
            Packet07Deck pack = new Packet07Deck()
            {
                Descr = Common.IO.Messages.Server.BetRequest,
                Deck = _deck,
                Deck2 = _deckRound
            };
            c.SendObject<Packet07Deck>("PlayingCardRequest", pack);
        }
        public void SendCardsAnswer(Connection c, Common.GameUtils.Deck _deck)
        {
            Packet07Deck pack = new Packet07Deck()
            {
                Descr = "Here is your Cards :",
                Deck = _deck
            };
            c.SendObject<Packet07Deck>("ShowCards", pack);
        }
    }
}