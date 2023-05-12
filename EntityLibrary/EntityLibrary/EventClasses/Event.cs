using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary.TicketClasses;

namespace EntityLibrary.EventClasses
{
    public class Event
    {
        public int Id { get; set; }
        public EventType EventType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Location EventLocation { get; set; }
        public Organizer EventOrganizer { get; set; }
        public AgeLimit EventAgeLimit { get; set; }

        ////////
        public List<Ticket> Tickets = new List<Ticket>();
        public Ticket BookTicket() // or return ticket id
        {
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.TicketStatus.Value == "free") // or available
                {
                    ticket.TicketStatus.Value = "booked";
                    return ticket;
                }
            }
            return null;
        }
        public void BuyTicket(Ticket ticket)
        {
            ticket.TicketStatus.Value = "bought"; //or purchased
        }
    }
}
