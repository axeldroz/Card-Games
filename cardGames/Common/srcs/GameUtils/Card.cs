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
    }
}
