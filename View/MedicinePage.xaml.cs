using ALMSAPP.Model;
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
        AddBasicRecordData();
        AddDataToCollection();
    }

    public void AddDataToCollection()
    {
        Items.Add(new MedicineItem { Name = "Paracetamol" });
        Items.Add(new MedicineItem { Name = "Ibuprofen" });
        Items.Add(new MedicineItem { Name = "Aspirin" });
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
            await DisplayAlert("Info", "Ingen medicin är vald - anteckningen kan inte läggas till", "OK");
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

    public async void AddBasicRecordData()
    {
        RecordItems.Add(new MedicineRecordItem { selectedItem = "Paracetamol", selectedDate = "31/05/2023", selectedTime = "10:00" });
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