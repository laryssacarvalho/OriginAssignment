using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OriginAssignmentApi.Models;
using OriginAssignmentApi.Services;
using System.Net;

namespace OriginAssignmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialScoreController : ControllerBase
    {
        private readonly IFinancialScoreService _service;
        private readonly IValidator<CalculateFinancialScoreRequest> _requestValidator;

        public FinancialScoreController(IFinancialScoreService service, IValidator<CalculateFinancialScoreRequest> requestValidator)
        {
            _service = service;
            _requestValidator = requestValidator;
        }

        [HttpPost(Name = "CalculateFinancialScore")]
        public IActionResult CalculateScore([FromBody] CalculateFinancialScoreRequest request)
        {
            try
            {
                if (request is null)
                    return BadRequest(new ApiErrorResponseModel(new string[] { "You must inform your annual income and monthly costs" }));

                var validationResult = _requestValidator.Validate(request);

                if (!validationResult.IsValid)
                    return BadRequest(new ApiErrorResponseModel(validationResult.Errors.Select(x => x.ErrorMessage)));

                var score = _service.CalculateFinancialScore(request.AnnualIncome, request.MonthlyCosts);
                
                return Ok(new CalculateFinancialScoreResponse(score));

            } catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ApiErrorResponseModel(new string[] { $"An unexpected error occurred. {e.Message}" }));
            }

        }
    }
}
