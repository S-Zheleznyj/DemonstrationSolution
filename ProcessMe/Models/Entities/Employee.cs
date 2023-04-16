using ProcessMe.Models.Dto;

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
        public Department Department { get; private set; }
        public ICollection<Appeal> Appeals { get; private set; }
        public ICollection<Rating> Ratings { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Employee() { }

        public Employee(EmployeeRequest employeeRequest)
        {
            Id = Guid.NewGuid();
            FirstName = employeeRequest.FirstName;
            LastName = employeeRequest.LastName;
            Email = employeeRequest.Email;
            DepartmentId = employeeRequest.DepartmentId;
            UserId = employeeRequest.UserId;
        }

        internal static Employee FromEmployeeRequest(EmployeeRequest employeeRequest)
        {
            return new(employeeRequest);
        }
    }
}
