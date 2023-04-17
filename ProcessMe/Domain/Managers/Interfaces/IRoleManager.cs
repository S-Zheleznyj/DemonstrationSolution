using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IRoleManager
    {
        Task<Role> GetItem(Guid id);
        Task<Guid> Create(RoleRequest role);
        Task<IEnumerable<Role>> GetItems();
        Task Update(Guid id, RoleRequest role);
    }
}
