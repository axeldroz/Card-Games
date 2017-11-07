using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.NetworkServer
{
    public abstract class ANetworkListenerCallback
    {
        public CoincheServer server;
        public ANetworkListenerCallback(CoincheServer _server)
        {
            server = _server;
        }
        
        public CoincheServer Server
        {
            get
            {
                return server;
            }
        }

    }
}
