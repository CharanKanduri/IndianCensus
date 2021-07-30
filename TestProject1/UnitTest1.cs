using IndianCensusAnalyserProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IndianCensusProject
{
    [TestClass]
    public class UnitTest1
    {
        //Interface
        IStateCensusCsvOperations censusAnalyzer;
        IStateCodeCsvOperations stateCodeCsv;
        GetCensusAdapter getCensusAdapter;

        //Path for Indian State Census
        string censusFilePath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCensusInformation.csv";
        string invalidFileCsvPath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\InvalidCensusFile.csv";
        string invalidFileTypePath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCensusWithInvalidExtension.css";
        string invalidDelimiterFilePath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCensusWithInvalidDelimiter.csv";
        string invalidHeaderFilePath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCensusWithInvalidHeader.csv";

        //Path for state code csv file
        //string stateCodeFilePath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCode.csv";
        //string stateCodeInvalidFilePath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\hfhfhf.csv";
        //string stateCodeInvalidFileTypePath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCensusWithInvalidExtension.css";
        //string stateCodeInvalidFileDelimiterPath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCodeWithInvalidDelimiter.csv";
        //string stateCodeInvalidFileHeaderPath = @"C:\Users\charan kanduri\source\repos\IndianCensusAnalyser\IndianCensus\IndianStateCodeWithInvalidHeader.csv";

        [TestInitialize]
        public void SetUp()
        {
            getCensusAdapter = new GetCensusAdapter();
            censusAnalyzer = new CensusAnalyzer();
            stateCodeCsv = new CsvStateAnalyzer();
        }

        //TC1.1: Count the number of records
        [TestMethod]
        [TestCategory("Given State Census CSV return Count of fields")]
        public void TestMethodToCheckCountOfDataRetrieved()
        {
            int expected = 28;
            string[] result = getCensusAdapter.GetCensusData(censusFilePath, "﻿State,Population,Increase,Area,Density");
            int actual = result.Length - 1;
            Assert.AreEqual(expected, actual);
        }

        //TC1.2:Check whether File exists
        [TestMethod]
        [TestCategory("Check Whether File Exists")]
        public void TestMethodToCheckInvalidFile()
        {
            try
            {
                getCensusAdapter.GetCensusData(invalidFileCsvPath, "State,Population,Increase,Area,Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "File not found!");
            }
        }

        //TC1.3:Check for correct Extension
        [TestMethod]
        [TestCategory("Invalid File Extension")]
        public void TestMethodToCheckInvalidFileExtension()
        {
            try
            {
                getCensusAdapter.GetCensusData(invalidFileTypePath, "State,Population,Increase,Area,Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid file type");
            }
        }
        //TC1.4:Check for proper Delimiter
        [TestMethod]
        [TestCategory("Delimiter Check")]
        public void TestMethodToCheckInvalidDelimiter()
        {
            try
            {
                censusAnalyzer.LoadCountryCsv(CountryChecker.Country.INDIA, invalidDelimiterFilePath, "State-Population-Increase.Area.Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Delimiter");
            }
        }
        //TC1.5: Check for incorrect header
        [TestMethod]
        [TestCategory("Incorrect Header")]
        public void TestMethodToCheckIncorrectHeader()
        {
            try
            {
                censusAnalyzer.LoadCountryCsv(CountryChecker.Country.INDIA, invalidHeaderFilePath, "State,Population,Increase,Area,Density");
            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Header");
            }
        }

    }
}