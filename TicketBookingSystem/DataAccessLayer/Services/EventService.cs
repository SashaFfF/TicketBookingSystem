using DataAccessLayer.Abstractions;
using DataLayer.Abstractions;
using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class EventService : IEventService
    {
        IUnitOfWork unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Event> AddAsync(Event item)
        {
            await unitOfWork.EventRepository.AddAsync(item);
            return item;
        }

        public async Task<Event> DeleteAsync(int id)
        {
            Event ev = await GetByIdAsync(id);
            await unitOfWork.EventRepository.DeleteAsync(ev);
            return ev;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await unitOfWork.EventRepository.ListAllAsync();
        }

        public Task<Event> GetByIdAsync(int id)
        {
            return unitOfWork.EventRepository.GetByIdAsync(id);
        }

        public async Task<Event> UpdateAsync(Event item)
        {
            await unitOfWork.EventRepository.UpdateAsync(item);
            return item;
        }
    }
}
