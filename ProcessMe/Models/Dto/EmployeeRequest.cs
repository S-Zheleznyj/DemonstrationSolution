using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class EmployeeRequest
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public Guid DepartmentId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
