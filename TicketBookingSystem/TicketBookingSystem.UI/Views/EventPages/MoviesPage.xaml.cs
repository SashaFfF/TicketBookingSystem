using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class MoviesPage : ContentPage
{
	public MoviesPage(MoviesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}