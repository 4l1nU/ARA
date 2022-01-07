using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ARA.Models;

namespace ARA.Data
{
    public class CabinetDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CabinetDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programari>().Wait();
        }
        public Task<List<Programari>> GetShopListsAsync()
        {
            return _database.Table<Programari>().ToListAsync();
        }
        public Task<Programari> GetShopListAsync(int id)
        {
            return _database.Table<Programari>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(Programari slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(Programari slist)
        {
            return _database.DeleteAsync(slist);
        }
    }

}
