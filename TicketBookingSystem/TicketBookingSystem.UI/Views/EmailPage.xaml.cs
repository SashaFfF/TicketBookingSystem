using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class EmailPage : ContentPage
{
	public EmailPage(EmailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}