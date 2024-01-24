using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ2T2
{
    /* 1. 
     Vytvořte třídu Card, která bude reprezentovat přístupovou kartu k hotelovému pokoji.
     Třída bude obsahovat konstruktor s jediným parametrem, kterým bude řetězec 
     v následujícím formátu: cislokarty-Jmeno/Prijmeni (příklad 151515-Radim/Kuncicky)
     Číslo karty je typu int.   */


    public class Card //třída Card
    {
        public Int32 CardId { get; private set; } //tímto nastavujeme práva na čtení a zápis proměnné?
        public User User { get; private set; }
        //Něco na způsob cizího klíče v SQL? Ve smyslu at můžeme přidělit kartu userovi
        //

        public Card(String cardId, User user) 
       //konstruktor - proč jsou tam dva parametry, jestliže zadání říká jediný parametr? 
       //Je to kvůli tomu, protože se dva parametry spojí v jeden?
       //To, zda je řetězec utvořen správně, se kontroluje ve třídě User?!
        {
            try {
                CardId = Int32.Parse(cardId);
                if (user == null) {
                    throw new ArgumentNullException("User cannot be null"); //zkouška, zda se nepokoušíme přidělit kartě prázdného neboli žádného uživatele?
                } else {
                    User = user;
                }
            } catch (Exception e) {
                throw new ArgumentException("Bad format", e);
            }
        }
    }

    public class User
    {
        public String FirstName { get; private set; }
        public String LastName { get; private set; }

        public User(String name)
        {
            try {
                String[] tokens = name.Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries); // split jmena na 2 casti podle /
                FirstName = tokens[0];
                LastName = tokens[1];
            } catch (Exception e) {
                throw new ArgumentException("Bad format", e);
            }
        }

        public User(String firstName, String lastName)
        {
            if (firstName == null || lastName == null || firstName.Length < 1 || lastName.Length < 1) {
                throw new ArgumentException("Bad format");
            }

            FirstName = firstName;
            LastName = lastName;
        }
    }

    public enum Access
    {
        PASS, FAIL
    }

    public class AccessControl
    {
        public Int32 CardId { get; private set; }
        public Int32 PassCount { get; private set; } = 0;
        public Int32 RoomId { get; private set; }

        public AccessControl(Card card, Int32 roomId)
        {
            CardId = card.CardId;
            RoomId = roomId;
        }

        public Access PassRule(Card card, Int32 roomId)
        {
            Access res = (CardId == card.CardId && RoomId == roomId) ? Access.PASS : Access.FAIL;
            if (res == Access.PASS) {
                PassCount++;
            }

            return res;
        }
    }

    public class AccessViolationException : ApplicationException
    {
        public Card Card { get; private set; }

        public AccessViolationException(Card card) : base() => Card = card;
    }

    public class Logger
    {
        public void Log(String name, String roomId)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"doorsystemlog.txt", true)) {
                file.WriteLine(String.Format("{0,-10}{1}", roomId, name));
            }
        }
    }

    public class DoorSystem
    {
        public delegate void LoggerMethod(String name, String roomId);

        public LoggerMethod Log { get; private set; } = new Logger().Log;
        public List<AccessControl> Rules = new List<AccessControl>();

        public void CheckCard(Card card, Int32 roomId)
        {
            AccessControl ac = Rules.Find(rule => rule.PassRule(card, roomId) == Access.PASS);
            if (ac == null) {
                 throw new AccessViolationException(card);
            } else {
                Log.Invoke(String.Format("{0}{1}", card.User.FirstName, card.User.LastName), roomId.ToString());
            }
        }

        public void Statistics()
        {
            Console.WriteLine("Door System Statistics");
            for (Int32 itr = 0; itr < Rules.Count; itr++) {
                Console.WriteLine(String.Format("Rule number: {0,-5}, CardId: {1,-10}, Room: {2,-5}, PASS: {3,-5}", itr, Rules[itr].CardId, Rules[itr].RoomId, Rules[itr].PassCount));
            }
        }
    }
}
