using ProcessMe.Models.Entities;

namespace ProcessMe.Models.DTOs.Incoming
{
    public class RatingForCreationDto
    {
        public double Value { get; set; }
        public string Comment { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
