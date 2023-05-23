using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class PurchasePage : ContentPage
{
	public PurchasePage(PurchaseViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

    private async void RadioButtonCheckedChangedAsync(object sender, CheckedChangedEventArgs e)
    {
		
		RadioButton radioButton = sender as RadioButton;
        PurchaseViewModel vm = (PurchaseViewModel)BindingContext;
		vm.SelectedTime = (DateTime)radioButton.Value;
		await vm.GetFreeTicketsByCategory();
		await vm.GetTickets();
    }
}