using NUnit.Framework;
using StateCensusAnalyser.POCO;
using StateCensusAnalyser;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        static string indiaStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indiaStateCensusFilePath = @"C:\Users\PC\source\repos\StateCensusAnalyser\CensusAnalyserTest\CSV Files\IndiaStateCensusData.csv";
        static string indiaStateCodeFilePath = @"C:\Users\PC\source\repos\StateCensusAnalyser\CensusAnalyserTest\CSV Files\IndiaStateCode.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\PC\source\repos\StateCensusAnalyser\CensusAnalyserTest\CSV Files\IndiaState.csv";
        static string wrongIndianCensusFilePath = @"C:\Users\PC\source\repos\StateCensusAnalyser\CensusAnalyserTest\CSV Files\IndiaStateCensusData.txt";
        static string wrongDemiliterIndianCensusFile = @"C:\Users\PC\source\repos\StateCensusAnalyser\CensusAnalyserTest\CSV Files\DelimiterIndiaStateCensusData.csv";
        static string wrongHeaderIndianStateCensusFile = @"C:\Users\PC\source\repos\StateCensusAnalyser\CensusAnalyserTest\CSV Files\WrongIndiaStateCensusData.csv";

        CensusAnalyser censusAnalyser;

        Dictionary<string, CensusDTO> toatlRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new StateCensusAnalyser.CensusAnalyser();
            toatlRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 1.1
        /// Givens the india census data when readed should return census data.
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenReaded_ShouldReturnCensusData()
        {
            toatlRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCensusFilePath, indiaStateCensusHeaders);
            Assert.AreEqual(29, toatlRecord.Count);
        }

        /// <summary>
        /// TC 1.2
        /// Givens the wrong indian census data file when readed should return exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indiaStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.exceptionType);
        }

        /// <summary>
        /// TC 1.3
        /// Givens the wrong indian census data file type when readed should return custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianCensusFilePath, indiaStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.exceptionType);
        }

        /// <summary>
        /// TC 1.4
        /// Givens the wrong delimiter indian census file when readed should return exception.
        /// </summary>
        [Test]
        public void GivenWrongDelimiterIndianCensusFile_WhenReaded_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongDemiliterIndianCensusFile, indiaStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.exceptionType);
        }

        [Test]
        public void GivenWrongHeaderFileIndianCensusFile_WhenReaded_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCensusFile, indiaStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.exceptionType);
        }
    }
}