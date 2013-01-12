//-----------------------------------------------------------------------
// <copyright file="Enumeration.Generic.cs" company="iron9light">
// Copyright (c) 2010 iron9light
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>
// <author>iron9light@gmail.com</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DwollaApi
{
    /// <summary>
    /// The enumeration. Provide more static methods and properties for every concrete enumeration.
    /// </summary>
    /// <typeparam name="T">The type of concrete enumeration.</typeparam>
    public abstract class Enumeration<T> : Enumeration, IEquatable<T>
        where T : Enumeration<T>
    {
        private static IDictionary<string, T> _dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        protected Enumeration(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        protected Enumeration(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Gets the dictionary of value and enumeration.
        /// </summary>
        /// <value>The dictionary.</value>
        protected static IDictionary<string, T> Dictionary
        {
            get
            {
                Initialize();
                return _dictionary;
            }
        }

        #region IEquatable<T> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            return Value == other.Value;
        }

        #endregion

        /// <summary>
        /// Gets all enumerations.
        /// </summary>
        /// <returns>All enumerations</returns>
        public static ICollection<T> GetEnums()
        {
            return Dictionary.Values;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected static void Initialize()
        {
            if (_dictionary == null)
            {
                _dictionary = new Dictionary<string, T>();

                Type type = typeof (T);

                IEnumerable<T> enums =
                    from fieldInfo in
                        type.GetFields(
                            BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly |
                            BindingFlags.GetField)
                    where fieldInfo.FieldType.IsAssignableFrom(type)
                    select fieldInfo.GetValue(null) as T;

                foreach (T @enum in enums)
                {
                    Debug.Assert(@enum != null, "enum cannot be null.");

                    _dictionary[@enum.Value] = @enum;
                }
            }
        }

        /// <summary>
        /// Converts the specified value to this enumeration.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="construct">The constructor function.</param>
        /// <returns>The enumeration.</returns>
        protected static T Convert(string value, Func<string, T> construct)
        {
            T @enum;

            if (!Dictionary.TryGetValue(value, out @enum))
            {
                @enum = construct(value);
            }

            return @enum;
        }
    }
}