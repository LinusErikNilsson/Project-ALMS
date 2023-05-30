using ALMSAPP.Model;
using System.Collections.ObjectModel;

namespace ALMSAPP.View;

public partial class MedicineStatisticsPage : ContentPage
{
	public ObservableCollection<MedicineItem> Items { get; set; } = new ObservableCollection<MedicineItem>();

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

	public void AddData()
	{
		Items.Add(new MedicineItem { Name = "Paracetamol" });
		Items.Add(new MedicineItem { Name = "Ibuprofen" });
		Items.Add(new MedicineItem { Name = "Aspirin" });
	}

}