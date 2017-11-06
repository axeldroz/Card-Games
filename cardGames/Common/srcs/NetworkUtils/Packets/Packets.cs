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
            String message;
        };

        /// <summary>
        /// Packet01LoginRequest : String name
        /// </summary>
        public struct Packet01LoginRequest
        {
            String name;
        }


    }
}
