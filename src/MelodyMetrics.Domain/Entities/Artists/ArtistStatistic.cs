using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelodyMetrics.Domain.Entities.Artists
{
    public class ArtistStatistic
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
