using Common.NetworkUtils.Packets;
using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet.Connections;

namespace CoincheClient.Network
{
    class NetworkListener : ANetworkListenerCallback
    {
        public NetworkListener(CClient _client) : base (_client)
        {

        }
        public void Init()
        {
            NetworkComms.AppendGlobalIncomingPacketHandler
                <Packet00Message>("Message", this.WhenMessage);
            NetworkComms.AppendGlobalIncomingPacketHandler
                <Packet02LoginAnswer>("LoginAnswer", this.WhenLoginAnswer);
            NetworkComms.AppendGlobalIncomingPacketHandler
                <Packet04WaitGameAnswer>("WaitGameAnswer", this.WhenWaitGameAnswer);
            NetworkComms.AppendGlobalIncomingPacketHandler
                <Packet05Bet>("BetRequest", this.WhenBetRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler
                <Packet05Bet>("FirstBetRequest", this.WhenFirstBetRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler
                <Packet05Bet>("BetAccepted", this.WhenBetAccepted);
            NetworkComms.AppendGlobalIncomingPacketHandler
                <Packet07Deck>("PlayingCardRequest", this.WhenPlayingCardRequest);
        }

    }
}
