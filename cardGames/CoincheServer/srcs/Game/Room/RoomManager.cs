using Common.GameUtils;
using NetworkCommsDotNet.Connections;
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

        /// <summary>
        /// Add a new player.
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {
            /* petit trick pour appelé ovveride dans une classe parente */
            player.Id = 0;
            player.Score = 0;
            if (DoAddPlayer(player))
                EventPlayerAdded();
        }

        /// <summary>
        /// Ajoute un parie sur la table demandée
        /// </summary>
        /// <param name="bet"></param>
        public void AddBet(Connection c, Bet bet)
        {
            Player p = FindPlayer(c);
            bet.player = p;
            if (DoAddBet(bet))
                EventBetAdded(bet);
        }

        public void AddCard(Connection c, int cardId)
        {
            Player p = FindPlayer(c);
            if (DoAddCard(p, cardId)) { }
                EventCardAdded(p);
        }
    }
}
