using AutoMapper;
using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepo _repo;
        private readonly IMapper _mapper;
        public DepartmentManager(IDepartmentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Guid> Create(DepartmentForCreationDto departmentRequest)
        {
            //Department result = Department.FromDepartmentRequest(departmentRequest);
            Department result = _mapper.Map<Department>(departmentRequest);
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

        public async Task Update(Guid id, DepartmentForCreationDto departmentRequest)
        {
            Department result = Department.FromDepartmentRequestAndId(id, departmentRequest);
            await _repo.Update(result);
        }
    }
}
