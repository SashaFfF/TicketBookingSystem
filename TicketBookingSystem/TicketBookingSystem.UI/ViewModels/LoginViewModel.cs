using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class LoginViewModel: ObservableObject
    {
        [ObservableProperty]
        string adminName = string.Empty;
        [ObservableProperty]
        string adminPassword =string.Empty;

    }
}
