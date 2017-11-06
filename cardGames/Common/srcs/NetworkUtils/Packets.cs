using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtils
{
    namespace Packets
    {
        /// <summary>
        /// Packet00Message : String message
        /// </summary>
        public struct Packet00Message
        {
            string message;
        };

        /// <summary>
        /// Packet01LoginRequest : String name
        /// </summary>
        public struct Packet01LoginRequest
        {
            string name;
        }

        /// <summary>
        /// Packet02LoginAnswer : bool accepted
        /// </summary>
        public struct Packet02LoginAnswer
        {
            bool accepted;
        }

        /// <summary>
        /// Packet03WaitGameRequest : Nothing
        /// </summary>
        public struct Packet03WaitGameRequest
        {
            
        }

        /// <summary>
        /// Packet04WaitGameAnswer : bool accepted
        /// </summary>
        public struct Packet04WaitGameAnswer
        {
            bool accepted;   
        }

        /// <summary>
        /// Packet05BetRequest : string descr, string type, Bet last_bet
        /// </summary>
        public struct Packet05BetRequest
        {
            string descr;
            string type;
            //Bet last_bet;
        }

        /// <summary>
        ///  Packet06BetAnswer : string type, Bet newbet
        /// </summary>
        public struct Packet06BetAnswer
        {
            string type;
            //Bet newbet
        }

    }
}
