using ALMSAPP.Model;
using ALMSAPP.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
namespace ALMSAPP.View;

public partial class MedicinePage : ContentPage
{
    public ObservableCollection<MedicineItem> Items { get; set; } = new ObservableCollection<MedicineItem>();

    public ObservableCollection<MedicineRecordItem> RecordItems { get; set; } = new ObservableCollection<MedicineRecordItem>();

    MedicineItemService medicineItemService = new();

    public string selectedItem { get; set; }
    public string selectedDate { get; set; }

    public string selectedTime { get; set; }

    public MedicinePage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AddDataToCollection();
    }

    public async void AddDataToCollection()
    {
        try
        {
            var medicineItemCollection = await medicineItemService.GetMedicineAsync();

            //Clear collection before adding items from medicineList
            Items.Clear();

            foreach (var item in medicineItemCollection)
            {
                Items.Add(item);
            }
        }
        catch
        {
            await DisplayAlert("Varning", "Kunde inte h�mta data fr�n APIet", "OK");
        }

    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            selectedItem = picker.Items[selectedIndex].ToString();
        }
    }

    void OnDateSelected(object sender,DateChangedEventArgs args)
    {
        selectedDate = ((DatePicker)sender).Date.ToString("d");
    }

    public async void OnTimeChanged(object sender, PropertyChangedEventArgs args)
    {
        selectedTime = ((TimePicker)sender).Time.ToString();
    }

    public async void AddMedicineRecord(object sender, EventArgs e)
    {
        if (selectedItem is null)
        {
            await DisplayAlert("Info", "Ingen medicin �r vald - anteckningen kan inte l�ggas till", "OK");
        }
        else
        {
            MedicineRecordItem RecordItem = new MedicineRecordItem
            {
                selectedItem = selectedItem,
                selectedDate = selectedDate,
                selectedTime = selectedTime
            };

            RecordItems.Add(RecordItem);

            var CancellationTokenSource = new CancellationTokenSource();
            var message = $"Anteckning skapad: {selectedItem}";
            ToastDuration duration = ToastDuration.Short;
            var fontSize = 14;
            var toast = Toast.Make(message, duration, fontSize);
            await toast.Show(CancellationTokenSource.Token);
        }

    }

    public async void DeleteMedicineRecord(object sender, EventArgs e)
    {
        var button = sender as Button;
        var recordItem = button.BindingContext as MedicineRecordItem;
        //RecordItems.Remove(recordItem);

        string action = await DisplayActionSheet("Vill du ta bort anteckningen?", "Nej", "Ja");

        if (action == "Ja")
        {
            RecordItems.Remove(recordItem);
            await DisplayAlert("Info", "Anteckning borttagen", "OK");
        }
        else if (action == "Nej")
        {
            return;
        }


    }

}