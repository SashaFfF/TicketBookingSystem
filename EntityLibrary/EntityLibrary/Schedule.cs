using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Schedule
    {
        public Schedule(Location location, List<DateTime> dateTimes) 
        {
            Location = location;
            DateTimes = dateTimes;
        }
        public Location? Location { get; set; }
        public List<DateTime>? DateTimes { get; set; }
    }
}
