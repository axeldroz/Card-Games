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

        /// <summary>
        /// Check wich team Won the plit and distribute point to players and Teams.
        /// </summary>
        /*public Player WhoWonRound()
        {
            int ScoreTeamRed = 0;
            int ScoreTeamBlue = 0;
            Player SaveBest = null;
            int lastCard = 0;

            try
            {
                if (cards.Count == 8 && !Asset.Equals(null))
                {
                    // Check all cards of the plit.
                    foreach (var elem in cards)
                    {
                        // Check if the card is the Asset of the plit.
                        if (elem.suit == Asset.suit && elem.number == Asset.number)
                        {
                            elem.player.Score += elem.pointA;
                            elem.player.Team.Score += elem.pointA;
                            ScoreTeamRed += elem.player.Team.Name == "Red" ? elem.pointA : 0;
                            ScoreTeamBlue += elem.player.Team.Name == "Blue" ? elem.pointA : 0;
                            if (lastCard < elem.pointA)
                            {
                                SaveBest = elem.player;
                                lastCard = elem.pointA;
                            }
                        }
                        else // Else the card is not an asset so it takes usual points.
                        {
                            elem.player.Score += elem.point;
                            elem.player.Team.Score += elem.point;
                            ScoreTeamRed += elem.player.Team.Name == "Red" ? elem.point : 0;
                            ScoreTeamBlue += elem.player.Team.Name == "Blue" ? elem.point : 0;
                            if (lastCard < elem.point)
                            {
                                SaveBest = elem.player;
                                lastCard = elem.point;
                            }

                        }
                    }
                    IO.OutputManager.Debug.Display((ScoreTeamRed > ScoreTeamBlue) ? "Red Team Won the plis" : "Blue Team Won the plis");
                    // Put action to do after end of plit. ClearTable() for example ?
                    return SaveBest;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }*/

        /// <summary>
        /// Check who won the Bet and give points to the winner and his team.
        /// </summary>
       /* public Player WhoWonBet()
        {
            Player save = null;
            try
            {
                foreach (var elem in cards)
                {
                    if (elem.suit == Asset.suit && elem.number == Asset.number)
                    {
                        // Je donne au joueur et à son équipe le nombre de point que pèse le Bet (JE SUIS PAS SUR DE LA REGLE à VERIFIER)
                        save = elem.player;
                        elem.player.Score += CurrentBet.points;
                        elem.player.Team.Score += CurrentBet.points;
                        IO.OutputManager.Debug.Display("Player " + elem.player.Name + " of Team " + elem.player.Team.Name + " won the bet of " + CurrentBet.points + " points !!");
                        return save;
                    }
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }

        }*/


    }
}