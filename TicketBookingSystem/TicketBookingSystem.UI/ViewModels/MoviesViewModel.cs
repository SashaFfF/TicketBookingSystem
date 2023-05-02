using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; //relaycommand
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
    public partial class MoviesViewModel : ObservableObject
    {
        private readonly IEventService _eventService;

        public MoviesViewModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        //[ObservableProperty]
        public ObservableCollection<Event> Events { get; set; } = new();

        [RelayCommand]
        async void InitEvents()
        {
            var events = await _eventService.GetAllAsync();//можно добавить методы GetAllMovies, GetAllConcerts, ... в EventService. Пока использую GetAll, потому что в бд только кино
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Events.Clear();
                foreach(var ev in events)
                {
                    Events.Add(ev);
                }
            });
        }

        [RelayCommand]
        async Task GoToMovie(Event ev)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {"SelectedEvent", ev}
            };
            await Shell.Current.GoToAsync($"{nameof(MovieDetailsPage)}", navigationParameter);
        }

    }
}
