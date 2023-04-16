using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class RatingRequest
    {
        public double Value { get; private set; }
        public string Comment { get; private set; }
        public Guid EmployeeId { get; private set; }
    }
}
