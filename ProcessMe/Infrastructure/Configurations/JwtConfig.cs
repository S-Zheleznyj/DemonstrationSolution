namespace ProcessMe.Infrastructure.Configurations
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public int Lifetime { get; set; }
    }
}
