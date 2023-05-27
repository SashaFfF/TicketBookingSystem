using TicketBookingSystem.UI.ViewModels;

namespace TicketBookingSystem.UI.Views;

public partial class PurchasePage : ContentPage
{
	public PurchasePage(PurchaseViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    private async void AlertButton_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("�������", "�� �������� � ���������� ���� �������?", "��", "���");
        if (result)
        {
            PurchaseViewModel vm =(PurchaseViewModel)BindingContext;
            await vm.GoToNextPage();

        }
    }
}