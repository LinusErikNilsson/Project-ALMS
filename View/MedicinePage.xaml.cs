using ALMSAPP.Database;
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
    MedicineRecordItemDatabase Database = new();

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
        AddMedicineItemToCollection();
    }

    public async void AddDataToDatabase(object sender, EventArgs e)
    {
        if(selectedItem == null)
        {
            await DisplayAlert("Info", "Ingen medicin �r vald - anteckningen kan inte l�ggas till", "OK");
            return;
        }
        if(selectedDate == null)
        {             
            await DisplayAlert("Info", "Inget datum �r valt - anteckningen kan inte l�ggas till", "OK");
            return;
        }
        if(selectedTime == string.Empty)
        {
            await DisplayAlert("Info", "Ingen tid �r vald - anteckningen kan inte l�ggas till", "OK");
            return;
        }

        MedicineRecordItem RecordItem = new MedicineRecordItem
        {
            selectedItem = selectedItem,
            selectedDate = selectedDate,
            selectedTime = selectedTime
        };

        await Database.SaveItemAsync(RecordItem);


        var CancellationTokenSource = new CancellationTokenSource();
        var message = $"Ny anteckning skapad: {selectedItem}";
        ToastDuration duration = ToastDuration.Short;
        var fontSize = 14;
        var toast = Toast.Make(message, duration, fontSize);
        await toast.Show(CancellationTokenSource.Token);
    }

    public async void AddMedicineItemToCollection()
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

}