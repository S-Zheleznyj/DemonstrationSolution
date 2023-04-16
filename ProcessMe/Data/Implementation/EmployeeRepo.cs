using Microsoft.EntityFrameworkCore;
using ProcessMe.Data.Interfaces;
using ProcessMe.Models.Entities;

namespace ProcessMe.Data.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ProcessMeDbContext _context;
        public EmployeeRepo(ProcessMeDbContext context)
        {
            _context = context;
        }
        public async Task Add(Employee item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var result = await _context.Employees.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
