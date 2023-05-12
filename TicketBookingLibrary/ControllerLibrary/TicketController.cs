using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;

namespace ControllerLibrary
{
    public class TicketController
    {
        //Dictionary<string, int> freeTickets = new Dictionary<string, int>();
        public List<Ticket> tickets = new List<Ticket>();
        public List<Category> categories = new List<Category>();

        public Dictionary<string, int> GetCountOfFreeTickets(Event ev)
        {
            // key: "1-5 ряд", value: count of free ticket
            Dictionary<string, int> freeTicketsInCategory = new Dictionary<string, int>();
            int freeTicketCount = 0;
            foreach (Category category in categories)
            {
                freeTicketCount = tickets.Where(t => t.Event == ev)
                                         .Where(t => t.TicketCategory == category)
                                         .Where(t => t.TicketStatus.Value == "free").Count();
                freeTicketsInCategory.Add(category.Description, freeTicketCount);
                freeTicketCount =0;
            }
            return freeTicketsInCategory;
        }

        public int GetFirstFreeTicket(Event ev, Category ticketCategory)
        {
            int ticketId = tickets.Where(t => t.Event == ev)
                                  .Where(t => t.TicketCategory == ticketCategory)
                                  .Where(t => t.TicketStatus.Value == "free").First().Id;
            return ticketId;
        }

        // id from GetFirstFreeTicket
        public int BookTicket(int ticketId)
        {
            Ticket ticket = tickets.Find(t=>t.Id== ticketId);
            ticket.TicketStatus.Value = "booked";
            return ticket.Id;
        }
        // id from BookTicket
        public int BuyTicket (int ticketId)
        {
            Ticket ticket = tickets.Find(t => t.Id == ticketId);
            ticket.TicketStatus.Value = "purchased";
            return ticket.Id;
        }
    } 
}