using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.TicketClasses
{
    public class Ticket
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public Category? TicketCategory { get; set; }
        public Status? TicketStatus { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
    }
}
