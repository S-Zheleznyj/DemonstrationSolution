using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class UserRequest
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Guid RoleId { get; private set; }
    }
}
