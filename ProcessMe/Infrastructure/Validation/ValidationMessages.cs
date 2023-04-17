namespace ProcessMe.Infrastructure.Validation
{
    public static class ValidationMessages
    {
        public const string EmailError = "Passed email has wrong format";
        public const string EmptyStringError = "This field must not be empty";
        public const string NeedEmailWhenNotPhone = "Please, enter phone or email";
    }
}
