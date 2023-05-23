using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class EmailViewModel: ObservableObject
    {
        [ObservableProperty]
        string email = string.Empty;

        [ObservableProperty]
        string phoneNumber = string.Empty;
    }
}
