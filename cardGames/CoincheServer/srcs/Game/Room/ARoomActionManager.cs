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
            Game.Table.TableManager t;
            try
            {
                t = tables.Last();
                t.AddPlayer(player);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
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
