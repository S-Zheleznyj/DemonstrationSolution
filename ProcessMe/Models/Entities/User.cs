using ProcessMe.Models.Dto;

namespace ProcessMe.Models.Entities
{
    /// <summary> Данные пользователя</summary>
    public class User : EntityBase
    {
        public string Username { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public Guid RoleId { get; private set; }
        public Role Role { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public User() { }

        internal static User FromUserRequest(UserRequest userRequest)
        {
            throw new NotImplementedException();
        }

        internal static User FromUserRequestAndId(Guid id, UserRequest userRequest)
        {
            throw new NotImplementedException();
        }
    }
}
