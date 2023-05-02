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
        public EventType? EventType { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Poster { get; set; }
        public DateTime Date { get; set; }
        public Location? EventLocation { get; set; }
        public Organizer? EventOrganizer { get; set; }
        public AgeLimit? EventAgeLimit { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
