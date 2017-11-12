using Common.NetworkUtils;
using Common.NetworkUtils.Packets;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer.Network
{
    public abstract class ACoincheConnectionServer
    {
        protected ServerInfo ServerInfo;
        private NetworkListener Nl;
        protected Game.Room.RoomManager room;

        public ACoincheConnectionServer(string _ip, int _port)
        {
            ServerInfo.Ip = _ip;
            ServerInfo.Port = _port;
            
        }

        ~ACoincheConnectionServer()
        {
           // Stop();
            Console.WriteLine("Server destroyed");
        }

        public void InitConnection(CServer _son)
        {
            
            Nl = new NetworkListener(_son);
            room = new Game.Room.RoomManager(_son);
            Nl.Init();
        }

        /// <summary>
        /// Run the server
        /// </summary>
        public void Start()
        {
            Connection.StartListening
                (ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, ServerInfo.Port));
        }
        /// <summary>
        /// Stop the server
        /// </summary>
        public void Stop()
        {
            NetworkComms.Shutdown();
        }

        /*
         * Getters & Setters
         */
        public string Ip
        {
            get
            {
                return ServerInfo.Ip;
            }
            set
            {
                ServerInfo.Ip = value;
            }
        }
        public int Port
        {
            get
            {
                return ServerInfo.Port;
            }
            set
            {
                ServerInfo.Port = value;
            }
        }
        public Game.Room.RoomManager Room
        {
            get
            {
                return (room);
            }
        }
    }
}