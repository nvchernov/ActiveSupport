using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ActiveSupport
{
    public static class StopWatchExtensions
    {


        /// <summary>
        /// Checks how many time code takes to execute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stopwatch"></param>
        /// <param name="codeToCheck"></param>
        /// <returns></returns>
        public static T CheckExecutionTime<T>(this Stopwatch stopwatch, Func<T> codeToCheck)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                
                return codeToCheck();
            }
            finally
            {
                stopwatch.Stop();
            }

        }

        /// <summary>
        /// Checks how many time code takes to execute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stopwatch"></param>
        /// <param name="codeToCheck"></param>
        public static void CheckExecutionTime<T>(this Stopwatch stopwatch, Action codeToCheck)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();

                codeToCheck();
            }
            finally
            {
                stopwatch.Stop();
            }

        }

    }

}
