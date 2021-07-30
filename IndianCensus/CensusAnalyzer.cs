using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianCensusAnalyserProblem
{
    public class CensusAnalyzer : GetCensusAdapter, IStateCensusCsvOperations
    {
        public void LoadCountryCsv(CountryChecker.Country country, string fileCsvPath, string header)
        {
            try
            {
                //Checking the country 
                switch (country)
                {
                    case (CountryChecker.Country.INDIA):
                        {
                            string[] result = GetCensusData(fileCsvPath, header);
                            foreach (var member in result.Skip(1))
                            {
                                //Checks for delimiter 
                                if (!member.Contains(","))
                                    throw new CensusCustomException(CensusCustomException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
                            }
                        }
                        break;
                    default:
                        {
                            throw new CensusCustomException(CensusCustomException.ExceptionType.NO_SUCH_COUNTRY, "NO SUCH COUNTRY");
                        }
                }
            }
            catch (CensusCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}