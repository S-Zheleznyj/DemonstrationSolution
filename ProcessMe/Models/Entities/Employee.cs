using ProcessMe.Models.DTOs.Incoming;

namespace ProcessMe.Models.Entities
{
    /// <summary> Информация о сотруднике</summary>
    public class Employee : EntityBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public bool IsBusy { get; private set; }
        public double Rating { get; private set; }
        public Guid DepartmentId { get; private set; }
        public Department Department { get; set; }
        public ICollection<Appeal> Appeals { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public Guid UserId { get; private set; }
        public User User { get; set; }
        public Employee() { }

        public Employee(EmployeeForCreationDto employeeRequest)
        {
            Id = Guid.NewGuid();
            FirstName = employeeRequest.FirstName;
            LastName = employeeRequest.LastName;
            Email = employeeRequest.Email;
            DepartmentId = employeeRequest.DepartmentId;
            UserId = employeeRequest.UserId;
        }

        internal static Employee FromEmployeeRequest(EmployeeForCreationDto employeeRequest)
        {
            Employee employee = new(employeeRequest);
            employee.Id = Guid.NewGuid();
            return employee;
        }

        internal static Employee FromEmployeeRequestAndId(Guid id, EmployeeForCreationDto employeeRequest)
        {
            Employee employee = new(employeeRequest);
            employee.Id = id;
            return employee;
        }
    }
}
