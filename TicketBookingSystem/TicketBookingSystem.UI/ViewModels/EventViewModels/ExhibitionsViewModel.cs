using DataAccessLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class ExhibitionsViewModel: BaseViewModel
    {
        public ExhibitionsViewModel(IEventService eventService) : base(eventService)
        {
        }

        public override async Task GetEvents()
        {
            var events = await _eventService.GetEventsOfSpecificTypeAsync("Выставка", selectedDate, selectedCity);
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
