using Microsoft.EntityFrameworkCore;
using ProcessMe.Data.Interfaces;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Implementation
{
    //public class RoleRepo : IRoleRepo
    //{
    //    private readonly ProcessMeDbContext _context;
    //    public RoleRepo(ProcessMeDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task Add(Role item)
    //    {
    //        await _context.Roles.AddAsync(item);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task<Role> GetItem(Guid id)
    //    {
    //        var result = await _context.Roles.FindAsync(id);
    //        return result;
    //    }

    //    public async Task<IEnumerable<Role>> GetItems()
    //    {
    //        return await _context.Roles.ToListAsync();
    //    }

    //    public async Task Update(Role item)
    //    {
    //        _context.Roles.Update(item);
    //        await _context.SaveChangesAsync();
    //    }
    //}
}
