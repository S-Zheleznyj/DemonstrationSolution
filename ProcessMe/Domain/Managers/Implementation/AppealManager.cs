using AutoMapper;
using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class AppealManager : IAppealManager
    {
        private readonly IAppealRepo _repo;
        private readonly IMapper _mapper;
        public AppealManager(IAppealRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Guid> Create(AppealForCreationDto appealRequest)
        {
            //Appeal result = Appeal.FromAppealRequest(appealRequest);
            Appeal result = _mapper.Map<Appeal>(appealRequest);
            await _repo.Add(result);
            return result.Id;
        }

        public async Task<Appeal> GetItem(Guid id)
        {
            return await _repo.GetItem(id);
        }

        public async Task<IEnumerable<Appeal>> GetItems()
        {
            return await _repo.GetItems();
        }

        public async Task Update(Guid id, AppealForCreationDto appealRequest)
        {
            Appeal result = Appeal.FromAppealRequestAndId(id, appealRequest);
            await _repo.Update(result);
        }
    }
}
