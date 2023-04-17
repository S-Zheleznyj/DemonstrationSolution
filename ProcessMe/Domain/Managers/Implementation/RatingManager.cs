using AutoMapper;
using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class RatingManager : IRatingManager
    {
        private readonly IRatingRepo _repo;
        private readonly IMapper _mapper;
        public RatingManager(IRatingRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Guid> Create(RatingForCreationDto ratingRequest)
        {
            //Rating result = Rating.FromRatingRequest(ratingRequest);
            Rating result = _mapper.Map<Rating>(ratingRequest);
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

        public async Task Update(Guid id, RatingForCreationDto ratingRequest)
        {
            Rating result = Rating.FromRatingRequestAndId(id, ratingRequest);
            await _repo.Update(result);
        }
    }
}
