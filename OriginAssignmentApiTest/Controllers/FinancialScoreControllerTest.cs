using Moq;
using Moq.AutoMock;
using OriginAssignmentApi.Controllers;
using OriginAssignmentApi.Enums;
using OriginAssignmentApi.Models;
using OriginAssignmentApi.Services;

namespace OriginAssignmentApiTest.Controllers
{
    public class FinancialScoreControllerTest
    {
        private readonly FinancialScoreController _sut;
        private readonly AutoMocker _mocker;
        public FinancialScoreControllerTest()
        {
            _mocker = new AutoMocker();
            _sut = _mocker.CreateInstance<FinancialScoreController>();
        }

        [Fact]
        public void CalculateScore_ShouldCallService_WhenRequestIsSent()
        {
            //Arrange
            var request = new CalculateFinancialScoreRequest(1000, 10);

            //Act
            var result = _sut.CalculateScore(request);

            //Assert
            _mocker.GetMock<IFinancialScoreService>()
                .Verify(x => x.CalculateFinancialScore(It.Is<double>(x => x == request.AnnualIncome), It.Is<double>(x => x == request.MonthlyCosts)), Times.Once);
            Assert.IsType<CalculateFinancialScoreResponse>(result);
            Assert.Equal(FinancialScoreType.Healthy, result.Score);
        }
    }
}
