using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _repo;
        public UserManager(IUserRepo repo)
        {
            _repo = repo;
        }
        public async Task<Guid> Create(UserFroCreationDto userRequest)
        {
            // Сделать JWT
            User result = User.FromUserRequest(userRequest);
            await _repo.Add(result);
            return result.Id;
        }

        public async Task<User> GetItem(Guid id)
        {
            return await _repo.GetItem(id);
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return await _repo.GetItems();
        }

        public async Task Update(Guid id, UserFroCreationDto userRequest)
        {
            User result = User.FromUserRequestAndId(id, userRequest);
            await _repo.Update(result);
        }
    }
}
