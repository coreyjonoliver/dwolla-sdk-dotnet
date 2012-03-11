namespace Dwolla.API
{
    /// <summary>
    /// Dwolla Account types.
    /// </summary>
    public sealed class AccountInformationType : Enumeration<AccountInformationType>
    {
        /// <summary>
        /// Personal account type.
        /// </summary>
        public static readonly AccountInformationType PERSONAL = new AccountInformationType("Personal", "personal");

        /// <summary>
        /// Commercial account type.
        /// </summary>
        public static readonly AccountInformationType COMMERCIAL= new AccountInformationType("Commercial", "commercial");

        /// <summary>
        /// Nonprofit account type.
        /// </summary>
        public static readonly AccountInformationType NONPROFIT = new AccountInformationType("Nonprofit", "nonprofit");

        private AccountInformationType(string value)
            : base(value)
        {
        }

        private AccountInformationType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="AccountInformationType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator AccountInformationType(string value)
        {
            return Convert(value, s => new AccountInformationType(s));
        }
    }
}