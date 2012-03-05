namespace Dwolla.API
{
    public sealed class TransactionStatType
    {
        public static readonly TransactionStatType TRANSACTIONSCOUNT = new TransactionStatType("TransactionsCount");
        public static readonly TransactionStatType TRANSACTIONSTOTAL = new TransactionStatType("TransactionsTotal");

        private TransactionStatType(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}