using OriginAssignmentApi.Enums;

namespace OriginAssignmentApi.Services
{
    public class FinancialScoreService : IFinancialScoreService
    {
        private const double _lowScorePercentage = 0.75;
        private const double _mediumScorePercentage = 0.25;
        public FinancialScoreType CalculateFinancialScore(double annualIncome, double monthlyCosts)
        {
            var taxOverIncome = annualIncome * 0.08;
            var annualCosts = monthlyCosts * 12 + taxOverIncome;

            var annualCostsPercentage = annualCosts / annualIncome;

            if (annualCostsPercentage > _lowScorePercentage)
                return FinancialScoreType.Low;
            else if (annualCostsPercentage > _mediumScorePercentage)
                return FinancialScoreType.Medium;

            return FinancialScoreType.Healthy;
        }
    }
}
