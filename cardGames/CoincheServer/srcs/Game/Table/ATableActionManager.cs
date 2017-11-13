/*
 * Created by Axel Drozdzynski and Simon Brami on 11/06/2017
 */
using CoincheServer.Network;
using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Game.Table
{
    public abstract class ATableActionManager : ATableEventManager
    {
        public ATableActionManager(CServer _server) : base(_server)
        {

        }

        public void DoAddPlayer(Player player)
        {
            Team tmp = FindTeamAvailable();
            if (tmp != null) // Check if the team is not full.
            {
                tmp.Player.Add(player);
                //player.Team = tmp;
                Console.WriteLine("Player " + player.Name + " has join the team " + tmp.Name + "!");
                if (tmp.Player.Count == 2)
                {
                    tmp.Full = true; // the team is full.
                }
                EventPlayerAdded(player, tmp);
            }
            else
            {
                throw new Exception("Error: Couldn't add new player, teams are full or null");
            }
        }

        public void DoAddBet(Bet newBet)
        {
            if (newBet.points > bet.points && newBet.points >= 80)
            {
                bet = newBet;
                betHasraised = true;
            }
            EventBetAdded(newBet.player, bet);
        }

        public void DoAddCard(Player player, int idCard)
        {
            Card c = player.Deck.cards.ElementAt(idCard);
            c.player = player;
            RoundDeck.AddCard(c);
            player.Deck.cards.RemoveAt(idCard);
            EventCardAdded(player);
        }
    }
}
