using Microsoft.EntityFrameworkCore;
using ProcessMe.Data.Interfaces;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Implementation
{
    public class RatingRepo : IRatingRepo
    {
        private readonly ProcessMeDbContext _context;
        public RatingRepo(ProcessMeDbContext context)
        {
            _context = context;
        }
        public async Task Add(Rating item)
        {
            await _context.Ratings.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Rating> GetItem(Guid id)
        {
            var result = await _context.Ratings.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Rating>> GetItems()
        {
            return await _context.Ratings.ToListAsync();
        }

        public async Task Update(Rating item)
        {
            _context.Ratings.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
