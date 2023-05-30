namespace ALMSAPP.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync($"//medicinepage");
    }
}