using EntityLibrary.TicketClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class TicketAllocation
    {
        public TicketAllocation(Category category, int count) 
        { 
            Category = category;
            Count = count;
        }
        public Category Category { get; set; }
        public int Count { get; set; }
    }
}
