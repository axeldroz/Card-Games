using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IO
{
    public static class Messages
    {
        public static string Success = "Success!";
        public static string Error = "Error!";

        public static class Suit
        {
            public static Tuple<int, string> Diamond = new Tuple<int, string>(1, "diamond");
            public static Tuple<int, string> Club = new Tuple<int, string>(2, "club");
            public static Tuple<int, string> Heart = new Tuple<int, string>(3, "heart");
            public static Tuple<int, string> Spade = new Tuple<int, string>(4, "spade");
            public static string SuitInfo = "suit (1:diamond; 2:club, 3:heart, 4:spade)";
        }

        public static class Server
        {
            public static string BetRequest = "You have to bet";
        }
    }
}
