using CoincheServer.Network;
using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Table
{
    public abstract class ATableRootManager
    {
        protected List<Player> player;
        protected Deck deck;
        protected List<Team> team;
        protected Bet bet;
        protected Deck handStack;
        protected bool isReady;
        protected CServer server;

        public ATableRootManager(CServer _server)
        {
            server = _server;
            player = new List<Player>();
            deck = new Deck();
            team = new List<Team>();
            bet = new Bet();
            handStack = new Deck();
        }

        /// <summary>
        /// Check if both teams are full.
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if (team.First().full && team.Last().full)
                return (true);
            return (false);
        }

        /// <summary>
        /// Check a team that is not full yet.
        /// </summary>
        /// <returns></returns>
        public Team FindTeamAvailable()
        {
            foreach (Team elem in team)
            {
                if (!elem.full)
                    return (elem);
            }
            return (null);
        }

        public List<Player> Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        }

        public Deck Deck
        {
            get
            {
                return deck;
            }
            set
            {
                deck = value;
            }
        }

        public List<Team> Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value;
            }
        }

        public Bet Bet
        {
            get
            {
                return bet;
            }
            set
            {
                bet = value;
            }
        }

        public Deck HandStack
        {
            get
            {
                return handStack;
            }
            set
            {
                handStack = value;
            }
        }

        public bool IsReady
        {
            get
            {
                return isReady;
            }
            set
            {
                isReady = value;
            }
        }
    }
}
