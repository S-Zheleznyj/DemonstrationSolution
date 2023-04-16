using Microsoft.EntityFrameworkCore;
using ProcessMe.Data.Interfaces;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Implementation
{
    public class AppealRepo : IAppealRepo
    {
        private readonly ProcessMeDbContext _context;
        public AppealRepo(ProcessMeDbContext context)
        {
            _context = context;
        }
        public async Task Add(Appeal item)
        {
            await _context.Appeals.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Appeal> GetItem(Guid id)
        {
            var result = await _context.Appeals.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Appeal>> GetItems()
        {
            return await _context.Appeals.ToListAsync();
        }

        public async Task Update(Appeal item)
        {
            _context.Appeals.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
