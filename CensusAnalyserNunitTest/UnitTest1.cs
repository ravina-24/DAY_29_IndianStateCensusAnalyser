using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserNunitTest
{
    public class Tests
    {

        #region UC 1 Indian State Census Data
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFiles\IndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFiles\IndianStateCencusData.txt";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFile\WrongIndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFiles\WrongIndiaStateCensusData.csv";
        #endregion UC 1

        #region UC 2 Indian State Code
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFiles\IndiaStateCode.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFiles\IndianStateCode.txt";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Hp\Downloads\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserNunitTest\CSVFils\WrongIndiaStateCode.csv";
        #endregion UC 2

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            #region TC 1.1
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            #endregion TC 1.1

            #region TC 2.1
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
            #endregion TC 2.1
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            #region TC 1.2
            var censusException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            #endregion TC 1.2

            #region TC 2.2
            var stateException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
            #endregion TC 2.2
        }

        [Test]
        public void GivenCorrectCSVFileButWrongType_WhenReaded_ShouldReturnCustomException()
        {
            #region TC 1.3
            var censusException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            #endregion TC 1.3

            #region TC 2.3
            var stateException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
            #endregion TC 2.3
        }

        [Test]
        public void GivenCorrectCSVFileButWrongDelimiter_WhenReaded_ShouldReturnCustomException()
        {
            #region TC 1.4
            var censusException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            #endregion TC 1.4

            #region TC 2.4
            var stateException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
            #endregion TC 2.4
        }

        [Test]
        public void GivenCorrectCSVFileButWrongHeader_WhenReaded_ShouldReturnCustomException()
        {
            #region TC 1.5
            var censusException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, wrongHeaderIndianCensusFilePath));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            #endregion TC 1.5

            #region TC 2.5
            var stateException = Assert.Throws<CensusAnalyserException>
                (() => censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, wrongHeaderStateCodeFilePath));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
            #endregion TC 2.5
        }
    }
}