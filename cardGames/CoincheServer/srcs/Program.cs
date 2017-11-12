using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetworkCommsDotNet;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet.Connections;
using ProtoBuf;
using CoincheServer.Network;


namespace CoincheServer
{
    class Program
    {
        private static CServer GoConnectServer()
        {
            int port = 0;
            CServer server = null;
            port = Common.IO.InputManager.Client.GetNumber("Please enter server port: ", "Please enter a valid port",
                new Common.IO.InputManager.Client.Between(4040, 50000));
            try
            {
                server = new CServer("127.0.0.1", port);

            }
            catch (ConnectionSetupException ex)
            {
                Console.WriteLine("Can't create the server connection on port: " + port);
                GoConnectServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }
            Console.WriteLine("Server connection enabled, waiting for connections...");
            return (server);
        }

        static void Main(string[] args)
        {
            CServer server = GoConnectServer();
            server.Start();
            Common.IO.InputManager.Standard.WaitQuit();
            server.Stop();
        }
        
    }
}
