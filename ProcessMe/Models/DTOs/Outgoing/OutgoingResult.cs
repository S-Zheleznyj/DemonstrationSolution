namespace ProcessMe.Models.DTOs.Outgoing
{
    public class OutgoingResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
