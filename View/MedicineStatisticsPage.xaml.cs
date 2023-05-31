using ALMSAPP.Model;
using ALMSAPP.Services;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ALMSAPP.View;

public partial class MedicineStatisticsPage : ContentPage
{
	public ObservableCollection<MedicineItem> Items { get; set; } = new ObservableCollection<MedicineItem>();

	MedicineItemService medicineItemService = new();


	public MedicineStatisticsPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	protected override void OnAppearing()
	{
        base.OnAppearing();
        AddData();
    }

	public async void AddData()
	{
		try
		{
			var medicineItemList = await medicineItemService.GetMedicineAsync();
			foreach (var item in medicineItemList)
			{
				Items.Add(item);
			}
		}

		catch (Exception ex)
		{
            await DisplayAlert("Error", ex.Message, "OK");
        }


		//Items.Add(new MedicineItem { Name = "Paracetamol" });
		//Items.Add(new MedicineItem { Name = "Ibuprofen" });
		//Items.Add(new MedicineItem { Name = "Aspirin" });
	}

}