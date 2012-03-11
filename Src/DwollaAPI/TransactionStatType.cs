namespace Dwolla.API
{
    /// <summary>
    /// Dwolla Transaction Stats types.
    /// </summary>
    public sealed class TransactionStatType : Enumeration<TransactionStatType>
    {
        /// <summary>
        /// Transaction count type.
        /// </summary>
        public static readonly TransactionStatType TRANSACTIONSCOUNT = new TransactionStatType("TransactionsCount");

        /// <summary>
        /// Transaction total type.
        /// </summary>
        public static readonly TransactionStatType TRANSACTIONSTOTAL = new TransactionStatType("TransactionsTotal");

        private TransactionStatType(string value)
            : base(value)
        {
        }

        private TransactionStatType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="TransactionStatType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TransactionStatType(string value)
        {
            return Convert(value, s => new TransactionStatType(s));
        }
    }
}