using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class AppealManager : IAppealManager
    {
        private readonly IAppealRepo _repo;
        public AppealManager(IAppealRepo repo)
        {
            _repo = repo;
        }
        public async Task<Guid> Create(AppealRequest appealRequest)
        {
            Appeal result = Appeal.FromAppealRequest(appealRequest);
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

        public async Task Update(Appeal appeal)
        {
            await _repo.Update(appeal);
        }
    }
}
