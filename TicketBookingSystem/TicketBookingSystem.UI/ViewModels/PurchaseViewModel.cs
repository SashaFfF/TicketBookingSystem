using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControllerLibrary;
using DataAccessLayer.Abstractions;
using EntityLibrary.TicketClasses;
using iText.StyledXmlParser.Jsoup.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.UI.Views;

namespace TicketBookingSystem.UI.ViewModels
{
    [QueryProperty("SelectedTicket", "SelectedTicket")]
    [QueryProperty("UserEmail", "UserEmail")]
    [QueryProperty("PhoneNumber", "PhoneNumber")]
    public partial class PurchaseViewModel: ObservableObject
    {
        ITicketService _ticketService;
        IStatusService _statusService;
        public PurchaseViewModel(ITicketService ticketService, IStatusService statusService)
        {
            _ticketService = ticketService;
            _statusService = statusService;
        }

        [ObservableProperty]
        public string userEmail;
        [ObservableProperty]
        public string phoneNumber;
        [ObservableProperty]
        public Ticket selectedTicket;

        [ObservableProperty]
        public string cardNumber;
        [ObservableProperty]
        public string cardholderName;
        [ObservableProperty]
        public string validityPeriod_month;
        [ObservableProperty]
        public DateTime validityPeriod_year;
        [ObservableProperty]
        public string verificationNumber;


        public ObservableCollection<string> Months { get; set; } = new();
        public ObservableCollection<string> Years { get; set; } = new();

        [RelayCommand]
        void InitStartData()
        {
            GetMonths();
            GetYears();
        }

        [RelayCommand]
        public async Task GoToNextPage()
        {
            await BuyTicket();
            string ticketPath = TicketGenerationController.GenerationTicketPdf(SelectedTicket);
            TicketGenerationController.SendEmail(UserEmail, ticketPath);
            await Shell.Current.GoToAsync(nameof(ResultPage));
        }

        void GetMonths()
        {
            for(int i = 1; i<=12; i++)
            {
                if (i <= 9)
                {
                    Months.Add($"0{i}");
                }
                else
                {
                    Months.Add(i.ToString());
                }
            }
        }
        void GetYears()
        {
            for(int i=0; i<6; i++)
            {
                Years.Add((2023+i).ToString());
            }

        }
        async Task BuyTicket()
        {
            var new_status = await _statusService.GetByIdAsync(3);
            selectedTicket.TicketStatus = new_status;
            await _ticketService.UpdateAsync(selectedTicket);
        }

    }
}
