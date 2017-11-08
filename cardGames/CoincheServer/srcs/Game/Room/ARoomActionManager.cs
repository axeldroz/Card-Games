using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Room
{
    public abstract class ARoomActionManager : ARoomEventManager
    {
        public ARoomActionManager(CoincheServer.Network.CServer _server) : base(_server)
        {

        }

        /*
         * Here is action of Room Manager
         */
        public bool DoAddPlayer(Player player)
        {
            if (player == null)
                return (false);
            if (room == null)
                return (false);

            Console.WriteLine("RoomActionManager.DoAddPlayer");
            room.Add(player);
            Game.Table.TableManager t = tables.Last();
            try
            {
                t.AddPlayer(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                t = new Table.TableManager(server);
                tables.Add(t);
                t.AddPlayer(player);
            }
                return (true);
        }
    }
}
