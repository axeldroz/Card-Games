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

        protected void WhenPing(PacketHeader header, Connection connection, Packet00Message packet)
        {
            client.Login();
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
            if (incomingObject.Bet.Equals(null)  || incomingObject.Bet.points == 0)
                client.Bet(new Common.GameUtils.Bet(), incomingObject.Cards);
            else
                client.Bet(incomingObject.Bet, incomingObject.Cards);
        }
        protected void WhenFirstBetRequest(PacketHeader packetHeader, Connection connection, Packet05Bet incomingObject)
        {
        }
        protected void WhenBetAccepted(PacketHeader packetHeader, Connection connection, Packet05Bet incomingObject)
        {
            throw new NotImplementedException();
        }
        protected void WhenPlayingCardRequest(PacketHeader packetHeader, Connection connection,
            Packet07Deck pack)
        {
            Console.WriteLine(pack.Descr);
            try
            {
                client.PlayCard(pack.Deck.cards, pack.Deck2);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception e" + e.ToString());
            }
        }
        protected void WhenShowCards(PacketHeader packetHeader, Connection connection, Packet07Deck pack)
        {
            Console.WriteLine(pack.Descr);
        }

        protected void WhenShowTeam(PacketHeader packetHeader, Connection connection, Packet09Team pack)
        {
            Console.WriteLine(pack.Descr);
            if (pack.Team.Name.Equals("Blue"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

            }
        }
    }
}
