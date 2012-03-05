namespace Dwolla.API
{
    public sealed class UserType
    {
        public static readonly UserType DWOLLA = new UserType("Dwolla"); 
        public static readonly UserType FACEBOOK = new UserType("Facebook");
        public static readonly UserType TWITTER = new UserType("Twitter");
        public static readonly UserType EMAIL = new UserType("Email");
        public static readonly UserType PHONE = new UserType("Phone");

        private UserType(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}