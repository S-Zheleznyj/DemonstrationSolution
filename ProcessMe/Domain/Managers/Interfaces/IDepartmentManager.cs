using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Interfaces
{
    public interface IDepartmentManager
    {
        Task<Department> GetItem(Guid id);
        Task<Guid> Create(DepartmentForCreationDto department);
        Task<IEnumerable<Department>> GetItems();
        Task Update(Guid id, DepartmentForCreationDto department);
    }
}
