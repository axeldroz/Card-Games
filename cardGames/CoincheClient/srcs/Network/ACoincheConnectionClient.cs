using Common.NetworkUtils;
using Common.NetworkUtils.Packets;
using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheClient.Network
{
    public class ACoincheConnectionClient
    {
        protected ServerInfo serverInfo;
        private NetworkListener nl;
        public ACoincheConnectionClient(string _ip, int _port)
        {
            serverInfo.ip = _ip;
            serverInfo.port = _port;
        }

        protected void InitConnection(CClient _son)
        {
            nl = new NetworkListener(_son);
            nl.Init();
        }

        public void Ping()
        {
            Packet00Message ping;
            ping.message = "PING";
            NetworkComms.SendObject<Packet00Message>("Message", serverInfo.ip, serverInfo.port, ping);
        }
    }
}
