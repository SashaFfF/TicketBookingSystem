using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary.EventClasses;

namespace EntityLibrary
{
    public class Catalog
    {
        public List<Event> Events = new List<Event>();
        //конструктор
        public List<Event> SelectByDate(DateTime date)
        {
            return Events.Where(e=>e.Date == date).ToList();
        }
        public List<Event> SelectByLocation(Location location)
        {
            return Events.Where(e=>e.EventLocation== location).ToList();
        }
        public List<Event> SelectByCity(string city)
        {
            return Events.Where(e=>e.EventLocation.City==city).ToList();
        }
    }
}
