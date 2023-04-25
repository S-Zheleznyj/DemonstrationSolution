namespace ProcessMe.Infrastructure.Extensions
{
    public static class LongExtensions
    {
        public static DateTime UnixTimeStampToDateTime(this long source)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            dateTimeVal = dateTimeVal.AddSeconds(source).ToUniversalTime();

            return dateTimeVal;
        }
    }
}
