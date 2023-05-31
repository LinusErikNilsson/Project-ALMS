using ALMSAPP.Database;

namespace ALMSAPP.View;

public partial class SettingsPage : ContentPage
{
    MedicineRecordItemDatabase Database = new();
    public SettingsPage()
	{
		InitializeComponent();
	}

    private async void LogoutCommand(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

    }

    private async void DeleteDatabaseContent(object sender, EventArgs e)
    {

        string action = await DisplayActionSheet("Rensa databasen", "Nej", "Ja");

        if(action == "Ja")
        {
            await Database.DeleteAllItemsAsync();
            await DisplayAlert("Info", "Alla anteckningar borttagna", "OK");
        }
        else if(action == "Nej")
        {
            return;
        }
    }

    private async void NavigateToLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("loginpage");
    }

    private async void NavigateToWebView(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("webviewdemo");
    }
}