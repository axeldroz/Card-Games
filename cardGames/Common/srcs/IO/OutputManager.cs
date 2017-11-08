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
                    Console.Write("Bet : ");
                    Console.Write("Suit = " + bet.suit);
                    Console.Write("Points = " + bet.points);


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
