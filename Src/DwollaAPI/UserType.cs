namespace Dwolla.API
{
    /// <summary>
    /// Dwolla User types.
    /// </summary>
    public sealed class UserType : Enumeration<UserType>
    {
        /// <summary>
        /// Dwolla user type.
        /// </summary>
        public static readonly UserType DWOLLA = new UserType("Dwolla"); 

        /// <summary>
        /// Facebook user type.
        /// </summary>
        public static readonly UserType FACEBOOK = new UserType("Facebook");

        /// <summary>
        /// Twitter user type.
        /// </summary>
        public static readonly UserType TWITTER = new UserType("Twitter");

        /// <summary>
        /// Email user type.
        /// </summary>
        public static readonly UserType EMAIL = new UserType("Email");

        /// <summary>
        /// Phone user type.
        /// </summary>
        public static readonly UserType PHONE = new UserType("Phone");

        private UserType(string value)
            : base(value)
        {
        }

        private UserType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="UserType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UserType(string value)
        {
            return Convert(value, s => new UserType(s));
        }
    }
}