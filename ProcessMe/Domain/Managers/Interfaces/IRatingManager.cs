using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IRatingManager
    {
        Task<Rating> GetItem(Guid id);
        Task<Guid> Create(RatingRequest rating);
        Task<IEnumerable<Rating>> GetItems();
        Task Update(Guid id, RatingRequest rating);
    }
}
