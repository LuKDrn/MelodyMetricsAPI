using MelodyMetrics.Domain.Entities.Steamings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<ArtistStatistic>? ArtistStatistics { get; set; }
        public ICollection<StreamingStatistic>? StreamingStatistics { get; set; }
    }
}
