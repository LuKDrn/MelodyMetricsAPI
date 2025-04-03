using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelodyMetrics.Domain.Entities.Users
{
    public class UserPlatform
    {
        public Guid Id { get; set; }

        [BsonElement("UserId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required Guid UserId { get; set; }

        [BsonElement("Platform")]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Platform { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
