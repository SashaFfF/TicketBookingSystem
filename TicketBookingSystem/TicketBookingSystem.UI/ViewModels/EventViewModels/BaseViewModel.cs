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
using TicketBookingSystem.UI.Views;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        protected readonly IEventService _eventService;

        [ObservableProperty]
        public DateTime selectedDate = DateTime.Now;

        [ObservableProperty]
        public string selectedCity = "Минск";

        public BaseViewModel(IEventService eventService)
        {
            MinDate = DateTime.Now;
            MaxDate = DateTime.Now.AddMonths(1);
            _eventService = eventService;
        }
        public ObservableCollection<Event> Events { get; set; } = new();
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }

        [RelayCommand]
        async void GetListOfEvents()
        {
            await GetEvents();
        }
        public virtual async Task GetEvents()
        {
            var events = await _eventService.GetEventsOfSpecificTypeAsync("Кино", selectedDate, selectedCity);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Events.Clear();
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
            });
        }

        [RelayCommand]
        async Task GoToDetails(Event ev)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {"SelectedEvent", ev}
            };
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", navigationParameter);
        }
    }
}
