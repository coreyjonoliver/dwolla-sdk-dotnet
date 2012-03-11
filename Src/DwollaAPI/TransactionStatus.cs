namespace Dwolla.API
{
    /// <summary>
    /// Dwolla Transaction statuses.
    /// </summary>
    public sealed class TransactionStatus : Enumeration<TransactionStatus>
    {
        /// <summary>
        /// Processed transaction status.
        /// </summary>
        public static readonly TransactionStatus PROCESSED = new TransactionStatus("processed");

        /// <summary>
        /// Pending transaction status.
        /// </summary>
        public static readonly TransactionStatus PENDING = new TransactionStatus("pending");

        /// <summary>
        /// Cancelled transaction status.
        /// </summary>
        public static readonly TransactionStatus CANCELLED = new TransactionStatus("cancelled");

        /// <summary>
        /// Failed transaction status.
        /// </summary>
        public static readonly TransactionStatus FAILED = new TransactionStatus("failed");

        /// <summary>
        /// Reclaimed transaction status.
        /// </summary>
        public static readonly TransactionStatus RECLAIMED = new TransactionStatus("reclaimed");

        private TransactionStatus(string value)
            : base(value)
        {
        }

        private TransactionStatus(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="TransactionStatus"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TransactionStatus(string value)
        {
            return Convert(value, s => new TransactionStatus(s));
        }
    }
}