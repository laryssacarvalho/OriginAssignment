using Microsoft.AspNetCore.Mvc;
using OriginAssignmentApi.Models;
using OriginAssignmentApi.Services;

namespace OriginAssignmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialScoreController : ControllerBase
    {
        private readonly IFinancialScoreService _service;

        public FinancialScoreController(IFinancialScoreService service)
        {
            _service = service;
        }

        [HttpPost(Name = "CalculateFinancialScore")]
        public IActionResult CalculateScore([FromBody] CalculateFinancialScoreRequest request)
        {            
            var score = _service.CalculateFinancialScore(request.AnnualIncome, request.MonthlyCosts);
            
            return Ok(new CalculateFinancialScoreResponse(score));                        
        }
    }
}
