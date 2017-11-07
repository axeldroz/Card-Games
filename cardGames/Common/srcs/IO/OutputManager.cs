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
            public static class Server
            {

            }
        }
        public static class Debug
        {

        }

        public static class Error
        {

        }
    }
}
