using StateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateCensusAnalyser
{
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        public Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="StateCensusAnalyser.CensusAnalyserException">File contains wrong Delimiter</exception>
        public Dictionary<string,CensusDTO> LoadCensusData(string csvFilePath,string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            /// Iterating over the censusData array to read the data here skips the header row written in the string array
            /// when loaded from the csv file.
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File contains wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }

                string[] coloumn = data.Split(",");

                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(coloumn[1], new CensusDTO(new StateCodeDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(coloumn[0], new CensusDTO(new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
