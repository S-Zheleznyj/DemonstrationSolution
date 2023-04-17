using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(Guid id);
        Task<Guid> Create(EmployeeForCreationDto employee);
        Task<IEnumerable<Employee>> GetItems();
        Task Update(Guid id, EmployeeForCreationDto employee);
    }
}
