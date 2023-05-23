using DataAccessLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class CircusViewModel: BaseViewModel
    {
        public CircusViewModel(IEventService eventService) : base(eventService)
        {
        }

        public override async Task GetEvents()
        {
            var events = await _eventService.GetEventsOfSpecificTypeAsync("Цирк", selectedDate, selectedCity);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Events.Clear();
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
            });
        }
    }
}
