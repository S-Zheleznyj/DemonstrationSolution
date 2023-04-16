using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IRatingManager
    {
        Task<Rating> GetItem(Guid id);
        Task<Guid> Create(RatingRequest appeal);
        Task<IEnumerable<Rating>> GetItems();
        Task Update(Rating rating);
    }
}
