namespace Dwolla.API
{
    /// <summary>
    /// Dwolla scopes.
    /// </summary>
    public sealed class Scope : Enumeration<Scope>
    {
        /// <summary>
        /// Balance scope.
        /// </summary>
        public static readonly Scope BALANCE = new Scope("Balance");

        /// <summary>
        /// Contacts scope.
        /// </summary>
        public static readonly Scope CONTACTS = new Scope("Contacts");

        /// <summary>
        /// Transactions scope.
        /// </summary>
        public static readonly Scope TRANSACTIONS = new Scope("Transactions");

        /// <summary>
        /// Send scope.
        /// </summary>
        public static readonly Scope SEND = new Scope("Send");

        /// <summary>
        /// Request scope.
        /// </summary>
        public static readonly Scope REQUEST = new Scope("Request");

        /// <summary>
        /// AccountInfoFull scope.
        /// </summary>
        public static readonly Scope ACCOUNTINFOFULL = new Scope("AccountInfoFull");

        private Scope(string value)
            : base(value)
        {
        }

        private Scope(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Scope"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Scope(string value)
        {
            return Convert(value, s => new Scope(s));
        }
    }
}