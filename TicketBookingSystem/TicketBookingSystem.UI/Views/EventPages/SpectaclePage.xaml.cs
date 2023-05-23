using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class SpectaclePage : ContentPage
{
	public SpectaclePage(SpectacleViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}