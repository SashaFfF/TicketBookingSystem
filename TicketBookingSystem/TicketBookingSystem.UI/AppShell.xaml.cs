using TicketBookingSystem.UI.Views;
namespace TicketBookingSystem.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MovieDetailsPage), typeof(MovieDetailsPage));
	}
}
