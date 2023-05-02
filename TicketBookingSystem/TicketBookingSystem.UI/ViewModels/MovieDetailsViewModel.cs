using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EntityLibrary.EventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.UI.ViewModels
{
    [QueryProperty("SelectedEvent", "SelectedEvent")]
    public partial class MovieDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Event selectedEvent;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
