using ProcessMe.Models.Entities;

namespace ProcessMe.Models.Dto
{
    public class RatingRequest
    {
        public double Value { get; set; }
        public string Comment { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
