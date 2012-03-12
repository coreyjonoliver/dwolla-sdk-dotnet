namespace Dwolla.API
{
    /// <summary>
    /// Dwolla TransactionsResult statuses.
    /// </summary>
    public sealed class TransactionsStatusResult : Enumeration<TransactionsStatusResult>
    {
        /// <summary>
        /// Processed transaction status.
        /// </summary>
        public static readonly TransactionsStatusResult PROCESSED = new TransactionsStatusResult("processed");

        /// <summary>
        /// Pending transaction status.
        /// </summary>
        public static readonly TransactionsStatusResult PENDING = new TransactionsStatusResult("pending");

        /// <summary>
        /// Cancelled transaction status.
        /// </summary>
        public static readonly TransactionsStatusResult CANCELLED = new TransactionsStatusResult("cancelled");

        /// <summary>
        /// Failed transaction status.
        /// </summary>
        public static readonly TransactionsStatusResult FAILED = new TransactionsStatusResult("failed");

        /// <summary>
        /// Reclaimed transaction status.
        /// </summary>
        public static readonly TransactionsStatusResult RECLAIMED = new TransactionsStatusResult("reclaimed");

        private TransactionsStatusResult(string value)
            : base(value)
        {
        }

        private TransactionsStatusResult(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="TransactionsStatusResult"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TransactionsStatusResult(string value)
        {
            return Convert(value, s => new TransactionsStatusResult(s));
        }
    }
}