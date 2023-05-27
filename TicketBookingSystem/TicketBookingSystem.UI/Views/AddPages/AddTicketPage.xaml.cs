using TicketBookingSystem.UI.ViewModels.AddViewModel;

namespace TicketBookingSystem.UI.Views.AddPages;

public partial class AddTicketPage : ContentPage
{
	public AddTicketPage(AddTicketViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}