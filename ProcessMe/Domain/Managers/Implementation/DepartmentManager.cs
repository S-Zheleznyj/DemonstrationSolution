using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.Dto;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepo _repo;
        public DepartmentManager(IDepartmentRepo repo)
        {
            _repo = repo;
        }
        public async Task<Guid> Create(DepartmentRequest departmentRequest)
        {
            Department result = Department.FromDepartmentRequest(departmentRequest);
            await _repo.Add(result);
            return result.Id;
        }

        public async Task<Department> GetItem(Guid id)
        {
            return await _repo.GetItem(id);
        }

        public async Task<IEnumerable<Department>> GetItems()
        {
            return await _repo.GetItems();
        }

        public async Task Update(Department department)
        {
            await _repo.Update(department);
        }
    }
}
