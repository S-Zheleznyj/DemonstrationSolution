using ProcessMe.Models.Entities;

namespace ProcessMe.Models.DTOs.Incoming
{
    public class UserFroCreationDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
