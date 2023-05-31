using ALMSAPP.Model;
using SQLite;

namespace ALMSAPP.Database
{
    public class MedicineRecordItemDatabase
    {
        SQLiteAsyncConnection Database;

        public MedicineRecordItemDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<MedicineRecordItem>();
        }

        public async Task<List<MedicineRecordItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<MedicineRecordItem>().ToListAsync();
        }

        //public async Task<List<MedicineRecordItem>> GetItemsNotDoneAsync()
        //{
        //    await Init();
        //    return await Database.Table<MedicineRecordItem>().Where(t => t.Done).ToListAsync();

        //    // SQL queries are also possible
        //    //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public async Task<MedicineRecordItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<MedicineRecordItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(MedicineRecordItem medicineItem)
        {
            await Init();
            if (medicineItem.ID != 0)
                return await Database.UpdateAsync(medicineItem);
            else
                return await Database.InsertAsync(medicineItem);
        }

        public async Task<int> DeleteItemAsync(MedicineRecordItem medicineRecordItem)
        {
            await Init();
            return await Database.DeleteAsync(medicineRecordItem);
        }

    }
}
