using System.ComponentModel.DataAnnotations;

namespace OriginAssignmentApi.Models
{
    public class CalculateFinancialScoreRequest
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Must be greater than 0")]
        public double AnnualIncome { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Must be greater than 0")]
        public double MonthlyCosts { get; set; }
        public CalculateFinancialScoreRequest(double annualIncome, double monthlyCosts)
        {
            AnnualIncome = annualIncome;
            MonthlyCosts = monthlyCosts;
        }
    }
}
