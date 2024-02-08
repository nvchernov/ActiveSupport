using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveSupport
{

    public static class ExceptionExtensions
    {


        private const int internalMaxDeep = 5;
        /// <summary>
        /// Detailed info about exception. Useful to use for logs and etc.
        /// </summary>
        public static string DetailedMessage(this Exception ex, int maxDeep = internalMaxDeep)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var counter = 0;

            var curEx = ex;
            while (curEx != null && counter <= maxDeep)
            {
                stringBuilder.Append($"{curEx.Message} {curEx.StackTrace}\r\n");

                curEx = curEx.InnerException;

                counter++;
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Gets <see cref="maxDeep"/> inner exeptions as array 
        /// </summary>
        public static Exception[] GetInnerExcepptions(this Exception ex, int maxDeep = internalMaxDeep)
        {
            if (ex is null)
                return new Exception[0];

            List<Exception> result = new List<Exception>();
            var counter = 0;

            var curEx = ex.InnerException;
            while (curEx != null && counter <= maxDeep)
            {
                result.Add(curEx);
                curEx = curEx.InnerException;

                counter++;

            }

            return result.ToArray();
        }


    }
}

