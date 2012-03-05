namespace Dwolla.API
{
    public sealed class Scope
    {
        public static readonly Scope BALANCE = new Scope("Balance");
        public static readonly Scope CONTACTS = new Scope("Contacts");
        public static readonly Scope TRANSACTIONS = new Scope("Transactions");
        public static readonly Scope SEND = new Scope("Send");
        public static readonly Scope REQUEST = new Scope("Request");
        public static readonly Scope ACCOUNTINFOFULL = new Scope("AccountInfoFull");

        private Scope(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}