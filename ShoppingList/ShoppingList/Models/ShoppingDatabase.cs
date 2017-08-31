using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class ShoppingDatabase
    {
        private SQLiteAsyncConnection database;

        public ShoppingDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ShoppingListModel>().Wait();
        }

        public Task<List<ShoppingListModel>> GetItemsAsync()
        {
            return database.Table<ShoppingListModel>().ToListAsync();
        }

        public Task<ShoppingListModel> GetItemAsync(int id)
        {
            return database.Table<ShoppingListModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ShoppingListModel shoppingList)
        {
            if (shoppingList.ID != 0)
            {
                return database.UpdateAsync(shoppingList);
            }
            else
            {
                return database.InsertAsync(shoppingList);
            }
        }

        public Task<int> DeleteItemAsync(ShoppingListModel shoppingList)
        {
            return database.DeleteAsync(shoppingList);
        }
    }
}
