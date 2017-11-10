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
        public Card Asset { get; set; }
        [ProtoMember(2)]
        public Bet CurrentBet { get; set; }

        /// <summary>
        /// Initialize new round, it's highly recommanded to set Asset and CurrentBet Values;
        /// </summary>
        public Round() : base()
        {
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
                    IO.OutputManager.Debug.Display("/!\\ Cards reset for new round/plit.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check wich team Won the plit and distribute point to players and Teams.
        /// </summary>
        public void WhoWonRound()
        {
            if (cards.Count == 8 && !Asset.Equals(null))
            {
                int ScoreTeamRed = 0;
                int ScoreTeamBlue = 0;

                try
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
                        }
                        else // Else the card is not an asset so it takes usual points.
                        {
                            elem.player.Score += elem.point;
                            elem.player.Team.Score += elem.point;
                            ScoreTeamRed += elem.player.Team.Name == "Red" ? elem.point : 0;
                            ScoreTeamBlue += elem.player.Team.Name == "Blue" ? elem.point : 0;
                        }
                    }
                }
                catch (ArgumentNullException ex)
                {
                    throw ex;
                }
                IO.OutputManager.Debug.Display((ScoreTeamRed > ScoreTeamBlue) ? "Red Team Won the plit" : "Blue Team Won the plit");
                // Put action to do after end of plit. ClearTable() for example ?
            }
        }

        /// <summary>
        /// Check who won the Bet and give points to the winner and his team.
        /// </summary>
        public void WhoWonBet()
        {
            try
            {
                foreach (var elem in cards)
                {
                    if (elem.suit == Asset.suit && elem.number == Asset.number)
                    {
                        // Je donne au joueur et à son équipe le nombre de point que pèse le Bet (JE SUIS PAS SUR DE LA REGLE à VERIFIER)
                        elem.player.Score += CurrentBet.points;
                        elem.player.Team.Score += CurrentBet.points;
                        IO.OutputManager.Debug.Display("Player " + elem.player.Name + " of Team " + elem.player.Team.Name + " won the bet of " + CurrentBet.points + " points !!");
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }

        }


    }
}