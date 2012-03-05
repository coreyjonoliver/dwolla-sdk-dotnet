namespace Dwolla.API
{
    public sealed class TransactionType
    {
        public static readonly TransactionType MONEYSENT = new TransactionType("money_sent");
        public static readonly TransactionType MONEYRECIEVED = new TransactionType("money_recieved");
        public static readonly TransactionType DEPOSIT = new TransactionType("deposit");
        public static readonly TransactionType WITHDRAWAL = new TransactionType("withdrawal");
        public static readonly TransactionType FEE = new TransactionType("fee");

        private TransactionType(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}