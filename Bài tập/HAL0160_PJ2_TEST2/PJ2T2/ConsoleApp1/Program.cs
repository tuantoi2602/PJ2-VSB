using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJ2T2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user0 = new User("Martin/Halfar");
            User user1 = new User("Nitram", "Raflah");
            User user2 = new User("Martin/Raflah");
            
            Card card0 = new Card("00000000", user0);
            Card card1 = new Card("99999999", user1);
            Card card2 = new Card("11111111", user2);

            try {
                User user3 = new User("ADWDA", "");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            DoorSystem system = new DoorSystem();
            system.Rules.Add(new AccessControl(card0, 100));
            system.Rules.Add(new AccessControl(card0, 101));
            system.Rules.Add(new AccessControl(card1, 100));
            system.Rules.Add(new AccessControl(card2, 101));

            Action<Card, Int32> tryWrapper = (card, roomId) => {
                try {
                    system.CheckCard(card, roomId);
                } catch (PJ2T2.AccessViolationException) {
                    Console.WriteLine("Ayy lmao");
                }
            };

            tryWrapper(card0, 100);
            tryWrapper(card0, 101);
            tryWrapper(card1, 100);
            tryWrapper(card1, 101);
            tryWrapper(card2, 100);
            tryWrapper(card2, 101);

            system.Statistics();

            Console.Read();
        }
    }
}
