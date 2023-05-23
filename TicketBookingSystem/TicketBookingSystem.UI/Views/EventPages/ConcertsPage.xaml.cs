using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class ConcertsPage : ContentPage
{
	public ConcertsPage(ConcertsViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}