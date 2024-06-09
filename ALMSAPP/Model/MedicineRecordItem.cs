using SQLite;

namespace ALMSAPP.Model
{
    public class MedicineRecordItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string selectedItem { get; set; }
        public string selectedDate { get; set; }
        public string selectedTime { get; set; }
    }
}
