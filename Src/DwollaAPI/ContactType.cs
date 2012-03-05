namespace Dwolla.API
{
    public sealed class ContactType
    {
        public static readonly ContactType ALL = new ContactType("All");
        public static readonly ContactType TWITTER = new ContactType("Twitter");
        public static readonly ContactType FACEBOOK = new ContactType("Facebook");
        public static readonly ContactType LINKEDIN = new ContactType("LinkedIn");
        public static readonly ContactType DWOLLA = new ContactType("Dwolla");
        public static readonly ContactType FOURSQUARE = new ContactType("Foursquare");

        private ContactType(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}