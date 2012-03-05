namespace Dwolla.API
{
    public sealed class TransactionStatus
    {
        public static readonly TransactionStatus PROCESSED = new TransactionStatus("processed");
        public static readonly TransactionStatus PENDING = new TransactionStatus("pending");
        public static readonly TransactionStatus CANCELLED = new TransactionStatus("cancelled");
        public static readonly TransactionStatus FAILED = new TransactionStatus("failed");
        public static readonly TransactionStatus RECLAIMED = new TransactionStatus("reclaimed");

        private TransactionStatus(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}