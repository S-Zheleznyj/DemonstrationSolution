using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IAppealManager
    {
        Task<Appeal> GetItem(Guid id);
        Task<Guid> Create(AppealForCreationDto appeal);
        Task<IEnumerable<Appeal>> GetItems();
        Task Update(Guid id, AppealForCreationDto appeal);
    }
}
