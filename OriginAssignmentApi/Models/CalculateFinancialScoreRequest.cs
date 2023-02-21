using System.ComponentModel.DataAnnotations;

namespace OriginAssignmentApi.Models
{
    public class CalculateFinancialScoreRequest
    {
        public double AnnualIncome { get; set; }
        
        public double MonthlyCosts { get; set; }
        public CalculateFinancialScoreRequest(double annualIncome, double monthlyCosts)
        {
            AnnualIncome = annualIncome;
            MonthlyCosts = monthlyCosts;
        }
    }
}
