using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Network
{
    public class CServer : ACoincheSenderServer
    {
        public CServer(string _ip, int _port) : base(_ip, _port)
        {
            InitSending(this);
        }
    }
}
