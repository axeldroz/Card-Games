using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.NetworkUtils.Packets;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;

namespace CoincheClient.Network
{
    public abstract class ANetworkListenerCallback
    {
        CClient client;
        public ANetworkListenerCallback(CClient _client)
        {
            client = _client;
        }
        /* Getters & Setters */

        /* Callback Methods 
            ** Syntaxe : When{TypePacket}
        */
        protected void WhenMessage(PacketHeader header, Connection connection, Packet00Message packet)
        {
            string str = header.PacketType.ToString();
            Console.WriteLine(str);
            Console.WriteLine("\nA message was received from " + connection.ToString() + " which said '" + packet.Message + "'.");
        }

        protected void WhenLoginAnswer(PacketHeader packetHeader, Connection connection, Packet02LoginAnswer incomingObject)
        {
            throw new NotImplementedException();
        }

        protected void WhenWaitGameAnswer(PacketHeader packetHeader, Connection connection, Packet04WaitGameAnswer incomingObject)
        {
            throw new NotImplementedException();
        }

        protected void WhenBetRequest(PacketHeader packetHeader, Connection connection, Packet05Bet incomingObject)
        {
            Console.WriteLine("Première étape");
            Console.WriteLine("CardCount3=" + incomingObject.Cards.Count + "");
            client.Bet(incomingObject.Bet, incomingObject.Cards);
        }
        protected void WhenFirstBetRequest(PacketHeader packetHeader, Connection connection, Packet05Bet incomingObject)
        {
            //client.Bet();
        }
        protected void WhenBetAccepted(PacketHeader packetHeader, Connection connection, Packet05Bet incomingObject)
        {
            throw new NotImplementedException();
        }
        protected void WhenPlayingCardRequest(PacketHeader packetHeader, Connection connection, Packet07Deck incomingObject)
        {
            client.PlayCard();
        }
        protected void WhenShowCards(PacketHeader packetHeader, Connection connection, Packet07Deck pack)
        {
            Common.IO.OutputManager.Debug.Display("ANetworkListenerCallback", "WhenShowCards");
            Console.WriteLine(pack.Descr);
            Common.IO.OutputManager.Standard.Display.ListCard(pack.Deck.cards);
        }
    }
}
