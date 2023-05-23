using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstractions
{
    public interface ITicketService : IBaseService<Ticket>
    {
        public Task<IEnumerable<Ticket>> GetTicketsListByEvent(Event ev);
        public Task<Dictionary<Category, int>> GetCountOfFreeTicketsByCategory(Event ev, List<Category> categories, string ticketStatusValue);
    }
}
