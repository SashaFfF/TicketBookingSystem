using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.EventClasses
{
    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location OrganizerLocation { get; set; }
        public string PhoneNumber { get; set; }

    }
}
