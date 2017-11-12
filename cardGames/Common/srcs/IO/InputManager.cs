using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IO
{
    public static class InputManager
    {
        public static class Client
        {
            public static string CreateLogin()
            {
                string name;

                Common.IO.OutputManager.Standard.Client.AskLogin();
                name = Console.ReadLine();
                return (name);
            }

            public static string GetSuit(int number)
            {
                string str;

                switch (number)
                {
                    case 1:
                        str = IO.Messages.Suit.Diamond.Item2;
                        break;
                    case 2:
                        str = IO.Messages.Suit.Club.Item2;
                        break;
                    case 3:
                        str = IO.Messages.Suit.Heart.Item2;
                        break;
                    case 4:
                        str = IO.Messages.Suit.Spade.Item2;
                        break;
                    default:
                        str = "error";
                        break;
                }
                return (str);
            }

            public struct Between
            {
                public int min;
                public int max;

                public Between(int a, int b)
                {
                    min = a;
                    max = b;
                }
            };

            public static int GetNumber(string msg1, string msg2, 
                Between s, bool again = false)
            {
                int a;

                a = -1;
                try
                {
                    if (msg1 != null)
                        Console.Write(msg1);
                    if (msg2 != null && again)
                        Console.WriteLine(msg2);
                    a = Int32.Parse(Console.ReadLine());
                    if (!(a >= s.min && a <= s.max))
                        a = GetNumber(msg1, msg2, s, true);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Problem format ...");
                    a = GetNumber(msg1, msg2, s, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception e" + e.ToString());
                }
                return (a);
            }
            public static Common.GameUtils.Bet CreateBet()
            {
                Common.GameUtils.Bet bet = new GameUtils.Bet();
                Between bPoints = new Between(0, 180);

                Common.IO.OutputManager.Standard.Client.AskBet();
                //Console.Write(Common.IO.Messages.Suit.SuitInfo + "? ");
                bet.suit = GetSuit(GetNumber(Common.IO.Messages.Suit.SuitInfo + "? ",
                    "Please enter a number between 1-4", new Between(1, 4)));
                bet.points = GetNumber("Enter number of points you want bet ("
                    + bPoints.min + "-" + bPoints.max + ") ?", "", 
                    bPoints);
                bet.player = null;
                bet.team = null;
                bet.coinched = false;
                bet.surcoinched = false;
                bet.id = 0;
                return (bet);
            }
        }

        public static class Standard
        {
            public static void WaitQuit()
            {
                Console.WriteLine("Press a key to quit ...");
                Console.ReadKey();
            }
            public static void WaitKey()
            {
                Console.WriteLine("Press a key To continue ...");
                Console.ReadKey();
            }
            public static void WaitKey(string cmd)
            {
                Console.WriteLine("Press a key to" + cmd + "...");
                Console.ReadKey();
            }
        }
    }
}
