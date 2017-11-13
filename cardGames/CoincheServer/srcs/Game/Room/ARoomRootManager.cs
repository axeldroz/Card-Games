/*
 * Created by Axel Drozdzynski on 11/06/2017
 */
using CoincheServer.Network;
using NetworkCommsDotNet.Connections;
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
        protected List<Common.GameUtils.Player> roomPlayers;
        public ARoomRootManager(CoincheServer.Network.CServer _server)
        {
            server = _server;
            room = new Common.GameUtils.Room();
            tables = new List<Table.TableManager>();
            tables.Add(new Table.TableManager(server));
            roomPlayers = new List<Common.GameUtils.Player>();
        }

        public void Init(CServer serv)
        {
            
        }

        public Game.Table.TableManager FindTable(Common.GameUtils.Player player)
        {
            if (player == null)
                throw new ArgumentNullException();
            return (tables.ElementAt(player.TableId));
        }

        public Common.GameUtils.Player FindPlayer(Connection c)
        {
            foreach(Common.GameUtils.Player p in roomPlayers)
            {
                if (p.Connection == c)
                    return (p);
            }
            return (null);
        }
    }
}
