using ALMSAPP.Model;
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
            DisplayAlert("Selected Item", selectedItem, "OK");
        }
    }

    void OnDateSelected(object sender,DateChangedEventArgs args)
    {

        selectedDate = ((DatePicker)sender).Date.ToString("d");

        DisplayAlert("Selected Date", ((DatePicker)sender).Date.ToString("d"), "OK");

    }

    public async void OnTimeChanged(object sender, PropertyChangedEventArgs args)
    {
        selectedTime = ((TimePicker)sender).Time.ToString();
    }

    void TimeSelectedChecker(object sender, EventArgs e)
    {
        DisplayAlert("Selected Time", selectedTime, "OK");
    }

    public void AddMedicineRecord(object sender, EventArgs e)
    {
        MedicineRecordItem RecordItem = new MedicineRecordItem
        {
            selectedItem = selectedItem,
            selectedDate = selectedDate,
            selectedTime = selectedTime
        };

        RecordItems.Add(RecordItem);
    }

    public void AddBasicRecordData()
    {
        RecordItems.Add(new MedicineRecordItem { selectedItem = "Paracetamol", selectedDate = "31/05/2023", selectedTime = "10:00" });

    }

    public void DeleteMedicineRecord(object sender, EventArgs e)
    {
        var button = sender as Button;
        var recordItem = button.BindingContext as MedicineRecordItem;
        RecordItems.Remove(recordItem);
    }

}