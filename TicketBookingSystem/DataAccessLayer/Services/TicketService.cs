using DataAccessLayer.Abstractions;
using DataLayer.Abstractions;
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
    }
}
