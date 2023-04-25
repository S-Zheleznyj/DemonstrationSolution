namespace ProcessMe.Models.DTOs.Outgoing
{
    public class AuthResult : OutgoingResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
