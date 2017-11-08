﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Room
{
    public abstract class ARoomEventManager : ARoomRootManager
    {
        public ARoomEventManager(CoincheServer.Network.CServer _server) : base(_server)
        {

        }

        /*
         * Here is Event of manager
         */
        public void EventPlayerAdded()
        {
            Game.Table.TableManager t = tables.Last();
            // check si assez de player pour lancer partie
            if (t.IsFull())
            {
                // t.Start();
            }
        }
    }
}