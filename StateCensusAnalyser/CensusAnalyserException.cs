using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyser
{
    public class CensusAnalyserException:Exception
    {
        //enum for creating instance for multiple exceptions
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE,INCORRECT_DELIMITER,INCORRECT_HEADER,NO_SUCH_COUNTRY
        }

        public ExceptionType exceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        public CensusAnalyserException(string message,ExceptionType exceptionType) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
