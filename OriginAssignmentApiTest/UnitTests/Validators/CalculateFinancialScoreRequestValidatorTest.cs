using OriginAssignmentApi.Models;
using OriginAssignmentApi.Validators;

namespace OriginAssignmentApiTest.UnitTests.Validators
{
    public class CalculateFinancialScoreRequestValidatorTest
    {
        private readonly CalculateFinancialScoreRequestValidator _sut = new();

        [Theory]
        [InlineData(0,0)]
        [InlineData(1,0)]
        [InlineData(0,1)]
        public void Validate_ShouldReturnFalse_WhenRequestIsInvalid(double annualIncome, double monthlyCosts)
        {
            //Arrange            
            var request = new CalculateFinancialScoreRequest(annualIncome, monthlyCosts);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Validate_ShouldReturnTrue_WhenRequestIsValid()
        {
            //Arrange            
            var request = new CalculateFinancialScoreRequest(1, 1);

            //Act
            var validationResult = _sut.Validate(request);

            //Assert
            Assert.True(validationResult.IsValid);
        }        
    }
}
