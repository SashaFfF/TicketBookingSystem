using DataAccessLayer.Abstractions;
using DataLayer.Abstractions;
using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class TicketService : ITicketService
    {
        IUnitOfWork unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Ticket> AddAsync(Ticket item)
        {
            await unitOfWork.TicketRepository.AddAsync(item);
            return item;
        }

        public async Task<Ticket> DeleteAsync(int id)
        {
            Ticket ticket = await GetByIdAsync(id);
            await unitOfWork.TicketRepository.DeleteAsync(ticket);
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await unitOfWork.TicketRepository.ListAllAsync();
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            return unitOfWork.TicketRepository.GetByIdAsync(id);
        }

        public async Task<Ticket> UpdateAsync(Ticket item)
        {
            await unitOfWork.TicketRepository.UpdateAsync(item);
            return item;
        }

        ////
        public async Task<IEnumerable<Ticket>> GetTicketsListByEvent(Event ev)
        {
            return await unitOfWork.TicketRepository.ListAsync(t => t.Event == ev );
        }

        public async Task<Dictionary<Category, int>> GetCountOfFreeTicketsByCategory(Event ev, List<Category> categories, string ticketStatusValue)
        {
            Dictionary<Category, int> freeTicketsInCategory = new Dictionary<Category, int>();
            var tickets = await GetTicketsListByEvent(ev);
            int freeTicketsCount = 0;
            foreach(Category category in categories)
            {
                freeTicketsCount = tickets.Where(t => t.TicketCategory == category && t.TicketStatus.Value == ticketStatusValue).Count();
                freeTicketsInCategory.Add(category, freeTicketsCount);
                freeTicketsCount = 0;
            }
            return freeTicketsInCategory;
        }
    }
}
