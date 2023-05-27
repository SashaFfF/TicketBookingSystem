using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.UI.Views.AddPages;

namespace TicketBookingSystem.UI.ViewModels.AddViewModel
{
    public partial class AddTicketViewModel: ObservableObject
    {
        [RelayCommand]
        async Task GoToAddEvent()
        {
            await Shell.Current.GoToAsync(nameof(AddTicketPage));
        }
    }
}
