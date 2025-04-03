using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using MelodyMetrics.Domain.Entities.Artists;

namespace MelodyMetrics.Domain.Entities.Steamings
{
    public class StreamingStatistic
    {
        public Guid Id { get; set; }

        [BsonElement("SavingDate")]
        public DateTime SavingDate { get; set; }
        [BsonElement("ArtistPlatformId")]
        public Guid ArtistPlatformId { get; set; }
        [ForeignKey("ArtistPlatformId")]
        public required ArtistPlatform ArtistPlatform { get; set; }
    }
}
