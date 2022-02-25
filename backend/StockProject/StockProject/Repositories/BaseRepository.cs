using MongoDB.Driver;

namespace StockProject.Repositories
{
    public class BaseRepository<T>
    {
        protected readonly IMongoDatabase database;
        public IMongoCollection<T> collection { get; set; }

        public BaseRepository(IMongoClient client)
        {
            this.database = client.GetDatabase("StockProject");
            this.collection = database.GetCollection<T>(typeof(T).Name);
        }
    }
}
