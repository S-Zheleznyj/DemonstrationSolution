using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(Guid id);
        Task<Guid> Create(EmployeeRequest employee);
        Task<IEnumerable<Employee>> GetItems();
        Task Update(Employee employee);
    }
}
