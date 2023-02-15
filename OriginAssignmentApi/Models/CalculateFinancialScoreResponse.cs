using OriginAssignmentApi.Enums;

namespace OriginAssignmentApi.Models
{
    public class CalculateFinancialScoreResponse
    {        
        public FinancialScoreType Score { get; private set; }
        public CalculateFinancialScoreResponse(FinancialScoreType score)
        {
            Score = score;
        }
    }
}
