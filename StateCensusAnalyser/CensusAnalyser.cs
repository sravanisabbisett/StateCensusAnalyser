using StateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyser
{
    public class CensusAnalyser
    {
        //enum for creating instance for multiple countries
        public enum Country
        {
            INDIA,
            US
        }
        // Dictionary to store the data from the CSV files
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        public Dictionary<string,CensusDTO> LoadCensusData(Country country,string csvFilePath,string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
