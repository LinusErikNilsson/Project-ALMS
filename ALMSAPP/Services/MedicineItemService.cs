using ALMSAPP.Model;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace ALMSAPP.Services
{
    public class MedicineItemService
    {
        HttpClient httpClient;

        public MedicineItemService()
        {
            httpClient = new HttpClient();
        }

        List<MedicineItem> medicineItemList = new();

        public ObservableCollection<MedicineItem> medicineItemListOC = new();

        public async Task<ObservableCollection<MedicineItem>> GetMedicineAsync()
        {
            if (medicineItemListOC?.Count > 0)
            {
                return medicineItemListOC;
            }

            var url = "https://medicineitemwebapi20230531155329.azurewebsites.net/api/MedicineItem";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                medicineItemListOC = await response.Content.ReadFromJsonAsync<ObservableCollection<MedicineItem>>();
            }

            return medicineItemListOC;
        }
    }

}
