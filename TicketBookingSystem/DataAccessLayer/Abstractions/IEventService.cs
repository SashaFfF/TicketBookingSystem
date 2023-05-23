using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstractions
{
    public interface IEventService : IBaseService<Event>
    {
        public Task<IEnumerable<Event>> GetAllEventsOfSpecificTypeAsync(string eventType, DateTime date, string city);
        public Task<IEnumerable<Event>> GetEventsOfSpecificTypeAsync(string eventType, DateTime date, string city);
        public Task<IEnumerable<KeyValuePair<Location, List<DateTime>>>> GetScheduleAsync(string EventType, string name, string city, DateTime date);
        public Task<Event> GetFirstOrDefaultAsync(string name, Location location, DateTime dateTime);
        public Task<Event> GetfirstByName(string name);
        public Task<Event> GetFirstByNameLocation(string name, Location location);

    }
}
