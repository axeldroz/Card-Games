using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    [ProtoContract]
    public class Player
    {
        /* gérer par CServer */
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int Status { get; set; } // 0 = afk, 1 = ready for a game
        public NetworkCommsDotNet.Connections.Connection Connection { get; set; }
        [ProtoMember(4)]
        public bool HasPlay { get; set; }
        [ProtoMember(5)]
        public bool HasBet { get; set; }
        /* gérer par TableManager */
        [ProtoMember(6)]
        public int Score { get; set; }
        //public int teamscore;
        [ProtoMember(7)]
        public Deck Deck { get; set; }
        [ProtoMember(8)]
        public Team Team { get; set; }
        [ProtoMember(9)]
        public Table Table { get; set; } // la table ou le joueur se trouve


        public Player()
        {
            Id = 0;
            Name = "";
            Score = 0;
            //teamscore = 0;
            Status = 0;
            Deck = null;
            Team = null;
        }
    }
}
