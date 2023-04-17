using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.Dto;

namespace ProcessMe.Models.Entities
{
    /// <summary> Информация об отделе</summary>
    public class Department : EntityBase
    {

        public DepartmentType Type { get; private set; }
        public int EmployeesCount { get; private set; }
        public ICollection<Employee> Employees { get; private set; }
        public Department() { }
        public Department(DepartmentRequest departmentRequest)
        {
            //Id = Guid.NewGuid();
            Type = departmentRequest.Type;
        }

        internal static Department FromDepartmentRequest(DepartmentRequest departmentRequest)
        {
            Department department = new(departmentRequest);
            department.Id = Guid.NewGuid();
            return department;
        }

        internal static Department FromDepartmentRequestAndId(Guid id,DepartmentRequest departmentRequest)
        {
            Department department = new(departmentRequest);
            department.Id = id;
            return department;
        }
    }
}