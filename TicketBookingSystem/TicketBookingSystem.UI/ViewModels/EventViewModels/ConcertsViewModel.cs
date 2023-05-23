using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccessLayer.Abstractions;
using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class ConcertsViewModel: BaseViewModel
    {
        public ConcertsViewModel(IEventService eventService): base(eventService)
        {
        }

        public override async Task GetEvents()
        {
            var events = await _eventService.GetEventsOfSpecificTypeAsync("Концерт", selectedDate, selectedCity);
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
