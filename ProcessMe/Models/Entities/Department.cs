using ProcessMe.Infrastructure.Enums;
using ProcessMe.Models.DTOs.Incoming;

namespace ProcessMe.Models.Entities
{
    /// <summary> Информация об отделе</summary>
    public class Department : EntityBase
    {

        public DepartmentType Type { get; private set; }
        public int EmployeesCount { get; private set; }
        public ICollection<Employee> Employees { get; set; }
        public Department() { }
        public Department(DepartmentForCreationDto departmentRequest)
        {
            //Id = Guid.NewGuid();
            Type = departmentRequest.Type;
        }

        internal static Department FromDepartmentRequest(DepartmentForCreationDto departmentRequest)
        {
            Department department = new(departmentRequest);
            department.Id = Guid.NewGuid();
            return department;
        }

        internal static Department FromDepartmentRequestAndId(Guid id,DepartmentForCreationDto departmentRequest)
        {
            Department department = new(departmentRequest);
            department.Id = id;
            return department;
        }
    }
}