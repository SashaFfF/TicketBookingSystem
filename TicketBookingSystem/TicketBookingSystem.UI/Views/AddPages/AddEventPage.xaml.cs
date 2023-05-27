using TicketBookingSystem.UI.ViewModels.AddViewModel;

namespace TicketBookingSystem.UI.Views.AddPages;

public partial class AddEventPage : ContentPage
{
	public AddEventPage(AddEventViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}