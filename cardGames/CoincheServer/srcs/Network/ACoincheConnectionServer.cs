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
        protected ServerInfo serverInfo;
        private NetworkListener nl;
        protected Game.Room.RoomManager room;
        private CServer myserverInstance;
        public ACoincheConnectionServer(string _ip, int _port)
        {
            serverInfo.Ip = _ip;
            serverInfo.Port = _port;
            
        }

        ~ACoincheConnectionServer()
        {
           // Stop();
            Console.WriteLine("Server destroyed");
        }

        public void InitConnection(CServer _son)
        {
            
            nl = new NetworkListener(_son);
            room = new Game.Room.RoomManager(_son);
            nl.Init();
        }

        /// <summary>
        /// Run the server
        /// </summary>
        public void Start()
        {
            Connection.StartListening
                (ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, serverInfo.Port));
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
                return serverInfo.Ip;
            }
            set
            {
                serverInfo.Ip = value;
            }
        }
        public int Port
        {
            get
            {
                return serverInfo.Port;
            }
            set
            {
                serverInfo.Port = value;
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