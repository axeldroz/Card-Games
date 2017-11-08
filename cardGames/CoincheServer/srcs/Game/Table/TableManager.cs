using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoincheServer;
using System.IO;
using CoincheServer.Network;

namespace CoincheServer.Game.Table
{
    public class TableManager : ATableActionManager
    {
        public TableManager(CServer _server) : base(_server)
        {

        }

        /// <summary>
        /// Add a new player to the table. If the Table and the teams are full, the game start.
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {
            try
            {
                Console.WriteLine("TableManager.AddPlayer()");
                DoAddPlayer(player);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " // Source : " + ex.Source);
            }
        }

        /// <summary>
        /// Play a card.
        /// </summary>
        /// <param name="player"></param>
        public void AddCard(Player player)
        {
            try
            {
                DoAddCard(player);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " // Source : " + ex.Source);
            }
        }


    }
}
