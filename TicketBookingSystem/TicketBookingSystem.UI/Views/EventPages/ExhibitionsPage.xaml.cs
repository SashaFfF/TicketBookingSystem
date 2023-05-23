using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class ExhibitionsPage : ContentPage
{
	public ExhibitionsPage(ExhibitionsViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}