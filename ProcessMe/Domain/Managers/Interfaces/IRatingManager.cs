using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IRatingManager
    {
        Task<Rating> GetItem(Guid id);
        Task<Guid> Create(RatingForCreationDto rating);
        Task<IEnumerable<Rating>> GetItems();
        Task Update(Guid id, RatingForCreationDto rating);
    }
}
