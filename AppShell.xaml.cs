using ALMSAPP.View;

namespace ALMSAPP;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("loginpage", typeof(LoginPage));
		Routing.RegisterRoute("medicinepage", typeof(MedicinePage));
        Routing.RegisterRoute("medicinestatisticspage", typeof(MedicineStatisticsPage));
		Routing.RegisterRoute("webviewdemo", typeof(WebViewDemo));
		Routing.RegisterRoute("settingspage", typeof(SettingsPage));
		Routing.RegisterRoute("recentmedicinerecords", typeof(RecentMedicineRecords));
    }
}
