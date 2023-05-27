using TicketBookingSystem.UI.Views;
using TicketBookingSystem.UI.Views.AddPages;

namespace TicketBookingSystem.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(TicketSelectionPage), typeof(TicketSelectionPage));
		Routing.RegisterRoute(nameof(EmailPage), typeof(EmailPage));
        Routing.RegisterRoute(nameof(PurchasePage), typeof(PurchasePage));
		Routing.RegisterRoute(nameof(ResultPage), typeof(ResultPage));
		Routing.RegisterRoute(nameof(DeletePage), typeof(DeletePage));
		Routing.RegisterRoute(nameof(AddEventPage), typeof(AddEventPage));
		Routing.RegisterRoute(nameof(AddTicketPage), typeof(AddTicketPage));
    }
}
