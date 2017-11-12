using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IO
{
    public static class OutputManager
    {
        public static class Standard
        {
            public static class Client
            {
                public static void AskLogin()
                {
                    Console.WriteLine("Your login");
                }
                public static void AskBet()
                {
                    Console.WriteLine("Creating of bet : ");
                }
            }

            /* Afficher composant de jeu */
            public class Display
            {
                public static void Bet(Common.GameUtils.Bet bet)
                {
                    Console.WriteLine("Bet : ");
                    Console.WriteLine("Suit = " + bet.suit);
                    Console.WriteLine("Points = " + bet.points);
                }
                public static int LastBet(Common.GameUtils.Bet bet)
                {
                    Console.WriteLine("Last Bet : ");
                    Console.WriteLine("Suit = " + bet.suit);
                    Console.WriteLine("Points = " + bet.points);
                    Console.WriteLine("Player = " + bet.player.Name);
                    return (0);
                }
                public static int LastBet2(Common.GameUtils.Bet bet)
                {
                    Console.Write("Last Bet : ");
                    Console.WriteLine(bet.player.Name + " has bet " + bet.points
                        + " on " + bet.suit);

                    return (0);
                }
                public static void Card(GameUtils.Card c, int i)
                {
                    Console.WriteLine("Card n" + i);
                    Console.WriteLine("Suit = " + c.suit);
                    Console.WriteLine("Number = " + c.number);
                    Console.WriteLine("Player = ", c.player.Name);
                    Console.WriteLine("point = ", c.point);
                }

                public static int ListCard(List<GameUtils.Card> l)
                {
                    int i = 0;
                    Console.WriteLine("CardCount4=" + l.Count + "");
                    GameUtils.Card c;
                    while (i < l.Count)
                    {
                        c = l.ElementAt(i);
                        Console.WriteLine("Card n" + i);
                        Console.WriteLine("Suit = " + c.suit);
                        Console.WriteLine("Number = " + c.number);
                        Console.WriteLine("Player = ", c.player.Name);
                        Console.WriteLine("point = ", c.point);
                        ++i;
                    }
                    return (0);
                }
            }
            public static class Server
            {

            }
        }
        public static class Debug
        {
            public static void Display(string msg)
            {
                Console.WriteLine(msg);
            }
            public static void Display(string key, string msg)
            {
                Console.WriteLine("<" + key + "> " + msg);
            }
            public static void DisplayVar(string name, string value)
            {
                Console.WriteLine("VAR : " + name + "=" + value);
            }
            public static void DisplayVar(string name, bool value)
            {
                Console.WriteLine("VAR : " + name + "=>" + value);
            }
        }

        public static class Error
        {

        }
    }
}
