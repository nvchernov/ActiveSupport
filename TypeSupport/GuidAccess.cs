namespace TypeSupport
{
    using System;

    public static class GuidAccess
    {
        /// <summary>
        /// Check if <paramref name="source"/> is not null and has no default value.
        /// </summary>
        /// <param name="source">An instance of <see cref="Guid?"/>.</param>
        /// <returns></returns>
        public static bool IsPresent(this Guid? source)
        {
            return source != null && source != default(Guid);
        }

        /// <summary>
        /// Check if <paramref name="source"/> is null or has default value.
        /// </summary>
        /// <param name="source">An instance of <see cref="Guid?"/>.</param>
        /// <returns></returns>
        public static bool IsBlank(this Guid? source)
        {
            return source == null || source == default(Guid);
        }

        /// <summary>
        /// Check if <paramref name="source"/> is not null and has no default value.
        /// </summary>
        /// <param name="source">An instance of <see cref="Guid"/>.</param>
        /// <returns></returns>
        public static bool IsPresent(this Guid source)
        {
            return source != default(Guid);
        }

        /// <summary>
        /// Check if <paramref name="source"/> is null or has default value.
        /// </summary>
        /// <param name="source">An instance of <see cref="Guid"/>.</param>
        /// <returns></returns>
        public static bool IsBlank(this Guid source)
        {
            return source == default(Guid);
        }



    }
}
