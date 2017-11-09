using Common.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoincheClient.Network
{
    public class CClient : ACoincheSenderClient
    {
        public CClient(string _ip, int _port) : base(_ip, _port)
        {
            InitSending(this);
            Ping();
        }

        /*
         * Explicit functions
         */
        public void Login()
        {
            string name;

            name = Common.IO.InputManager.Client.CreateLogin();
            clientInfo.name = name;
            SendLoginRequest(clientInfo.name);
            Console.WriteLine("Client sended LoginRequest");
        }

        public void WaitGame()
        {
            SendWaitGameRequest();
        }

        public void Bet(Bet lastbet, List<Card> _cards)
        {
            Console.WriteLine("CClient.Bet()");
            Console.WriteLine("CardCount3=" + _cards.Count + "");
            Console.WriteLine("Your cards in your hand :");
            Task<int> task = new Task<int>(new Func<int>( () => RunDisplayList(_cards)));
            
            //Common.IO.OutputManager.Standard.Display.ListCard(cards);
            //Thread.Sleep(200);
            Task<int> task2 = null;
            if (lastbet.points > 0)
                task2 = new Task<int>(new Func<int>(() => Common.IO.OutputManager.Standard.Display.LastBet(lastbet)));
            Task task3 = new Task<int>(new Func<int>(() => RunBet()));

            task.Start();
            Thread.Sleep(1000);
            if (task2 != null)
            {
                task2.Start();
                Thread.Sleep(200);
            }
            task3.Start();
            Thread.Sleep(200);
        }
        private int RunBet()
        {
            Bet bet = Common.IO.InputManager.Client.CreateBet();
            SendBetAnswer(bet);
            return (0);
        }

        private int RunDisplayList(List<Card> cards)
        {
            int i = 0;
            Console.WriteLine("CardCount4=" + cards.Count + "");
            Card c;
            while (i < cards.Count)
            {
                c = cards.ElementAt(i);
                Console.Write("Card n" + (i + 1));
                Console.Write(" Suit = " + c.suit);
                Console.Write(" Number = " + c.number);
                //Console.Write(" Player = ", c.player.Name);
                Console.WriteLine(" point = ", c.point);
                ++i;
            }
            return (0);
        }
        /* to finish */
        public void PlayCard()
        {
            Common.GameUtils.Card card;
        }
    }
}
