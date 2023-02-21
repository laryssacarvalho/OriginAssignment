using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using OriginAssignmentApi.Controllers;
using OriginAssignmentApi.Enums;
using OriginAssignmentApi.Models;
using OriginAssignmentApi.Services;
using OriginAssignmentApi.Validators;
using System.Net;

namespace OriginAssignmentApiTest.Controllers
{
    public class FinancialScoreControllerTest
    {
        private readonly FinancialScoreController _sut;
        private readonly AutoMocker _mocker;
        public FinancialScoreControllerTest()
        {
            _mocker = new AutoMocker();
            var validator = new CalculateFinancialScoreRequestValidator();
            
            _mocker.Use<IValidator<CalculateFinancialScoreRequest>>(validator);

            _sut = _mocker.CreateInstance<FinancialScoreController>();
        }

        [Fact]
        public void CalculateScore_ShouldReturnOkAndCallService_WhenRequestIsSent()
        {
            //Arrange
            var request = new CalculateFinancialScoreRequest(1000, 10);

            //Act
            var result = _sut.CalculateScore(request) as ObjectResult;
            var response = result.Value as CalculateFinancialScoreResponse;

            //Assert
            _mocker.GetMock<IFinancialScoreService>()
                .Verify(x => x.CalculateFinancialScore(It.Is<double>(x => x == request.AnnualIncome), It.Is<double>(x => x == request.MonthlyCosts)), Times.Once);            
            Assert.Equal(FinancialScoreType.Healthy, response.Score);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void CalculateScore_ShouldReturnBadRequest_WhenRequestIsNull()
        {
            //Arrange
            var expectedErrorMessage = "You must inform your annual income and monthly costs";

            //Act
            var result = _sut.CalculateScore(null) as ObjectResult;
            var response = result.Value as ApiErrorResponseModel;

            //Assert
            _mocker.GetMock<IFinancialScoreService>()
                .Verify(x => x.CalculateFinancialScore(It.IsAny<double>(), It.IsAny<double>()), Times.Never);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Contains(expectedErrorMessage, response.Errors);
        }

        [Fact]
        public void CalculateScore_ShouldReturnBadRequest_WhenRequestIsInvalid()
        {
            //Arrange
            var request = new CalculateFinancialScoreRequest(0, 0);
            var expectedErrorMessages = new string[] { "Annual income must be greater than 0", "Monthly costs must be greater than 0" };
            
            //Act
            var result = _sut.CalculateScore(request) as ObjectResult;
            var response = result.Value as ApiErrorResponseModel;

            //Assert
            _mocker.GetMock<IFinancialScoreService>()
                .Verify(x => x.CalculateFinancialScore(It.IsAny<double>(), It.IsAny<double>()), Times.Never);

            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Contains(expectedErrorMessages.First(), response.Errors);
            Assert.Contains(expectedErrorMessages.Last(), response.Errors);
        }

        [Fact]
        public void CalculateScore_ShouldReturnInternalServerError_WhenUnexpectedExceptionIsThrown()
        {
            //Arrange
            var request = new CalculateFinancialScoreRequest(1000, 10);
            var expectedErrorMessage = $"An unexpected error occurred. Exception error";
            
            _mocker.GetMock<IFinancialScoreService>()
                .Setup(x => x.CalculateFinancialScore(It.IsAny<double>(), It.IsAny<double>()))
                .Throws(new Exception("Exception error"));

            //Act
            var result = _sut.CalculateScore(request) as ObjectResult;
            var response = result.Value as ApiErrorResponseModel;

            //Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.Contains(expectedErrorMessage, response.Errors);
        }
    }
}
