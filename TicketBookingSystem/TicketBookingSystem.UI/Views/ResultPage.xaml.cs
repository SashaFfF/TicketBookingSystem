using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class ResultPage : ContentPage
{
	public ResultPage(ResultViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}