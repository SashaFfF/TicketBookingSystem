using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccessLayer.Abstractions;
using EntityLibrary.TicketClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.UI.Views;

namespace TicketBookingSystem.UI.ViewModels
{
    [QueryProperty("SelectedTicket", "SelectedTicket")]
    public partial class EmailViewModel: ObservableObject
    {
        ITicketService _ticketService;
        IStatusService _statusService;
        public  EmailViewModel(ITicketService ticketService, IStatusService statusService)
        {
            _ticketService = ticketService;
            _statusService = statusService;
        }
        [ObservableProperty]
        Ticket selectedTicket;

        [ObservableProperty]
        public string userEmail = string.Empty;

        [ObservableProperty]
        public string phoneNumber = string.Empty;

        [ObservableProperty]
        public bool allFieldsFilled ;
        [ObservableProperty]
        public bool allPhoneNumbers = false;

        [RelayCommand]
        async Task GoToNextPage()
        {
            await BookTicket();

            var navigationParameter = new Dictionary<string, object>
            {
                {"SelectedTicket", SelectedTicket},
                {"UserEmail", UserEmail},
                {"PhoneNumber", PhoneNumber},
            };
            await Shell.Current.GoToAsync($"{nameof(PurchasePage)}", navigationParameter);
        }

        async Task BookTicket()
        {
            var new_status = await _statusService.GetByIdAsync(2);
            selectedTicket.TicketStatus= new_status;
            await _ticketService.UpdateAsync(selectedTicket);
        }
    }
}
