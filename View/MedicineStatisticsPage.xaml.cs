using ALMSAPP.Database;
using ALMSAPP.Model;
using ALMSAPP.Services;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ALMSAPP.View;

public partial class MedicineStatisticsPage : ContentPage
{
    MedicineRecordItemDatabase Database = new();
    public ObservableCollection<MedicineRecordItem> Items { get; set; } = new ObservableCollection<MedicineRecordItem>();

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
            Items.Clear();
            //Database. is where the Method/query is located (From Database class)
            var databaseItems = Database.GetItemsAsync();
            foreach (var item in await databaseItems)
            {
                Items.Add(item);
            }
        }

		catch (Exception ex)
		{
            await DisplayAlert("Error", ex.Message, "OK");
        }

	}

    public async void DeleteMedicineRecord(object sender, EventArgs e)
    {
        var button = sender as Button;
        var recordItem = button.BindingContext as MedicineRecordItem;

        string action = await DisplayActionSheet("Vill du ta bort anteckningen?", "Nej", "Ja");

        if (action == "Ja")
        {
            await Database.DeleteItemAsync(recordItem);
            await DisplayAlert("Info", "Anteckning borttagen", "OK");
            AddData();
        }
        else if (action == "Nej")
        {
            return;
        }

    }

}