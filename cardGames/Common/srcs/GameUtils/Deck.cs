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
        public List<Card> cards { get; set; }
        //public Card Cards { get; private set; }

        //private string[] suit = {}
        public Deck()
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// Add all cards in deck
        /// </summary>
        public void init()
        {
            /*Card card = new Card();
            card.suit = "Diamonds";
            card.number = "Ace";
            card.point = 20;
            card.player = null;*/

            //Card card = CreateCard()
            //cards.Add(card);
        }

        public void Generate()
        {
            int sui = 1;
            int i = 0;
            int num = 0;

            while (sui <= 4)
            {
                while (num <= 8)
                {
                    cards.Insert(i, CreateCard(num, Common.IO.InputManager.Client.GetSuit(sui)));
                    ++i;
                    ++num;
                }
                num = 0;
                ++sui;
            }
            Console.WriteLine("Number Of Cards : " + cards.Count);
        }

        public Card CreateCard(int num, string suit)
        {
            Card c = new Card();
            switch (num)
            {
                case 1:
                    c.number = "Ace";
                    c.point = 7;
                    c.pointA = 19;
                    break;
                case 2:
                    c.number = "7";
                    c.point = 0;
                    c.pointA = 0;
                    break;
                case 3:
                    c.number = "8";
                    c.point = 0;
                    c.pointA = 0;
                    break;
                case 4:
                    c.number = "9";
                    c.point = 9;
                    c.pointA = 0;
                    break;
                case 5:
                    c.number = "10";
                    c.point = 5;
                    c.pointA = 10;
                    break;
                case 6:
                    c.number = "Jack";
                    c.point = 2;
                    c.pointA = 14;
                    break;
                case 7:
                    c.number = "Qween";
                    c.point = 2;
                    c.pointA = 3;
                    break;
                case 8:
                    c.number = "King";
                    c.point = 3;
                    c.pointA = 4;
                    break;
            }
            return (c);
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
        public Card TakeCard()
        {
            if (cards.Count < 1)
                return (new Card());
            Card c = cards.ElementAt(0);
            cards.RemoveAt(0);
            return (c);
        }

        public void Distrib(List<Team> teams)
        {
            foreach (Team t in teams)
            {
                int i = 0;
                while (i < 8)
                {
                    t.Player.First().Deck.cards.Add(TakeCard());
                    t.Player.Last().Deck.cards.Add(TakeCard());
                    ++i;
                }
            }
        }
    }
}
