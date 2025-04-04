using MelodyMetrics.Domain.Entities.Artists;

namespace MelodyMetrics.Domain.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<UserPlatform>? Platforms { get; set; }
    }
}
