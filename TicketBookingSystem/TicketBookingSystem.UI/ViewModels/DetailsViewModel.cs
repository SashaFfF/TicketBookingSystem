//using Android.Widget;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccessLayer.Abstractions;
using EntityLibrary;
using EntityLibrary.EventClasses;
using iText.StyledXmlParser.Jsoup.Nodes;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.UI.Views;
using Location = EntityLibrary.EventClasses.Location;

namespace TicketBookingSystem.UI.ViewModels
{
    [QueryProperty("SelectedEvent", "SelectedEvent")]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly IEventService _eventService;

        [ObservableProperty]
        public Event selectedEvent;

        [ObservableProperty]
        public DateTime selectedDateTime;

        [ObservableProperty]
        public Schedule selectedSchedule;

        public DetailsViewModel(IEventService eventService)
        {
            _eventService = eventService;
        }
        public ObservableCollection<Schedule> Schedules { get; set; } = new();

        [RelayCommand]
        async Task InitSchedule()
        {
            await GetSchedule();
        }


        //[RelayCommand]
        //async void GoToPurchase(DateTime dateTime)
        //{
        //    await GoToNextPage(dateTime);
        //}

        //[RelayCommand]
        //async Task GoNext(Schedule schedule)
        //{
        //    var navigationParameter = new Dictionary<string, object>
        //    {
        //        {"SelectedSchedule", schedule}
        //    };
        //    await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", navigationParameter);
        //}


        public async Task GetSchedule()
        {
            //var schedule = await _eventService.GetScheduleAsync(SelectedEvent.EventType.Type, SelectedEvent.Name, SelectedEvent.EventLocation.City, SelectedEvent.Date);
            //Schedules.Clear();
            //foreach (var s in schedule)
            //{
            //    Schedules.Add(new Schedule(s.Key, s.Value));
            //}


            var schedule = await _eventService.GetScheduleAsync(SelectedEvent.EventType.Type, SelectedEvent.Name, SelectedEvent.EventLocation.City, SelectedEvent.Date);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Schedules.Clear();
                foreach (var s in schedule)
                {
                    Schedules.Add(new Schedule(s.Key, s.Value));
                }
            });
        }


        //async Task GoToNextPage(DateTime dateTime)
        //{
        //    var ev = await _eventService.GetFirstOrDefaultAsync(selectedEvent.Name, selectedSchedule.Location, dateTime);
        //    var navigationParameter = new Dictionary<string, object>
        //    {
        //        {"SelectedEvent", ev},
        //    };
        //    await Shell.Current.GoToAsync($"{nameof(PurchasePage)}", navigationParameter);
        //}

        [RelayCommand]
        async Task GoToNextPage(Schedule schedule)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {"SelectedSchedule", schedule},
                {"SelectedEvent", this.SelectedEvent}
            };
            await Shell.Current.GoToAsync($"{nameof(TicketSelectionPage)}", navigationParameter);
        }


        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
