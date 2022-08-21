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
            _database.CreateTableAsync<Rating>().Wait();
            _database.CreateTableAsync<Product>().Wait();



        }
        public  async Task<List<User>> GetUsersAsync()
        {
            return await _database.Table<User>()
                    .ToListAsync();
        }

        public Task<int> SaveUsersAsync(User user)
        {
            return _database
                    .InsertAsync(user);
        }

        public async Task<int> SaveProductAsync(Product product)
        {
           return await  _database
                    .InsertAsync(product);
        }

        public async Task<int> SaveRatingAsync(Rating rating)
        {
            return await _database
                    .InsertAsync(rating);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _database.Table<Product>()
                    .ToListAsync();
        }

        public async Task<Rating> GetRatingsAsync(int id)
        {
            return await _database.Table<Rating>()
                        .Where(x=>x.id==id)
                        .FirstOrDefaultAsync();
        }

        public async Task DeleteRegisters()
        {
            await _database.Table<Product>().DeleteAsync(x=>x.id!=null);
            await _database.Table<Rating>().DeleteAsync(x =>x.id != null);
        }
    }
}

