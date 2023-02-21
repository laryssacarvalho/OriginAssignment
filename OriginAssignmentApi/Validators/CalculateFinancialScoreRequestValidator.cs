using FluentValidation;
using OriginAssignmentApi.Models;

namespace OriginAssignmentApi.Validators
{
    public class CalculateFinancialScoreRequestValidator : AbstractValidator<CalculateFinancialScoreRequest> 
    {
        public CalculateFinancialScoreRequestValidator()
        {
            RuleFor(request => request.AnnualIncome)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Annual income must be greater than 0");

            RuleFor(request => request.MonthlyCosts)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Monthly costs must be greater than 0");
        }
    }
}
