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
        //public Deck DeckRound { get; set; } //deck où l'on pose nos carte pour jouer
        public Round RoundDeck { get; set; }
        protected List<Team> team;
        protected Bet bet;
        protected Deck handStack;
        protected bool isReady;
        protected CServer server;
        protected int tourBet;
        protected int tourPlayingCard;
        protected bool betHasraised;

        public ATableRootManager(CServer _server)
        {
            server = _server;
            player = new List<Player>();
            deck = new Deck();
            team = new List<Team>();
            team.Add(new Team {Name = "Red"});
            team.Add(new Team {Name = "Blue"});
            handStack = new Deck();
            RoundDeck = new Round(team);
            bet = new Bet
            {
                points = 0,
                suit = "diamond"
            };
            tourBet = 0;
            tourPlayingCard = 0;
            betHasraised = false;
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

        public Player NextPlayer(Player player)
        {
            if (player == Team.First().Player.First())
                return (Team.Last().Player.First());
            if (player == Team.Last().Player.First())
                return (Team.First().Player.Last());
            if (player == Team.First().Player.Last())
                return (Team.Last().Player.Last());
            return (Team.First().Player.First());
        }

        public Player NextPlayerBet(Player player)
        {
            if (tourBet < 3 || !betHasraised || bet.points < 80)
            {
                ++tourBet;
                if (player == Team.First().Player.First())
                    return (Team.Last().Player.First());
                if (player == Team.Last().Player.First())
                    return (Team.First().Player.Last());
                if (player == Team.First().Player.Last())
                    return (Team.Last().Player.Last());
                if (player == Team.Last().Player.Last())
                    return (Team.First().Player.First());

            }
            return (null);
        }

        public Player NextPlayerPlayingCard(Player player)
        {
            if (tourPlayingCard < 3 || !betHasraised || bet.points < 80)
            {
                ++tourPlayingCard;
                if (player == Team.First().Player.First())
                    return (Team.Last().Player.First());
                if (player == Team.Last().Player.First())
                    return (Team.First().Player.Last());
                if (player == Team.First().Player.Last())
                    return (Team.Last().Player.Last());
                if (player == Team.Last().Player.Last())
                    return (Team.First().Player.First());

            }
            return (null);
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
