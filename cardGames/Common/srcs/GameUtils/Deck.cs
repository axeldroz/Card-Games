using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    [ProtoContract]
    public class Deck
    {
        [ProtoMember(1)]
        private List<Card> cards { get; set; }
        public Deck()
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// Add all cards in deck
        /// </summary>
        public void init()
        {
            Card card;
            card.suit = "Diamonds";
            card.number = "Ace";
            card.point = 20;
            card.player = null;

            cards.Add(card);
        }

        /// <summary>
        /// Mix the deck
        /// </summary>
        public void mix()
        {
            /* we need a algo to mix cards */
        }

        /// <summary>
        /// Take a card in the deck to give to a player for example
        /// </summary>
        /// <returns></returns>
        public Card takeCard()
        {
            return (cards.ElementAt(0));
        }
    }
}
