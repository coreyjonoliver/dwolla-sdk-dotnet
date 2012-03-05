namespace Dwolla.API
{
    public sealed class AccountInformationType
    {
        public static readonly AccountInformationType PERSONAL = new AccountInformationType("Personal");
        public static readonly AccountInformationType COMMERCIAL= new AccountInformationType("Commercial");
        public static readonly AccountInformationType NONPROFIT = new AccountInformationType("Nonprofit");

        private AccountInformationType(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}