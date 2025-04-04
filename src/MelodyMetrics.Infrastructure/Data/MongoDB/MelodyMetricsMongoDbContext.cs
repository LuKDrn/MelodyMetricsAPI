using MelodyMetrics.Domain.Entities.Artists;
using MelodyMetrics.Domain.Entities.Steamings;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MelodyMetrics.Infrastructure.Data.MongoDB
{
    public class MelodyMetricsMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MelodyMetricsMongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDB:Server");
            var databaseName = configuration.GetConnectionString("MongoDB:DatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Artist> Artists => _database.GetCollection<Artist>("Artists");
        public IMongoCollection<ArtistPlatform> ArtistPlatforms => _database.GetCollection<ArtistPlatform>("ArtistPlatforms");
        public IMongoCollection<ArtistStatistic> ArtistStatistics => _database.GetCollection<ArtistStatistic>("ArtistStatistics");
        public IMongoCollection<StreamingStatistic> StreamingStatistics => _database.GetCollection<StreamingStatistic>("StreamingStatistics");
    }
}
