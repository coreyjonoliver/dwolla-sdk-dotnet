namespace Dwolla.API
{
    /// <summary>
    /// Dwolla TransactionsResult Stats types.
    /// </summary>
    public sealed class TransactionStatsType : Enumeration<TransactionStatsType>
    {
        /// <summary>
        /// TransactionsResult count type.
        /// </summary>
        public static readonly TransactionStatsType TRANSACTIONSCOUNT = new TransactionStatsType("TransactionsCount");

        /// <summary>
        /// TransactionsResult total type.
        /// </summary>
        public static readonly TransactionStatsType TRANSACTIONSTOTAL = new TransactionStatsType("TransactionsTotal");

        private TransactionStatsType(string value)
            : base(value)
        {
        }

        private TransactionStatsType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="TransactionStatsType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TransactionStatsType(string value)
        {
            return Convert(value, s => new TransactionStatsType(s));
        }
    }
}