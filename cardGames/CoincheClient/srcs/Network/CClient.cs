using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheClient.Network
{
    public class CClient : ACoincheConnectionClient
    {
        public CClient(string _ip, int _port) : base(_ip, _port)
        {
            InitConnection(this);
            Ping();
        }
    }
}
