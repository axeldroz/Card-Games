using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManagerServer
    {
        protected List<Player> player;
        protected Deck deck;
        protected List<Team> team;
        protected Bet bet;
        protected Deck handStack;
        protected bool isReady;
        protected CoincheServer.Network.CServer server;

        public GameManagerServer()
        {
            player = new List<Player>();
            deck = new Deck();
            team = new List<Team>();
            bet = new Bet();
            handStack = new Deck();
        }

        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        public Deck Deck
        {
            get { return deck; }
            set { deck = value; }
        }

        public List<Team> Team
        {
            get { return team; }
            set { team = value; }
        }

        public Bet Bet
        {
            get { return bet; }
            set { bet = value; }
        }

        public Deck HandStack
        {
            get { return handStack; }
            set { handStack = value; }
        }

        public bool IsReady
        {
            get { return isReady; }
            set { isReady = value; }
        }

        public Player getPlayer(Player p)
        {
            foreach (Player elem in player)
            {
                if (elem.Id == p.Id)
                    return (elem);
            }
            return (null);
        }

        public void startHand()
        {
            Console.WriteLine("Game Starts!");
        }
    }
}
