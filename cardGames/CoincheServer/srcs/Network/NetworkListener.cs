using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.NetworkUtils.Packets;
using NetworkCommsDotNet;

namespace CoincheServer.Network
{
    public class NetworkListener : ANetworkListenerCallback
    {
        public NetworkListener(CServer _server) : base(_server)
        {

        }

        /// <summary>
        /// Init Callback Method
        /// </summary>
        public void Init()
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<Packet00Message>
                ("Message", this.WhenMessage);
            NetworkComms.AppendGlobalIncomingPacketHandler<Packet00Message>
                ("Ping", this.WhenPing);
        }

    }
}

