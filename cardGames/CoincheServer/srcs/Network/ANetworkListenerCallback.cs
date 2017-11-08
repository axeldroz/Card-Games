using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.NetworkUtils.Packets;

namespace CoincheServer.Network
{
    /// <summary>
    /// Callback when receive packet
    /// </summary>
    public abstract class ANetworkListenerCallback
    {
        public CServer server;
        public ANetworkListenerCallback(CServer _server)
        {
            server = _server;
        }
        
        /* Getters & Setters */
        public CServer Server
        {
            get
            {
                return server;
            }
        }

        /* Callback Methods 
         ** Syntaxe : When{TypePacket}
         */
        protected void WhenMessage(PacketHeader header, Connection connection, Packet00Message packet)
        {
            string str = header.PacketType.ToString();
            Packet00Message answer = new Packet00Message()
            {
                message = "Hello client ! "
            };
            //answer.message = "Hello client ! ";
            Console.WriteLine(str);
            Console.WriteLine("\nA message was received from " + connection.ToString() + " which said '" + packet.message + "'.");

            connection.SendObject<Packet00Message>("Message", answer);
        }

        protected void WhenPing(PacketHeader header, Connection connection, Packet00Message packet)
        {
            string str = header.PacketType.ToString();
            Packet00Message answer = new Packet00Message();
            answer.message = "Hello client ! ";
            Console.WriteLine(str);
            Console.WriteLine("\nA message was received from " + connection.ToString() + " which said '" + packet.message + "'.");

            connection.SendObject<Packet00Message>("Message", answer);
        }

        protected void WhenLoginRequest(PacketHeader packetHeader, Connection connection, 
            Packet01LoginRequest pack)
        {
            Common.GameUtils.Player player = new Common.GameUtils.Player
            {
                Name = pack.name,
                Connection = connection
            };
            server.Room.AddPlayer(player);
        }

        protected void WhenWaitGameRequest(PacketHeader packetHeader, Connection connection, 
            Packet03WaitGameRequest incomingObject)
        {
            throw new NotImplementedException();
        }

        protected void WhenBetAnswer(PacketHeader packetHeader, Connection connection, 
            Packet05Bet incomingObject)
        {
            throw new NotImplementedException();
        }
        protected void WhenPlayingCardAnswer(PacketHeader packetHeader, Connection connection, 
            Packet07Deck incomingObject)
        {
            throw new NotImplementedException();
        }

    }
}
