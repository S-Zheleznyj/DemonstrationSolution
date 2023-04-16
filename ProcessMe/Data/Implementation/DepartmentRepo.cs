using Microsoft.EntityFrameworkCore;
using ProcessMe.Data.Interfaces;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ProcessMeDbContext _context;
        public DepartmentRepo(ProcessMeDbContext context)
        {
            _context = context;
        }
        public async Task Add(Department item)
        {
            await _context.Departments.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Department> GetItem(Guid id)
        {
            var result = await _context.Departments.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Department>> GetItems()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task Update(Department item)
        {
            _context.Departments.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
