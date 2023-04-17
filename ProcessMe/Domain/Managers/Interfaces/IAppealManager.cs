using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IAppealManager
    {
        Task<Appeal> GetItem(Guid id);
        Task<Guid> Create(AppealRequest appeal);
        Task<IEnumerable<Appeal>> GetItems();
        Task Update(Guid id, AppealRequest appeal);
    }
}
