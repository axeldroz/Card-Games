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
    public struct Card
    {
        [ProtoMember(1)]
        public string suit; // couleur
        [ProtoMember(2)]
        public string number;
        [ProtoMember(3)]
        public Player player; // player qui joue la carte
        [ProtoMember(4)]
        public int point; // point que vaut la carte
        [ProtoMember(5)]
        public int pointA; // point que vaut la carte
        [ProtoMember(6)]
        public int power; // valeur de la carte
        [ProtoMember(7)]
        public int powerA; // valeur de la carte avec atout
    }
}
