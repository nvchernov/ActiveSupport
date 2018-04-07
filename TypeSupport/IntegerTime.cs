namespace TypeSupport
{
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="int"/> for <see cref="TimeSpan"/> conversion.
    /// </summary>
    public static class IntegerTime
    {
        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in second.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in second.</returns>
        public static TimeSpan Second(this int source)
        {
            return new TimeSpan(0, 0, source);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in seconds.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in seconds.</returns>
        public static TimeSpan Seconds(this int source)
        {
            return new TimeSpan(0, 0, source);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in minute.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in minute.</returns>
        public static TimeSpan Minute(this int source)
        {
            return new TimeSpan(0, source, 0);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in minutes.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in minutes.</returns>        
        public static TimeSpan Minutes(this int source)
        {
            return new TimeSpan(0, source, 0);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in hour.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in hour.</returns>        
        public static TimeSpan Hour(this int source)
        {
            return new TimeSpan(source, 0, 0);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in hours.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in hours.</returns>        
        public static TimeSpan Hours(this int source)
        {
            return new TimeSpan(source, 0, 0);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in day.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in day.</returns>
        public static TimeSpan Day(this int source)
        {
            return new TimeSpan(source, 0, 0, 0);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in days.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in days.</returns>
        public static TimeSpan Days(this int source)
        {
            return new TimeSpan(source, 0, 0, 0);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in week.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in week.</returns>
        public static TimeSpan Week(this int source)
        {
            return (source * 7).Days();
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> in weeks.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns a <see cref="TimeSpan"/> in weeks.</returns>
        public static TimeSpan Weeks(this int source)
        {
            return (source * 7).Days();
        }

    }
}
