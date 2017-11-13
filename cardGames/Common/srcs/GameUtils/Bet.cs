/*
 * Created by Axel Drozdzynski and Simon Brami on 11/06/2017
 */
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    [ProtoContract]
    public struct Bet
    {
        [ProtoMember(1)]
        public string suit; // couleur
        [ProtoMember(2)]
        public int points; // point que l'on veut parier
        [ProtoMember(3)]
        public Player player; // player qui parie
        [ProtoMember(4)]
        public Team team; // team qui parie
        [ProtoMember(5)]
        public bool coinched;
        [ProtoMember(6)]
        public bool surcoinched;
        [ProtoMember(7)]
        public int id;
    }
}