namespace Dwolla.API
{
    /// <summary>
    /// Dwolla Contact types.
    /// </summary>
    public sealed class ContactType : Enumeration<ContactType>
    {
        /// <summary>
        /// All contact type.
        /// </summary>
        public static readonly ContactType ALL = new ContactType("All");

        /// <summary>
        /// Twitter contact type.
        /// </summary>
        public static readonly ContactType TWITTER = new ContactType("Twitter");

        /// <summary>
        /// Facebook contact type.
        /// </summary>
        public static readonly ContactType FACEBOOK = new ContactType("Facebook");

        /// <summary>
        /// LinkedIn contact type.
        /// </summary>
        public static readonly ContactType LINKEDIN = new ContactType("LinkedIn");

        /// <summary>
        /// Dwolla contact type.
        /// </summary>
        public static readonly ContactType DWOLLA = new ContactType("Dwolla");

        /// <summary>
        /// Foursquare contact type.
        /// </summary>
        public static readonly ContactType FOURSQUARE = new ContactType("Foursquare");

        private ContactType(string value)
            : base(value)
        {
        }

        private ContactType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="ContactType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ContactType(string value)
        {
            return Convert(value, s => new ContactType(s));
        }
    }
}