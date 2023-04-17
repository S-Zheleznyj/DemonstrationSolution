using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.Dto;

namespace ProcessMe.Models.Entities
{
    /// <summary> Пользовательские роли</summary>
    public class Role : EntityBase
    {
        public RoleType Type { get; private set; }
        public ICollection<User> Users { get; private set; }
        public Role() { }

        public Role(RoleRequest roleRequest)
        {
            Id = Guid.NewGuid();
            Type = roleRequest.Type;
        }

        internal static Role FromDepartmentRequest(RoleRequest roleRequest)
        {
            Role role = new(roleRequest);
            role.Id = Guid.NewGuid();
            return role;
        }

        internal static Role FromDepartmentRequestAndId(Guid id, RoleRequest roleRequest)
        {
            Role role = new(roleRequest);
            role.Id = id;
            return role;
        }
    }
}
