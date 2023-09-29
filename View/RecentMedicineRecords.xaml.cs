namespace ALMSAPP.View;

public partial class RecentMedicineRecords : ContentPage
{
	public RecentMedicineRecords()
	{
		InitializeComponent();
		BindingContext = this;
	}

	public bool IsRefreshing { get; set; }

	public async void Refresh()
	{
		return;
	}


}