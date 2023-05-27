using DataAccessLayer.Abstractions;
using DataLayer.Abstractions;
using EntityLibrary;
using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            if (ev != null)
            {
                await unitOfWork.EventRepository.DeleteAsync(ev);
            }
            return ev;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var all = await unitOfWork.EventRepository.ListAllAsync();
            return all.Distinct();
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

        ////////////
        public async Task<IEnumerable<Event>> GetEventsOfSpecificTypeAsync(string eventType, DateTime date, string city)
        {
            var events = await unitOfWork.EventRepository.ListAsync(ev => ev.EventType.Type == eventType &&
                                                                  ev.EventLocation.City == city &&
                                                                  ev.Date.Date == date.Date);
            return events.DistinctBy(ev => ev.Name);
        }
        public async Task<IEnumerable<Event>> GetAllEventsOfSpecificTypeAsync(string eventType, DateTime date, string city)
        {
            return await unitOfWork.EventRepository.ListAsync(ev => ev.EventType.Type == eventType &&
                                                                  ev.EventLocation.City == city &&
                                                                  ev.Date.Date == date.Date);
        }

        public async Task<IEnumerable<KeyValuePair<Location, List<DateTime>>>> GetScheduleAsync(string eventType, string name, string city, DateTime date)
        {
            var eventsOfSpecificType = await GetAllEventsOfSpecificTypeAsync(eventType, date, city);
            var eventsByName = eventsOfSpecificType.Where(e => e.Name == name);
            Dictionary<Location, List<DateTime>> dictionary= new Dictionary<Location, List<DateTime>>();
            foreach(var e in eventsByName)
            {
                if (!dictionary.ContainsKey(e.EventLocation))
                {
                    dictionary.Add(e.EventLocation, new List<DateTime>());
                    dictionary[e.EventLocation].Add(e.Date);
                }
                else
                {
                    dictionary[e.EventLocation].Add(e.Date);
                }
            }
            return dictionary;
        }

        public async Task<Event> GetFirstOrDefaultAsync(string name, Location location, DateTime dateTime)
        {
            var item = (await unitOfWork.EventRepository.ListAllAsync()).FirstOrDefault(ev => ev.Name == name && 
                                                                                        ev.EventLocation == location && 
                                                                                        ev.Date == dateTime);
            return item;
        }
        public async Task<Event> GetfirstByName(string name)
        {
            return await unitOfWork.EventRepository.FirstOrDefaultAsync(e=>e.Name == name);
        }
        public async Task<Event> GetFirstByNameLocation(string name, Location location)
        {
            return await unitOfWork.EventRepository.FirstOrDefaultAsync(ev=>ev.Name==name &&
                                                                            ev.EventLocation==location);
        }
    }
}
