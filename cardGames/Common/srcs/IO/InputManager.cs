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

            private static string GetSuit(int number)
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
            public static Common.GameUtils.Bet CreateBet()
            {
                Common.GameUtils.Bet bet = new GameUtils.Bet();
                int a;

                Common.IO.OutputManager.Standard.Client.AskBet();
                Console.Write(Common.IO.Messages.Suit.SuitInfo + "? ");
                a = Int32.Parse(Console.ReadLine());
                while (a < 1 || a > 4)
                {
                    Console.WriteLine("Please Enter a number between 1-4");
                    Console.Write(Common.IO.Messages.Suit.SuitInfo + "? ");
                    a = Int32.Parse(Console.ReadLine());
                }
                bet.suit = GetSuit(a);
                Console.WriteLine("Enter number of points you want bet (0-180)");
                a = Int32.Parse(Console.ReadLine());
                while (a < 0 || a > 180)
                {
                    Console.WriteLine("Please Enter a number between 0-80");
                    a = Int32.Parse(Console.ReadLine());
                }
                return (bet);
            }
        }
    }
}
