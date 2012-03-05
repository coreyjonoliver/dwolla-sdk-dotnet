namespace Dwolla.API
{
    using System;

    internal class DeserializeException : DwollaAPIException
    {
        public DeserializeException(Type objectType, string objectString)
        {
            this.ObjectType = objectType;
            this.ObjectString = objectString;
        }

        public DeserializeException(Type objectType, string objectString, Exception innerException)
            : base(null, innerException)
        {
            this.ObjectType = objectType;
            this.ObjectString = objectString;
        }

        public Type ObjectType { get; private set; }

        public string ObjectString { get; private set; }

        public override string Message
        {
            get
            {
                return string.Format(
                    "Deserialize Failed.{0}Type:{1}{0}String:{2}",
                    Environment.NewLine,
                    this.ObjectType,
                    this.ObjectString);
            }
        }
    }
}