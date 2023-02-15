using OriginAssignmentApi.Enums;

namespace OriginAssignmentApi.Services
{
    public interface IFinancialScoreService
    {
        FinancialScoreType CalculateFinancialScore(double annualIncome, double monthlyCosts);
    }
}