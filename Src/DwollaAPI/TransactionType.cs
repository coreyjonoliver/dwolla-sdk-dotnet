namespace Dwolla.API
{
    /// <summary>
    /// Dwolla Transaction types.
    /// </summary>
    public sealed class TransactionType : Enumeration<TransactionType>
    {
        /// <summary>
        /// Money sent transaction type.
        /// </summary>
        public static readonly TransactionType MONEYSENT = new TransactionType("money_sent");

        /// <summary>
        /// Money recieved transaction type.
        /// </summary>
        public static readonly TransactionType MONEYRECIEVED = new TransactionType("money_recieved");

        /// <summary>
        /// Deposit transaction type.
        /// </summary>
        public static readonly TransactionType DEPOSIT = new TransactionType("deposit");

        /// <summary>
        /// Withdrawal transaction type.
        /// </summary>
        public static readonly TransactionType WITHDRAWAL = new TransactionType("withdrawal");

        /// <summary>
        /// Fee transaction type.
        /// </summary>
        public static readonly TransactionType FEE = new TransactionType("fee");

        private TransactionType(string value)
            : base(value)
        {
        }

        private TransactionType(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="TransactionType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TransactionType(string value)
        {
            return Convert(value, s => new TransactionType(s));
        }
    }
}