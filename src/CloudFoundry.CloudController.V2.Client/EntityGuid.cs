namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Globalization;

    /// <summary>
    /// This is a class that facilitates implicit conversion to string and Guid
    /// for CloudFoundry entity identifiers.
    /// The default value of this class is null.
    /// <remarks>
    /// Even though the metadata key for an entity identifier is 'guid', the API 
    /// documentation defines it as a 'stable id' (http://cloudfoundryjp.github.io/docs/reference/cc-api.html).
    /// There are payload samples in the documentation that are not Guids.
    /// </remarks>
    /// </summary>
    public class EntityGuid
    {
        private string value = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityGuid"/> class.
        /// </summary>
        internal EntityGuid()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityGuid"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal EntityGuid(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityGuid"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal EntityGuid(Guid? value)
        {
            if (value == null)
            {
                value = null;
            }
            else
            {
                this.value = value.ToString();
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="EntityGuid"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="value">The d.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string(EntityGuid value)
        {
            if (value == null)
            {
                return new EntityGuid((string)null).ToString();
            }
            else
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="EntityGuid"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator EntityGuid(string value)
        {
            return EntityGuid.FromString(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="EntityGuid"/> to <see cref="System.Nullable{Guid}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        public static implicit operator Guid?(EntityGuid value)
        {
           if (value == null)
           {
               return new EntityGuid((Guid?)null).ToNullableGuid();
           }
           else
           {
               return value.ToNullableGuid();
           }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Nullable{Guid}"/> to <see cref="EntityGuid"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator EntityGuid(Guid? value)
        {
            return EntityGuid.FromGuid(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="EntityGuid"/> to <see cref="Guid"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Guid(EntityGuid value)
        {
            if (value == null)
            {
                return new EntityGuid((Guid?)null).ToGuid();
            }
            else
            {
                return value.ToGuid();
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Guid"/> to <see cref="EntityGuid"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator EntityGuid(Guid value)
        {
            return EntityGuid.FromGuid(value);
        }

        /// <summary>
        /// Creates an <seealso cref="EntityGuid"/> from a <seealso cref="string"/>.
        /// </summary>
        /// <param name="value">A <seealso cref="string"/></param>
        /// <returns>A new <seealso cref="EntityGuid"/></returns>
        public static EntityGuid FromString(string value)
        {
            return new EntityGuid(value);
        }

        /// <summary>
        /// Creates an <seealso cref="EntityGuid"/> from a <seealso cref="Guid"/>.
        /// </summary>
        /// <param name="value">A <seealso cref="Guid"/></param>
        /// <returns>A new <seealso cref="EntityGuid"/></returns>
        public static EntityGuid FromGuid(Guid? value)
        {
            return new EntityGuid(value);
        }

        /// <summary>
        /// Returns a <see cref="System.Guid" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Guid" /> that represents this instance.
        /// </returns>
        public Guid? ToNullableGuid()
        {
            Guid result = Guid.Empty;

            if (this.value == null)
            {
                return null;
            }
            else if (Guid.TryParse(this.value, out result))
            {
                return result;
            }
            else
            {
                throw new FormatException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    "Could not convert entity identifier '{0}' into a Guid. Try using it as a string.",
                    this.value));
            }
        }

        /// <summary>
        /// Returns a <see cref="System.Guid" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.Guid" /> that represents this instance.
        /// </returns>
        public Guid ToGuid()
        {
            if (this.value == null)
            {
                throw new FormatException("Could not convert a null entity identifier into a Guid. Try using a nullable Guid (Guid?).");
            }
            else
            {
                return (Guid)this.ToNullableGuid();
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.value;
        }
    }
}
