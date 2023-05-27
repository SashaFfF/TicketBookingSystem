using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class CircusPage : ContentPage
{
    public CircusPage(CircusViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}