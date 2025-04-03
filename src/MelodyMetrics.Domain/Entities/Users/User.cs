using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MelodyMetrics.Domain.Entities.Artists;

namespace MelodyMetrics.Domain.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }

        [BsonElement("Firstname")]
        public required string Firstname { get; set; }
        [BsonElement("Lastname")]
        public required string Lastname { get; set; }
        [BsonElement("Email")]
        public required string Email { get; set; }
        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        public ICollection<UserPlatform>? Platforms { get; set; }
        public ICollection<ArtistPlatform>? Artists { get; set; }
    }
}
