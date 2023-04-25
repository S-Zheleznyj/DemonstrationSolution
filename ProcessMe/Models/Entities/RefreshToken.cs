namespace ProcessMe.Models.Entities
{
    public class RefreshToken : EntityBase
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; private set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        internal void SetIsUsed()
        {
            IsUsed = true;
        }
    }
}
