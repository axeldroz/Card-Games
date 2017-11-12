using NetworkCommsDotNet;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using CoincheClient.Network;

namespace CoincheClient
{
    class Program
    {
        /*static void Main(string[] args)
        {
            //Request server IP and port number
            Console.WriteLine("Please enter the server IP and port in the format 192.168.0.1:10000 and press return:");
            string serverInfo = Console.ReadLine();

            //Parse the necessary information out of the provided string
            string serverIP = serverInfo.Split(':').First();
            int serverPort = int.Parse(serverInfo.Split(':').Last());

            //Keep a loopcounter
            int loopCounter = 1;
            Test structure = new Test()
            {
                msg = "hello world",
                id = 1
            };
            Test msg = new Test()
            {
                msg = "T'as vu mec !",
                id = 1
            };
            while (true)
            {
                //Write some information to the console window
                string messageToSend = "This is message #" + loopCounter;
                Console.WriteLine("Sending message to server saying '" + messageToSend + "'");

                //Send the message in a single line
                NetworkComms.SendObject<Test>("Message2", serverIP, serverPort, structure);
                NetworkComms.SendObject<Test>("Message", serverIP, serverPort, msg);
                //Check if user wants to go around the loop
                Console.WriteLine("\nPress q to quit or any other key to send another message.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else loopCounter++;
            }
            NetworkComms.Shutdown();
        }*/

        private static CClient GoConnect()
        {
            int port = 0;
            string ip;
            CClient client = null;

            Console.Write("Please enter server IP:");
            ip = Console.ReadLine();
            port = Common.IO.InputManager.Client.GetNumber("Please enter server port: ", "Please enter a valid port",
                new Common.IO.InputManager.Client.Between(4040, 50000));
            try
            {
               client = new CClient(ip, port);
                
            }
            catch (ConnectionSetupException ex)
            {
                Console.WriteLine("Can't reach the following server: " + ip + ":" + port);
                GoConnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }
            return (client);
        }

        static void Main(string[] args)
        {
            CClient client = GoConnect();
            client.Login();
            //Common.IO.InputManager.Standard.WaitQuit();
            while (true) ;
            }
        }
    }
