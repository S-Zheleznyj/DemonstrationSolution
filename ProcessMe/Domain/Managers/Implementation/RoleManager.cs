using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepo _repo;
        public RoleManager(IRoleRepo repo)
        {
            _repo = repo;
        }
        public async Task<Guid> Create(RoleRequest roleRequest)
        {
            Role result = Role.FromRoleRequest(roleRequest);
            await _repo.Add(result);
            return result.Id;
        }

        public async Task<Role> GetItem(Guid id)
        {
            return await _repo.GetItem(id);
        }

        public async Task<IEnumerable<Role>> GetItems()
        {
            return await _repo.GetItems();
        }

        public async Task Update(Role role)
        {
            await _repo.Update(role);
        }
    }
}
