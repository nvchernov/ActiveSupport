namespace ActiveSupport
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> for from/to conversion.
    /// </summary>
    public static class EnumerableAccess
    {
        /// <summary>
        /// Returns the tail of the element sequence from position.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from.</param>
        /// <param name="index">The index no to start from.</param>
        /// <returns>Returns the tail of the element sequence from position.</returns>
        public static IEnumerable<T> From<T>(this IEnumerable<T> source, int index)
        {
            return source.Skip(index);
        }

        /// <summary>
        /// Returns the beginning of the array up to position.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from.</param>
        /// <param name="index">The index no to stop at.</param>
        /// <returns>Returns the beginning of the array up to position.</returns>
        public static IEnumerable<T> To<T>(this IEnumerable<T> source, int index)
        {
            return source.Take(++index);
        }

        /// <summary>
        /// Determines whether a sequence is empty.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to check for emptiness.</param>
        /// <returns>true if the source sequence is null or contains no elements; otherwise, false.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Seaches for the specified object and returns the zero-based index of the first occurence within the entire <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to find index</param>
        /// <param name="predicate">Predicate containing logic to find index</param>
        /// <returns>Index of the matched element or -1 if nothing found</returns>
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null || predicate == null)
                return -1;

            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    return index;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Seaches for the specified object and returns the zero-based index of the first occurence within the entire <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to find index</param>
        /// <param name="predicate">Predicate containing logic to find index</param>
        /// <returns>Index of the matched element or -1 if nothing found</returns>
        public static int IndexOf(this IEnumerable source, Func<object, bool> predicate)
        {
            if (source == null || predicate == null)
                return -1;

            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    return index;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Check if <paramref name="source"/> is null or has no elements.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An instance of <see cref="IEnumerable"/>.</param>
        /// <returns></returns>
        public static bool IsBlank<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Check if <paramref name="source"/> is not null and has any element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An instance of <see cref="IEnumerable"/>.</param>
        /// <returns></returns>
        public static bool IsPresent<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        /// <summary>
        /// Check if <paramref name="source"/> is null or has no elements.
        /// </summary>
        /// <param name="source">An instance of <see cref="IEnumerable"/>.</param>
        /// <returns></returns>
        public static bool IsBlank(this IEnumerable source)
        {
            return source == null || !source.GetEnumerator().MoveNext();
        }

        /// <summary>
        /// Check if <paramref name="source"/> is not null and has any element.
        /// </summary>
        /// <param name="source">An instance of <see cref="IEnumerable"/>.</param>
        /// <returns></returns>
        public static bool IsPresent(this IEnumerable source)
        {
            return source != null && source.GetEnumerator().MoveNext();
        }
    }
}
