using System.ComponentModel.DataAnnotations.Schema;

namespace MelodyMetrics.Domain.Entities.Users
{
    public class UserPlatform
    {
        public Guid Id { get; set; }
        public required string Platform { get; set; }
        public required Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
