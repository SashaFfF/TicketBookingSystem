using EntityLibrary.TicketClasses;
using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class TicketSelectionPage : ContentPage
{
	public TicketSelectionPage(TicketSelectionViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

    private async void RadioButtonCheckedChangedAsync(object sender, CheckedChangedEventArgs e)
    {
		
		RadioButton radioButton = sender as RadioButton;
        TicketSelectionViewModel vm = (TicketSelectionViewModel)BindingContext;
		vm.SelectedTime = (DateTime)radioButton.Value;
		vm.IsVisibleLabel = true;
		await vm.GetFreeTicketsByCategory();

    }

    private void CategoryRadioButtonChangedAsync(object sender, CheckedChangedEventArgs e)
    {
		RadioButton radioBtn = sender as RadioButton;
		TicketSelectionViewModel vm =(TicketSelectionViewModel)BindingContext;
		vm.SelectedCategory = (Category)radioBtn.Value;
		vm.IsVisible = true;
    }
}