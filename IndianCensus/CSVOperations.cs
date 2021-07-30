
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyserProblem
{
    //Interface segregation principle
    public interface IStateCensusCsvOperations
    {
        void LoadCountryCsv(CountryChecker.Country country, string fileCsvPath, string header);
    }
    public interface IStateCodeCsvOperations
    {
        void LoadStateCsv(CountryChecker.Country country, string fileCsvPath, string header);

    }
}