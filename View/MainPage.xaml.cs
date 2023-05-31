namespace ALMSAPP;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void NavigateToLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//medicinepage");
    }

}

