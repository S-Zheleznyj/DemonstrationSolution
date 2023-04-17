using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
