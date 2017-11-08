using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Room
{
    public class RoomManager : ARoomActionManager
    {
        public RoomManager(CoincheServer.Network.CServer _server) : base(_server)
        {

        }

        /*
         * Following Handling method for server
         */
        void AddPlayer(Player player)
        {
            /* petit trick pour appelé ovveride dans une classe parente */
            player.Id = 0;
            player.Score = 0;
            player.Teamscore = 0;

            if (((ARoomActionManager)this).DoAddPlayer(player))
                EventPlayerAdded();
        }

        /// <summary>
        /// Ajoute un parie sur la table demandée
        /// </summary>
        /// <param name="bet"></param>
        void AddBet(Bet bet)
        {

        }
    }
}
