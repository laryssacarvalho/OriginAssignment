using OriginAssignmentApi.Enums;
using OriginAssignmentApi.Models;
using System.Collections;

namespace OriginAssignmentApiTest.IntegrationTests.Data
{
    public class CalculateFinancialScoreRequestValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new CalculateFinancialScoreRequest(1000, 10), FinancialScoreType.Healthy
            };

            yield return new object[] {
                new CalculateFinancialScoreRequest(1000, 30), FinancialScoreType.Medium
            };

            yield return new object[] {
                new CalculateFinancialScoreRequest(1000, 80), FinancialScoreType.Low
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
