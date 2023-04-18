using Microsoft.EntityFrameworkCore;
using ProcessMe.Data.Interfaces;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Implementation
{
    //public class UserRepo : IUserRepo
    //{
    //    private readonly ProcessMeDbContext _context;
    //    public UserRepo(ProcessMeDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task Add(User item)
    //    {
    //        await _context.Users.AddAsync(item);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task<User> GetItem(Guid id)
    //    {
    //        var result = await _context.Users.FindAsync(id);
    //        return result;
    //    }

    //    public async Task<IEnumerable<User>> GetItems()
    //    {
    //        return await _context.Users.ToListAsync();
    //    }

    //    public async Task Update(User item)
    //    {
    //        _context.Users.Update(item);
    //        await _context.SaveChangesAsync();
    //    }
    //}
}
