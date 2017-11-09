﻿using Common.GameUtils;
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

        /*
         * Following Handling method for server
         */
        public void AddPlayer(Player player)
        {
            /* petit trick pour appelé ovveride dans une classe parente */
            player.Id = 0;
            player.Score = 0;
            //player.Teamscore = 0;
            Console.WriteLine("RoomManager.AddPlayer");
            if (DoAddPlayer(player))
                EventPlayerAdded();
        }

        /// <summary>
        /// Ajoute un parie sur la table demandée
        /// </summary>
        /// <param name="bet"></param>
        public void AddBet(Connection c, Bet bet)
        {
            Common.IO.OutputManager.Debug.Display("RoomManager", "AddBet() : called");
            Player p = FindPlayer(c);
            Common.IO.OutputManager.Debug.DisplayVar("p.TableID", "" + p.TableId);
            bet.player = p;
            if (DoAddBet(bet))
                EventBetAdded(bet);
        }

        public void AddCard(Connection c, int cardId)
        {
            Common.IO.OutputManager.Debug.Display("RoomManager", "AddCard() : called");
            Player p = FindPlayer(c);
            //Common.IO.OutputManager.Debug.DisplayVar("p.TableID", "" + p.TableId);
            if (DoAddCard(p, cardId)) { }
                EventCardAdded(p);
        }
    }
}
