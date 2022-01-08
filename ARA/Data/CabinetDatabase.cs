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
            _database.CreateTableAsync<Serviciu>().Wait();
            _database.CreateTableAsync<ListServiciu>().Wait();
        }
        public Task<int> SaveProductAsync(Serviciu product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Serviciu product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Serviciu>> GetProductsAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
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
        public Task<int> SaveListProductAsync(ListServiciu listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Serviciu>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Serviciu>(
            "select P.ID, P.Description from Product P"
            + " inner join ListProduct LP"
            + " on P.ID = LP.ProductID where LP.ShopListID = ?",
            shoplistid);
        }
    }

}
