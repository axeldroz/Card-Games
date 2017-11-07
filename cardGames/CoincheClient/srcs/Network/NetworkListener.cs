using Common.NetworkUtils.Packets;
using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheClient.Network
{
    class NetworkListener : ANetworkListenerCallback
    {
        public NetworkListener(CClient _client) : base (_client)
        {

        }
        public void Init()
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<Packet00Message>("Message", this.WhenMessage);
        }
    }
}
