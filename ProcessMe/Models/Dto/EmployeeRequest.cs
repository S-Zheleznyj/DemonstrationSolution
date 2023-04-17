using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class EmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid UserId { get; set; }
    }
}
