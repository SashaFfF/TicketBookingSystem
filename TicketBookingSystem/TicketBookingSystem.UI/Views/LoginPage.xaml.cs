using TicketBookingSystem.UI.ViewModels;
using TicketBookingSystem.UI.Views.AddPages;

namespace TicketBookingSystem.UI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

    private async void AlertButton_Clicked(object sender, EventArgs e)
    {
		bool result = await DisplayAlert("Действия", "Вы хотите удалить или добавить данные?", "Удалить", "Добавить"); //add delete
		if (result )//true - update
		{
            await Shell.Current.GoToAsync(nameof(DeletePage));

		}
		else
		{
            await Shell.Current.GoToAsync(nameof(AddEventPage));
        }
    }
}