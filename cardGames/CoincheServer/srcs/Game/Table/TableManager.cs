using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoincheServer;
using System.IO;

namespace CoincheServer.Game.Table
{
    public class TableManager : GameManagerServer
    {
        public TableManager()
        {
            
        }

        public Team findTeamAvailable()
        {
            foreach (Team elem in team)
            {
                if (!elem.full)
                    return (elem);
            }
            return (null);
        }

        public int addPlayer(string name, int id)
        {
            try
            {
                if (name == null || id < 0)
                    throw new ArgumentException("Error: The player must have at least a name and an id >= 0");
                Team tmp;
                if ((tmp = findTeamAvailable()) == null)
                    throw new Exception("Error: All teams are full");
                Player newPlayer = new Player
                {
                    Name = name,
                    Id = id,
                    Team = tmp
                };
                player.Add(newPlayer);
                Console.WriteLine("Player " + name + " added to the team N°" + tmp.Id);
                if (tmp.Player.Count == 2)
                    tmp.Full = true;
                return (0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " // Source : " + ex.Source);
                return (-1);
            }
            
        }

        public bool IsFull()
        {
            if (team.First().full && team.Last().full)
                return (true);
            return (false);
        }
        

    }
}
