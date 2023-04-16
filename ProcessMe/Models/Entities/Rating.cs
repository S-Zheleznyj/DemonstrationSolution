using ProcessMe.Models.Dto;

namespace ProcessMe.Models.Entities
{
    /// <summary> Оценка сотрудника</summary>
    public class Rating : EntityBase
    {
        public double Value { get; private set; }
        public string Comment { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public Rating() { }

        public Rating(RatingRequest ratingRequest)
        {
            Value = ratingRequest.Value;
            Comment = ratingRequest.Comment;
            EmployeeId = ratingRequest.EmployeeId;
        }

        internal static Rating FromRatingRequest(RatingRequest ratingRequest)
        {
            return new(ratingRequest);
        }
    }
}
