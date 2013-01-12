namespace DwollaApi.Dwolla
{
    public sealed class BankProcessingType : Enumeration<BankProcessingType>
    {
        public static readonly BankProcessingType Fisync = new BankProcessingType("FiSync", "FiSync");

        public static readonly BankProcessingType Ach = new BankProcessingType("ACH", "ACH");

        private BankProcessingType(string value)
            : base(value)
        {
        }

        private BankProcessingType(string name, string value)
            : base(name, value)
        {
        }

        public static implicit operator BankProcessingType(string value)
        {
            return Convert(value, s => new BankProcessingType(s));
        }
    }
}