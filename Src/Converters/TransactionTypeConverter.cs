using System;
using System.Globalization;
using Newtonsoft.Json.Utilities;

namespace Dwolla.API.Converters
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Utilities;

    /// <summary>
    /// Converts a string to a<see cref="TransactionType"/>.
    /// </summary>
    public class TransactionTypeConverter : JsonConverter
    {
        internal static bool IsNullable(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            if (t.IsValueType)
            {
                return IsNullableType(t);
            }

            return true;
        }

        internal static bool IsNullableType(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool nullable = IsNullableType(objectType);
            Type t = (nullable)
              ? Nullable.GetUnderlyingType(objectType)
              : objectType;

            if (reader.TokenType == JsonToken.Null)
            {
                if (!IsNullableType(objectType))
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, "Cannot convert null value to {0}.", objectType));

                return null;
            }

            if (reader.TokenType != JsonToken.String)
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected token parsing contact type. Expected String, got {0}.", reader.TokenType));

            string transactionTypeText = reader.Value.ToString();

            if (string.IsNullOrEmpty(transactionTypeText) && nullable)
                return null;

            if (transactionTypeText == TransactionType.MONEYSENT.Value)
                return TransactionType.MONEYSENT;
            else if (transactionTypeText == TransactionType.MONEYRECIEVED.Value)
                return TransactionType.MONEYRECIEVED;
            else if (transactionTypeText == TransactionType.DEPOSIT.Value)
                return TransactionType.DEPOSIT;
            else if (transactionTypeText == TransactionType.WITHDRAWAL.Value)
                return TransactionType.WITHDRAWAL;
            else if (transactionTypeText == TransactionType.FEE.Value)
                return TransactionType.FEE;
            else
                throw new Exception(string.Format("Unexpected option {0}.", transactionTypeText));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TransactionType);
        }
    }
}
