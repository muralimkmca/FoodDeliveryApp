using FoodieApi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodieApi.Services
{
    public class FoodServices
    {
        private readonly IMongoCollection<Foods> foodcollection;
        public FoodServices(IOptions<DBSettings> dbSettings)
        {
            var foodConnection = new MongoClient(dbSettings.Value.ConnectionString);
            var foodb = foodConnection.GetDatabase(dbSettings.Value.DatabaseName);
            foodcollection = foodb.GetCollection<Foods>(dbSettings.Value.CollectionName);
        }

        //public async Task<List<Foods>> GetAsync()
        //    => await foodcollection.Find(_ => true).ToListAsync();


        public async Task<List<Foods>> GettheFood()
        {
            return await foodcollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertFoodDetails(Foods foods)
        {
            await foodcollection.InsertOneAsync(foods);
        }

    }
}
