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

        internal static Rating FromDepartmentRequest(RatingRequest ratingRequest)
        {
            Rating rating = new(ratingRequest);
            rating.Id = Guid.NewGuid();
            return rating;
        }

        internal static Rating FromDepartmentRequestAndId(Guid id, RatingRequest ratingRequest)
        {
            Rating rating = new(ratingRequest);
            rating.Id = id;
            return rating;
        }
    }
}
