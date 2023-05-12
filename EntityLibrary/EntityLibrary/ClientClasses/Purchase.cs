using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary.TicketClasses;

namespace EntityLibrary.ClientClasses
{
    public class Purchase
    {
        public int Id { get; set; }
        public Ticket? Ticket { get; set; }
        public Client? Client { get; set; }
    }
}
