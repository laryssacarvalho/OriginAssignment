using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OriginAssignmentApi.Enums;
using OriginAssignmentApi.Models;
using OriginAssignmentApiTest.IntegrationTests.Data;
using System.Net;
using System.Net.Http.Json;

namespace OriginAssignmentApiTest.IntegrationTests
{
    public class FinancialScoreTests
    : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FinancialScoreTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }      

        [Theory]
        [ClassData(typeof(CalculateFinancialScoreRequestValidData))]
        public async Task CalculateFinancialScore_ShouldReturnOkAndCalculatedScore_WhenPassingValidInput(CalculateFinancialScoreRequest input, FinancialScoreType expectedScore)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/FinancialScore", input);

            var responseString = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonConvert.DeserializeObject<CalculateFinancialScoreResponse>(responseString);
            
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(expectedScore, deserializedResponse.Score);
        }

        [Theory]
        [ClassData(typeof(CalculateFinancialScoreRequestInvalidData))]
        public async Task CalculateFinancialScore_ShouldReturnBadRequestStatus_WhenPassingInvalidInput(CalculateFinancialScoreRequest input)
        {            
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/FinancialScore", input);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
