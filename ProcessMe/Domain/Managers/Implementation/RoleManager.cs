using AutoMapper;
using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepo _repo;
        private readonly IMapper _mapper;
        public RoleManager(IRoleRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Guid> Create(RoleForCreationDto roleRequest)
        {
            //Role result = Role.FromRoleRequest(roleRequest);
            Role result = _mapper.Map<Role>(roleRequest);
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

        public async Task Update(Guid id, RoleForCreationDto roleRequest)
        {
            Role result = Role.FromRoleRequestAndId(id, roleRequest);
            await _repo.Update(result);
        }
    }
}
