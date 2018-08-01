namespace TypeSupport
{
    using System;
    using System.Globalization;

    //TODO methods to check if string can be respresent as numeric

    /// <summary>
    /// Provides extension methods for <see cref="String"/> for conversion and checking to other types.
    /// </summary>
    public static class StringToNumberConversion
    {

        /// <summary>
        /// Default format for numbers (has minimal format for mathimatic like numbers)
        /// </summary>
        internal const NumberStyles DEFAULT_NUMBER_STYLES = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent;

        /// <summary>
        /// Return whether the provided <see cref="String"/> is number with provided <see cref=" NumberStyles"/>.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to check against <paramref name="source"/>.</param>
        /// <returns>Returns true if the <see cref="String"/> can be convert to number with provided <see cref=" NumberStyles"/>, otherwise false.</returns>
        public static bool IsNumber(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            if (source == null)
                return false;

            return
                double.TryParse(source, style, NumberFormatInfo.CurrentInfo, out double parseDouble) ||
                decimal.TryParse(source, style, NumberFormatInfo.CurrentInfo, out decimal parsedDecimal);
        }

        /// <summary>
        /// Convert string <see cref="Int32"/> 
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>Return converted <see cref="Int32"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="source"/> is null.</exception>
        /// <exception cref="FormatException">Throws when <paramref name="source"/> is not correct format.</exception>
        /// <exception cref="OverflowException">Throws when <paramref name="source"/> represents a number less than <see cref="Int32.MinValue"/> or greater than <see cref="Int32.MaxValue"/>.</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="style"/> is not valid <see cref="NumberStyles"/></exception>
        public static int ToInt32(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            return int.Parse(source, style, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Return converted <see cref="Int32"/> if successfully parsed, otherwise null (Nothing in Visual Basic).
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>An instance of <see cref="Int32"/> if successfully parsed, otherwise null (Nothing in Visual Basic).</returns>
        public static int? AsInt32(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            var result = 0;
            return int.TryParse(source, style, NumberFormatInfo.CurrentInfo, out result) ? (int?)result : null;
        }

        /// <summary>
        /// Return converted <see cref="Int64"/>.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>Return converted <see cref="Int64"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="source"/> is null.</exception>
        /// <exception cref="FormatException">Throws when <paramref name="source"/> is not correct format.</exception>
        /// <exception cref="OverflowException">Throws when <paramref name="source"/> represents a number less than <see cref="Int64.MinValue"/> or greater than <see cref="Int64.MaxValue"/>.</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="style"/> is not valid <see cref="NumberStyles"/></exception>
        public static long ToInt64(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            return long.Parse(source, style, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Return converted <see cref="Int64"/> if successfully parsed, otherwise null (Nothing in Visual Basic).
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>An instance of <see cref="Int64"/> if successfully parsed, otherwise null (Nothing in Visual Basic).</returns>
        public static long? AsInt64(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            var result = 0L;
            return long.TryParse(source, style, NumberFormatInfo.CurrentInfo, out result) ? (long?)result : null;
        }

        /// <summary>
        /// Return converted <see cref="Double"/>.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>Return converted <see cref="Double"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="source"/> is null.</exception>
        /// <exception cref="FormatException">Throws when <paramref name="source"/> is not correct format.</exception>
        /// <exception cref="OverflowException">Throws when <paramref name="source"/> represents a number less than <see cref="Double.MinValue"/> or greater than <see cref="Double.MaxValue"/>.</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="style"/> is not valid <see cref="NumberStyles"/></exception>
        public static double ToDouble(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            Guard.ArgumentNotNull("source", source);

            return double.Parse(source, style, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Return converted <see cref="Double"/> if successfully parsed, otherwise null (Nothing in Visual Basic).
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>An instance of <see cref="Double"/> if successfully parsed, otherwise null (Nothing in Visual Basic).</returns>
        public static double? AsDouble(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            var result = 0.0;
            return double.TryParse(source, style, NumberFormatInfo.CurrentInfo, out result) ? (double?)result : null;
        }

        /// <summary>
        /// Return converted <see cref="Decimal"/>.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>Return converted <see cref="Decimal"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="source"/> is null.</exception>
        /// <exception cref="FormatException">Throws when <paramref name="source"/> is not correct format.</exception>
        /// <exception cref="OverflowException">Throws when <paramref name="source"/> represents a number less than <see cref="Decimal.MinValue"/> or greater than <see cref="Decimal.MaxValue"/>.</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="style"/> is not valid <see cref="NumberStyles"/></exception>
        public static decimal ToDecimal(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            Guard.ArgumentNotNull("source", source);

            return decimal.Parse(source, style, NumberFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Return converted <see cref="Decimal"/> if successfully parsed, otherwise null (Nothing in Visual Basic).
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>An instance of <see cref="Decimal"/> if successfully parsed, otherwise null (Nothing in Visual Basic).</returns>
        public static decimal? AsDecimal(this string source, NumberStyles style = DEFAULT_NUMBER_STYLES)
        {
            var result = 0.0m;
            return decimal.TryParse(source, style, NumberFormatInfo.CurrentInfo, out result) ? (decimal?)result : null;
        }



    }
}
