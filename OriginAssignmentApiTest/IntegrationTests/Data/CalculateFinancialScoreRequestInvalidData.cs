using OriginAssignmentApi.Enums;
using OriginAssignmentApi.Models;
using System.Collections;

namespace OriginAssignmentApiTest.IntegrationTests.Data
{
    public class CalculateFinancialScoreRequestInvalidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new CalculateFinancialScoreRequest(0, 0)
            };

            yield return new object[] {
                new CalculateFinancialScoreRequest(1000, 0)
            };

            yield return new object[] {
                new CalculateFinancialScoreRequest(0, 80)
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
