namespace TypeSupport
{
    using System;

    /// <summary>
    /// Provide access methods for <see cref="string"/>.
    /// </summary>
    public static class StringAccess
    {
        /// <summary>
        /// Analog of Char.IsWhitespace of <see cref="System.Char"/>
        /// </summary>
        /// <param name="ch">Some char value</param>
        /// <returns></returns>
        private static bool IsWhiteSpaceInternal(char ch)
        {
            switch (ch)
            {

                case '\u0020': //Space
                case '\u00A0': //No-Break Space
                case '\u1680': //Ogham Space Mark
                case '\u2000': //En Quad
                case '\u2001': //Em Quad

                case '\u2002': //En Space
                case '\u2003': //Em Space
                case '\u2004': //Three-Per-Em Space
                case '\u2005': //Four-Per-Em Space
                case '\u2006': //Six-Per-Em Space

                case '\u2007': //Figure Space
                case '\u2008': //Punctuation Space
                case '\u2009': //Thin Space
                case '\u200A': //Hair Space
                case '\u202F': //Narrow No-Break Space

                case '\u205F': //Medium Mathematical Space
                case '\u3000': //Ideographic Space
                case '\u2028': //Line Separator
                case '\u2029': //Paragraph Separator
                case '\u0009': //Horizontal Tabulation

                case '\u000A': //New Line
                case '\u000B': //Vertical Tabulation
                case '\u000C': //Form Feed
                case '\u000D': //Carriage Return
                case '\u0085': //Next Line
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Replaces all whitespace for a single space also remove any whitespace at beginning and end of string
        /// </summary>
        /// <param name="source">An instance of <see cref="string"/>.</param>
        /// <returns>New <see cref="string"/> without double whitespaces</returns>
        public static string Squish(this string source)
        {
            /*
             * Main idea was found here 
             * 
             * https://www.codeproject.com/Articles/1014073/Fastest-method-to-remove-all-whitespace-from-Strin 
             * 
             * */

            if (source == null)
                return null;

            if (source == string.Empty)
                return string.Empty;

            var isWhitespaceFound = false;

            var len = source.Length;
            var src = source.ToCharArray();
            int dstIdx = 0;

            for (int i = 0; i < len; i++)
            {
                var ch = src[i];

                if (IsWhiteSpaceInternal(ch))
                {
                    if (!isWhitespaceFound)
                    {
                        src[dstIdx++] = ' ';
                        isWhitespaceFound = true;
                    }
                }
                else
                {
                    src[dstIdx++] = ch;
                    isWhitespaceFound = false;
                }
            }

            if (dstIdx == 1 && IsWhiteSpaceInternal(source[0]))
                return string.Empty;

            /* remove whitespaces */

            if (dstIdx > 0 && IsWhiteSpaceInternal(src[dstIdx - 1]))
                dstIdx -= 2;

            if (IsWhiteSpaceInternal(src[0]))
                return new string(src, 1, dstIdx);
            else
                return new string(src, 0, dstIdx);
        }

        /// <summary>
        /// Check whether given <see cref="string"/> is null or empty.
        /// </summary>
        /// <param name="source">An instance of <see cref="string"/>.</param>
        /// <returns>true if <paramref name="source"/> is null or empty, otherwise false.</returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Check whether given <see cref="string"/> is null or empty or only whitespace.
        /// </summary>
        /// <param name="source">An instance of <see cref="string"/>.</param>
        /// <returns>true if <paramref name="source"/> is null or empty or only whitespace, otherwise false.</returns>
        public static bool IsBlank(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// Check whether given <see cref="string"/> is not null or empty or only whitespace.
        /// </summary>
        /// <param name="source">An instance of <see cref="string"/>.</param>
        /// <returns>true if <paramref name="source"/> is null or empty or only whitespace, otherwise false.</returns>
        public static bool IsPresent(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        // TODO make namesapce (like TypeSupport.Neworking) for this type of operations
        /// <summary>
        /// Encode string as url string.
        /// </summary>
        /// <param name="source"><see cref="string"/> instance to encode.</param>
        /// <returns>Encoded url string.</returns>
        public static string UrlEncode(this string source)
        {
            Guard.ArgumentNotNull("source", source);

            return Uri.EscapeDataString(source);
        }

        /// <summary>
        /// Decode url string to original string.
        /// </summary>
        /// <param name="source"><see cref="string"/> instance to decode.</param>
        /// <returns>Original string of url string.</returns>
        public static string UrlDecode(this string source)
        {
            Guard.ArgumentNotNull("source", source);

            return Uri.UnescapeDataString(source.Replace("+", "%20"));
        }


    }
}
