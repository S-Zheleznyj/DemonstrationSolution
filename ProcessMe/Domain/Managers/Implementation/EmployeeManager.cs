using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _repo;
        public EmployeeManager(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public async Task<Guid> Create(EmployeeRequest employeeRequest)
        {
            Employee result = Employee.FromEmployeeRequest(employeeRequest);
            await _repo.Add(result);
            return result.Id;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return await _repo.GetItem(id);
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            return await _repo.GetItems();
        }

        public async Task Update(Guid id, EmployeeRequest employeeRequest)
        {
            Employee result = Employee.FromEmployeeRequestAndId(id, employeeRequest);
            await _repo.Update(result);
        }
    }
}
