using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Concert c1 = new Concert() { Name = "Kansas", Rating = 1, Genre = "Rock", Location = "Bourbon Street", TicketsLeft = 200 };
            Concert c2 = new Concert() { Name = "Florida", Rating = 2, Genre = "Rap", Location = "Miami", TicketsLeft = 0 };
            Concert c3 = new Concert() { Name = "Oasis", Rating = 3, Genre = "Alternative", Location = "California", TicketsLeft = 1 };

            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(c3.ToString());

            //Console.ReadLine();

            ConcertService cs = new ConcertService();

            var newShows = cs.Upcoming();

            cs.AddConcert(c1);
            cs.AddConcert(c2);
            cs.AddConcert(c3);

            var t1 = cs.PurchaseTicket("Kansas");
            var t2 = cs.PurchaseTicket("Oasis");
            var t3 = cs.PurchaseTicket("Florida");
        }
    }

    public class Concert
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
        public int TicketsLeft { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return String.Format("Name : " + this.Name +
                "\nRating: " + this.Rating.ToString() +
                "\nGenre: " + this.Genre +
                "\nTickets Left: " + this.TicketsLeft.ToString() +
                "\nLocation: " + this.Location);
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Concert, then return false.
            Concert c = obj as Concert;
            if ((System.Object)c == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ToString() == c.ToString());
        }

        // overriden to remove compiler warning
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class ConcertService
    {
        private List<Concert> Concerts { get; set; }

        public ConcertService()
        {
            if (Concerts == null)
            {
                Concerts = new List<Concert>();
            }
        }

        public IEnumerable<IGrouping<string, Concert>> Upcoming()
        {
            if (Concerts != null)
            {
                IEnumerable<IGrouping<string, Concert>> results = Concerts.GroupBy(n => n.Genre);
                return results;
            }
            return null;
        }

        public bool AddConcert(Concert a = null)
        {
            if (a != null)
            {
                Concerts.Add(a);
                return true;
            }

            return false;
        }

        public bool PurchaseTicket(string name = null)
        {
            if (name == null)
            {
                return false;
            }

            IEnumerable<Concert> result = Concerts.Where(n => n.Name == name);
            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    if (item.TicketsLeft > 0)
                    {
                        item.TicketsLeft--;
                        return true;
                    }
                    else
                    {
                        throw new Exception("No More Tickets Left buddy...");
                    }
                }
            }

            return false;
        }
    }
}
