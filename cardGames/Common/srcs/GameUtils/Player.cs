using Common.srcs.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    public class Player
    {
        /* gérer par CServer */
        private int id;
        private string name;
        private int status; // 0 = afk, 1 = ready for a game
        private NetworkCommsDotNet.Connections.Connection connection;

        /* gérer par TableManger */
        private int score;
        //private int teamscore;
        private Deck deck;
        private Team team;
        private Table table; // la table ou le joueur se trouve


        public Player()
        {
            id = 0;
            name = "";
            score = 0;
            //teamscore = 0;
            status = 0;
            deck = null;
            team = null;
        }

        public int Id
        {
            get
            {
                return (id);
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return (name);
            }
            set
            {
                name = value;
            }
        }
        public int Score
        {
            get
            {
                return (score);
            }
            set
            {
                score = value;
            }
        }
        public int Teamscore
        {
            get
            {
                return (teamscore);
            }
            set
            {
                teamscore = value;
            }
        }
        public int Status
        {
            get
            {
                return (status);
            }
            set
            {
                status = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return (deck);
            }
            set
            {
                deck = value;
            }
        }
        public Team Team
        {
            get
            {
                return (team);
            }
            set
            {
                team = value;
            }
        }
        public NetworkCommsDotNet.Connections.Connection Connection
        {
            get
            {
                return (connection);
            }
            set
            {
                connection = value;
            }
        }
        
    }
}
