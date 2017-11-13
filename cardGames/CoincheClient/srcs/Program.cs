/*
 * Created by Axel Drozdzynski and Simon Brami on 11/06/2017
 */ 
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
                //Console.WriteLine("Exception : " + ex.ToString());
                GoConnect();
            }
            return (client);
        }

        static void Main(string[] args)
        {
            CClient client = GoConnect();
            //client.Login();
            while (true) ;
            }
        }
    }
