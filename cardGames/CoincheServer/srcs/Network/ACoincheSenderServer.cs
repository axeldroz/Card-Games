﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.NetworkServer
{
    public abstract class ACoincheSenderServer : ACoincheConnectionServer
    {
        public ACoincheSenderServer(string _ip, int _port) : base(_ip, _port)
        {

        }
    }
}