using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Room
{
    public abstract class ARoomRootManager
    {
        protected CoincheServer.Network.CServer server;
        protected Common.GameUtils.Room room;
        protected List<CoincheServer.Game.Table.TableManager> tables;
        public ARoomRootManager(CoincheServer.Network.CServer _server)
        {
            server = _server;
            room = new Common.GameUtils.Room();    
        }
    }
}
