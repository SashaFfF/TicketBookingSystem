using CommunityToolkit.Maui.Storage;
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
using TicketBookingSystem.UI.Views.AddPages;
using Location = EntityLibrary.EventClasses.Location;

namespace TicketBookingSystem.UI.ViewModels.AddViewModel
{
    public partial class AddEventViewModel: ObservableObject
    {
        private readonly IEventService _eventService;
        private readonly ILocationService _locationService;
        private readonly IAgeLimitService _ageLimitService;
        private readonly IOrganizerService _organizerService;


        [ObservableProperty]
        public Type eventType;
        [ObservableProperty]
        public string eventName;
        [ObservableProperty]
        public string eventDescription;
        [ObservableProperty]
        public string eventPoster;
        [ObservableProperty]
        public DateTime eventDate;
        [ObservableProperty]
        public TimeSpan eventTime;
        [ObservableProperty]
        public Location eventLocation;
        [ObservableProperty]
        public Organizer eventOrganizer;
        [ObservableProperty]
        public AgeLimit eventAgeLimit;

        [ObservableProperty]
        public DateTime minDateTime = DateTime.Now;
        [ObservableProperty]
        public DateTime maxDateTime = DateTime.Now.AddMonths(1);

        public AddEventViewModel(IEventService eventService)
        {
            _eventService = eventService;
            //_ageLimitService = ageLimitService;
            //_locationService = locationService;
            //_organizerService = organizerService;

        }

        public ObservableCollection<AgeLimit> AgeLimits { get; set; } = new();
        public ObservableCollection<Location> Locations { get; set; } = new();
        public ObservableCollection<Organizer> Organizers { get; set; } = new();


        [RelayCommand]
        async Task GoToAddTicket()
        {
            await Shell.Current.GoToAsync(nameof(AddTicketPage));
        }

        [RelayCommand]
        async void InitStartData()
        {
            //await GetAgeLimits();
            //await GetLocations();
            //await GetOrganizers();
        }
        public virtual async Task GetAgeLimits()
        {
            var agelimits = await _ageLimitService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                AgeLimits.Clear();
                foreach (var a in agelimits)
                {
                    AgeLimits.Add(a);
                }
            });
        }

        public virtual async Task GetLocations()
        {
            var locations = await _locationService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Locations.Clear();
                foreach (var l in locations)
                {
                    Locations.Add(l);
                }
            });
        }

        public virtual async Task GetOrganizers()
        {
            var organizers= await _organizerService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Organizers.Clear();
                foreach (var o in organizers)
                {
                    Organizers.Add(o);
                }
            });
        }


    }
}
