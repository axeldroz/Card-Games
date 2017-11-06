using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    [ProtoContract]
    public struct Test
    {
        [ProtoMember(1)]
        public string msg;
        [ProtoMember(2)]
        public int id;
    }
}
