using AutoMapper;
using ProcessMe.Data.Interfaces;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.Entities;

namespace ProcessMe.Domain.Managers.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Guid> Create(EmployeeForCreationDto employeeRequest)
        {
            //Employee result = Employee.FromEmployeeRequest(employeeRequest);
            Employee result = _mapper.Map<Employee>(employeeRequest);
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

        public async Task Update(Guid id, EmployeeForCreationDto employeeRequest)
        {
            Employee result = Employee.FromEmployeeRequestAndId(id, employeeRequest);
            await _repo.Update(result);
        }
    }
}
