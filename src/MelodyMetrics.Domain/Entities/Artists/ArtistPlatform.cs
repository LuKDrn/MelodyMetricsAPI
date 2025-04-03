using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using MelodyMetrics.Domain.Entities.Steamings;
using MelodyMetrics.Domain.Entities.Users;

namespace MelodyMetrics.Domain.Entities.Artists
{
    public class ArtistPlatform
    {
        public Guid Id { get; set; }

        [BsonElement("ArtistId")]
        public required string ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public required Artist Artist { get; set; }
        [BsonElement("Platform")]
        public required string Platform { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<ArtistStatistic>? ArtistStatistics { get; set; }
        public ICollection<StreamingStatistic>? StreamingStatistics { get; set; }
    }
}
