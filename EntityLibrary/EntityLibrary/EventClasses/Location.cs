using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.EventClasses
{
    public class Location
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int BuildingNumber { get; set; }
        public string? BuildingName { get; set; }
    }
}
