using StateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyser
{
    public class CSVAdapterFactory
    {
        /// <summary>
        /// Loads the CSV data.and checking country matches or not
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="StateCensusAnalyser.CensusAnalyserException">No such country</exception>
        public Dictionary<string,CensusDTO> LoadCsvData(CensusAnalyser.Country country,string csvFilePath,string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No such country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
