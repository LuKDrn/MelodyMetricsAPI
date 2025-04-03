using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MelodyMetrics.Domain.Entities.Artists
{
    public class Artist
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        [BsonElement("ArtistId")]
        public required string ArtistId { get; set; }
        [BsonElement("ArtistName")]
        public required string ArtistName { get; set; }
        [BsonElement("Country")]
        public required string Country { get; set; }
    }

}
