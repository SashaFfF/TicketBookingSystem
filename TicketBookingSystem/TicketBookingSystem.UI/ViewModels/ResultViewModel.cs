using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.UI.Views;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class ResultViewModel: ObservableObject
    {
        [RelayCommand]
        async Task GoToStartPage()
        {
            await Shell.Current.GoToAsync("MoviesPage");
        }

    }
}
