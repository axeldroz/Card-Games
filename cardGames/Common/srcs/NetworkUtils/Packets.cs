using Common.GameUtils;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.NetworkUtils
{
    namespace Packets
    {
        /// <summary>
        /// Packet00Message : String message
        /// </summary>
        [ProtoContract]
        public class Packet00Message
        {
            [ProtoMember(1)]
            public string message;
        };

        /// <summary>
        /// Packet01LoginRequest : String name
        /// </summary>
        [ProtoContract]
        public class Packet01LoginRequest
        {
            [ProtoMember(1)]
            public string name;
        }

        /// <summary>
        /// Packet02LoginAnswer : bool accepted
        /// </summary>
        [ProtoContract]
        public class Packet02LoginAnswer
        {
            [ProtoMember(1)]
            public bool accepted;
        }

        /// <summary>
        /// Packet03WaitGameRequest : Nothing
        /// </summary>
        [ProtoContract]
        public class Packet03WaitGameRequest
        {
            
        }

        /// <summary>
        /// Packet04WaitGameAnswer : bool accepted
        /// </summary>
        [ProtoContract]
        public class Packet04WaitGameAnswer
        {
            [ProtoMember(1)]
            public bool accepted;   
        }

        /// <summary>
        /// Packet05BetRequest : string descr, string type, Bet last_bet
        /// </summary>
        [ProtoContract]
        public class Packet05Bet
        {
            [ProtoMember(1)]
            public string descr;
            [ProtoMember(2)]
            public Bet bet;
        }

        [ProtoContract]
        public class Packet06Card
        {
            [ProtoMember(1)]
            public string descr;
            [ProtoMember(2)]
            public Card card;
        }

        [ProtoContract]
        public class Packet07Deck
        {
            [ProtoMember(1)]
            public string descr;
            [ProtoMember(2)]
            public Deck deck;
        }



    }
}
