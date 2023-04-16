using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IDepartmentManager
    {
        Task<Department> GetItem(Guid id);
        Task<Guid> Create(DepartmentRequest department);
        Task<IEnumerable<Department>> GetItems();
        Task Update(Department department);
    }
}
