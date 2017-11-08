using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GameUtils
{
    [ProtoContract]
    public class Team
    {
        [ProtoMember(1)]
        private int id;
        [ProtoMember(2)]
        private string name;
        [ProtoMember(3)]
        private List<Player> player;
        [ProtoMember(4)]
        private int score;
        [ProtoMember(5)]
        public bool full;

        public Team()
        {
            id = 0;
            name = "";
            player = new List<Player>();
            score = 0;
            full = false;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<Player> Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public bool Full
        {
            get
            {
                return full;
            }
            set
            {
                full = value;
            }
        }

    }
}
