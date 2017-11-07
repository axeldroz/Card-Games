using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheClient.Network
{
    public abstract class ACoincheSenderClient : ACoincheConnectionClient
    {
        public ACoincheSenderClient(string _ip, int _port) : base(_ip, _port)
        {

        }

        protected void InitSending(CClient _client)
        {
            InitConnection(_client);
        }
    }
}
