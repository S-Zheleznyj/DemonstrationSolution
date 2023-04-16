using ProcessMe.Models.Dto;

namespace ProcessMe.Models.Entities
{
    /// <summary> Пользовательские роли</summary>
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public ICollection<User> Users { get; private set; }
        public Role() { }

        public Role(RoleRequest roleRequest)
        {
            Id = Guid.NewGuid();
            Name = roleRequest.Name;
        }

        internal static Role FromRoleRequest(RoleRequest roleRequest)
        {
            return new(roleRequest);
        }
    }
}
