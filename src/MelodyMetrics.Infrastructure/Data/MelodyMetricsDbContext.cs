using MelodyMetrics.Domain.Entities.Artists;
using MelodyMetrics.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MelodyMetrics.Infrastructure.Data
{
    public class MelodyMetricsDbContext
    {
        private readonly IMongoDatabase _database;

        public MelodyMetricsDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDB");   
            var databaseName = configuration.GetConnectionString("DatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Artist> Artists => _database.GetCollection<Artist>("Artists");
        public IMongoCollection<User> Users => _database.GetCollection<User>("User");
    }
}
