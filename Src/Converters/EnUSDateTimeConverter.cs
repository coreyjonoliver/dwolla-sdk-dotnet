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
    /// Converts a date-string in standard en-US (e.g. 8/29/2011 1:17:35 PM) to a <see cref="DateTime"/> to standard en-US.
    /// </summary>
    public class EnUSDateTimeConverter : DateTimeConverterBase
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
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected token parsing date. Expected String, got {0}.", reader.TokenType));

            string dateText = reader.Value.ToString();

            if (string.IsNullOrEmpty(dateText) && nullable)
                return null;

#if !PocketPC && !NET20
            if (t == typeof(DateTimeOffset))
            {
                    return DateTimeOffset.Parse(dateText);
            }
#endif

             return DateTime.Parse(dateText);
        }
    }
}
