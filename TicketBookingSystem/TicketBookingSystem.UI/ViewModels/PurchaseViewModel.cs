using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccessLayer.Abstractions;
using EntityLibrary;
using EntityLibrary.EventClasses;
using EntityLibrary.TicketClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.UI.Views;

namespace TicketBookingSystem.UI.ViewModels
{
    [QueryProperty("SelectedSchedule", "SelectedSchedule")]
    [QueryProperty("SelectedEvent", "SelectedEvent")]
    public partial class PurchaseViewModel: ObservableObject
    {
        private readonly IEventService _eventService;
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;

        [ObservableProperty]
        public Event selectedEvent;
        [ObservableProperty]
        public Schedule selectedSchedule;

        [ObservableProperty]
        public DateTime selectedTime;

        [ObservableProperty]
        public Event selectedEvent1;
        [ObservableProperty]
        public Event selectedEvent2;
        [ObservableProperty]
        public Event selectedEvent3;
        [ObservableProperty]
        public DateTime selectedDate1;
        public PurchaseViewModel(IEventService eventService, ITicketService ticketService, ICategoryService categoryService)
        {
            _eventService = eventService;
            _ticketService = ticketService;
            _categoryService = categoryService;
        }

        public ObservableCollection<DateTime> DateTimes { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public ObservableCollection<Ticket> AllTickets { get; set; } = new();
        public ObservableCollection<TicketAllocation> TicketAllocation { get; set; } = new();
        
        //создам временно list, а не observablecollection, чтобы закинуть список в метод получения словаря, и если привязка будет работать с листом, а не osrvablecollection, то оставляю список

        //commands

        [RelayCommand]
        public async void InitStartData()
        {
            SelectedEvent1 = await _eventService.GetfirstByName(SelectedEvent.Name);
            SelectedEvent2 = await _eventService.GetFirstByNameLocation(SelectedEvent.Name, SelectedSchedule.Location);
            SelectedDate1 = new DateTime(2023, 5, 22, 17, 00, 00);
            SelectedEvent3 = await _eventService.GetFirstOrDefaultAsync(SelectedEvent.Name, SelectedSchedule.Location, SelectedDate1);
            await GetCategories();

            GetDateTimes();
        }

        [RelayCommand]
        async Task GoToNextPage()
        {
            await Shell.Current.GoToAsync(nameof(EmailPage));
        }


        //
        public async Task GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Categories.Clear();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            });
        }

        public async Task GetTickets()
        {
            var ev = await _eventService.GetFirstOrDefaultAsync(SelectedEvent.Name, SelectedSchedule.Location, SelectedTime);
            var tickets = await _ticketService.GetTicketsListByEvent(ev);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                AllTickets.Clear();
                foreach (var t in tickets)
                {
                    AllTickets.Add(t);
                }
            });
        }

        public void GetDateTimes()
        {
            DateTimes.Clear();
            foreach (var dateTime in SelectedSchedule.DateTimes)
            {
                DateTimes.Add(dateTime);
            }
        }

        public async Task GetFreeTicketsByCategory()
        {
            var ev = await _eventService.GetFirstOrDefaultAsync(SelectedEvent.Name, SelectedSchedule.Location, SelectedTime);
            var dictionary = await _ticketService.GetCountOfFreeTicketsByCategory(ev, Categories, "Свободно");
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                TicketAllocation.Clear();
                foreach (var d in dictionary)
                {
                    TicketAllocation.Add(new TicketAllocation(d.Key, d.Value));
                }
            });
        }
        
    }
}
