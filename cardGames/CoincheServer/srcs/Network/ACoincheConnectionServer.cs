using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.NetworkServer
{
    public abstract class ACoincheConnectionServer
    {
        private string ip;
        private int port;
        public ACoincheConnectionServer(string _ip, int _port)
        {
            this.ip = _ip;
            this.port = _port;
        }
    }
}