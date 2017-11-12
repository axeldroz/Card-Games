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
        protected ClientInfo clientInfo;
        private NetworkListener nl;
        public ACoincheConnectionClient(string _ip, int _port)
        {
            serverInfo.Ip = _ip;
            serverInfo.Port = _port;
            clientInfo.name = "login";
        }

        protected void InitConnection(CClient _son)
        {
            nl = new NetworkListener(_son);
            nl.Init();
        }

        public void Ping()
        {
            Packet00Message ping = new Packet00Message();
            ping.Message = "PING";
            try
            {
                NetworkComms.SendObject<Packet00Message>("Ping", serverInfo.Ip, serverInfo.Port, ping);
            }
            catch(CommsException e)
            {
                throw e;
            }
            Console.WriteLine("Ping sended");
        }
    }
}
