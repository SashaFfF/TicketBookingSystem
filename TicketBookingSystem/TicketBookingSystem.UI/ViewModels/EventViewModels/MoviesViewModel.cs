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
using Location = EntityLibrary.EventClasses.Location;

namespace TicketBookingSystem.UI.ViewModels
{
    public partial class MoviesViewModel : BaseViewModel
    {
        public MoviesViewModel(IEventService eventService) : base(eventService) { }
    }
}
