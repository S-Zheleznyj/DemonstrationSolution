using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class RatingManager : IRatingManager
    {
        private readonly IRatingRepo _repo;
        public RatingManager(IRatingRepo repo)
        {
            _repo = repo;
        }
        public async Task<Guid> Create(RatingRequest ratingRequest)
        {
            Rating result = Rating.FromRatingRequest(ratingRequest);
            await _repo.Add(result);
            return result.Id;
        }

        public async Task<Rating> GetItem(Guid id)
        {
            return await _repo.GetItem(id);
        }

        public async Task<IEnumerable<Rating>> GetItems()
        {
            return await _repo.GetItems();
        }

        public async Task Update(Rating rating)
        {
            await _repo.Update(rating);
        }
    }
}
