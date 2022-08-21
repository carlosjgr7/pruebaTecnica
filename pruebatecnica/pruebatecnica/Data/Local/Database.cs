using System.Collections.Generic;
using System.Threading.Tasks;
using pruebatecnica.Models;
using SQLite;
namespace pruebatecnica.Data.Local
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTablesAsync<Root, Rating>().Wait();
                       

        }
        public  Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUsersAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<Root>> GetProductsAsync()
        {
            return _database.Table<Root>().ToListAsync();
        }
    }
}

