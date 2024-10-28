using FriendOrganiser.Domain.Common;

namespace FriendOrganiser.Domain.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
