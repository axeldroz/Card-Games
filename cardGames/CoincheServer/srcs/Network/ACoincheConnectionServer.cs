using Common.NetworkUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Network
{
    public abstract class ACoincheConnectionServer
    {
        protected ServerInfo serverInfo;
        private NetworkListener nl;
        public ACoincheConnectionServer(string _ip, int _port)
        {
            serverInfo.ip = _ip;
            serverInfo.port = _port;
        }
        public void InitConnection(CServer _son)
        {
            nl = new NetworkListener(_son);
            nl.Init();
        }
        public string Ip
        {
            get
            {
                return serverInfo.ip;
            }
            set
            {
                serverInfo.ip = value;
            }
        }
        public int Port
        {
            get
            {
                return serverInfo.port;
            }
            set
            {
                serverInfo.port = value;
            }
        }
    }
}