using OriginAssignmentApi.Enums;
using OriginAssignmentApi.Services;

namespace OriginAssignmentApiTest.Services
{
    public class FinancialScoreServiceTest
    {
        private readonly FinancialScoreService _sut;

        public FinancialScoreServiceTest()
        {
            _sut = new();
        }

        [Fact]
        public void CalculateFinancialScore_ShouldReturnLow_WhenAnnualCostsIsGreaterThanExpected()
        {
            //Arrange
            var annualIncome = 1000;
            var monthlyCosts = 80;

            //Act
            var result = _sut.CalculateFinancialScore(annualIncome, monthlyCosts);

            //Assert
            Assert.Equal(FinancialScoreType.Low, result);
        }

        [Fact]
        public void CalculateFinancialScore_ShouldReturnMedium_WhenAnnualCostsIsGreaterThanAndLessOrEqualToExpected()
        {
            //Arrange
            var annualIncome = 1000;
            var monthlyCosts = 30;

            //Act
            var result = _sut.CalculateFinancialScore(annualIncome, monthlyCosts);

            //Assert
            Assert.Equal(FinancialScoreType.Medium, result);
        }

        [Fact]
        public void CalculateFinancialScore_ShouldReturnHealthy_WhenAnnualCostsIsLessThanExpected()
        {
            //Arrange
            var annualIncome = 1000;
            var monthlyCosts = 10;

            //Act
            var result = _sut.CalculateFinancialScore(annualIncome, monthlyCosts);

            //Assert
            Assert.Equal(FinancialScoreType.Healthy, result);
        }
    }
}
