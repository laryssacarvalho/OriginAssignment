using Microsoft.AspNetCore.Mvc;
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
            var result = _sut.CalculateScore(request) as ObjectResult;
            //var result = await _sut.GetAllAsync(CancellationToken.None) as ObjectResult;
            var response = result.Value as CalculateFinancialScoreResponse;

            //Assert
            _mocker.GetMock<IFinancialScoreService>()
                .Verify(x => x.CalculateFinancialScore(It.Is<double>(x => x == request.AnnualIncome), It.Is<double>(x => x == request.MonthlyCosts)), Times.Once);            
            Assert.Equal(FinancialScoreType.Healthy, response.Score);
        }
    }
}
