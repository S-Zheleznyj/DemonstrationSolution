using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetItem(Guid id);
        Task<Guid> Create(UserRequest user);
        Task<IEnumerable<User>> GetItems();
        Task Update(User user);
    }
}
