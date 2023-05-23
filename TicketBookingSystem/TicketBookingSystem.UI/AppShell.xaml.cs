using TicketBookingSystem.UI.Views;
namespace TicketBookingSystem.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(PurchasePage), typeof(PurchasePage));
		Routing.RegisterRoute(nameof(EmailPage), typeof(EmailPage));
	}
}
