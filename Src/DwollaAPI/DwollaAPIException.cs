namespace Dwolla.API
{
    using System;

    public class DwollaAPIException : Exception
    {
        public DwollaAPIException()
        {
        }

        public DwollaAPIException(string message)
            : base(message)
        {
        }

        public DwollaAPIException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}