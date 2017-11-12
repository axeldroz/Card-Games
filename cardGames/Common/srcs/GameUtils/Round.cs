using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.GameUtils
{
    [ProtoContract]
    public class Round : Deck
    {
        [ProtoMember(1)]
        public string Asset { get; set; }
        [ProtoMember(2)]
        public Bet CurrentBet { get; set; }
        [ProtoMember(3)]
        public List<Team> Teams { get; set; }

        /// <summary>
        /// Initialize new round, it's highly recommanded to set Asset and CurrentBet Values;
        /// </summary>
        public Round(List<Team> t) : base()
        {
            Teams = t;
        }

        /// <summary>
        /// Add a card on the Hand.
        /// </summary>
        /// <param name="ToPlay"></param>
        public void AddCard(Card ToPlay)
        {
            try
            {
                if (!ToPlay.Equals(null))
                {
                    cards.Add(ToPlay);
                    IO.OutputManager.Debug.Display("Player " + ToPlay.player.Name + " played " + ToPlay.number + " of " + ToPlay.suit + "...");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clear the actual 'hand' for a new round/plit.
        /// </summary>
        public void ClearTable()
        {
            try
            {
                if (cards.Count > 0)
                {
                    cards.RemoveRange(0, cards.Count);
                    IO.OutputManager.Debug.Display("/!\\ Cards reset for new round/plis.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Player WhoWonRound()
        {
            Card bestCard = new Card();
            int lastPower = 0;

            if (cards == null || cards.Count < 4)
                return (null);
            foreach (Card ca in cards)
            {
                if (ca.suit == Asset)
                {
                    if (ca.powerA > lastPower)
                    {
                        lastPower = ca.powerA;
                        bestCard = ca;
                    }
                }
                else
                {
                     if (ca.power > lastPower)
                     {
                          lastPower = ca.power;
                          bestCard = ca;
                     }
                }
            }
            return (bestCard.player);
        }

        public Player AddPointToTeams()
        {
            Player winner = WhoWonRound();
            int totalPoints = 0;

            foreach(Card ca in cards)
            {
                if (ca.suit == Asset)
                    totalPoints += ca.pointA;
                else
                    totalPoints += ca.point;
            }
            foreach (Player p in Teams.First().Player)
            {
                if (winner == p)
                {
                    Teams.First().Score += totalPoints;
                    return (winner);
                }
                    
            }
            foreach (Player p in Teams.Last().Player)
            {
                if (winner == p)
                {
                    Teams.Last().Score += totalPoints;
                    return (winner);
                }

            }
            return (winner);
        }
    }
}