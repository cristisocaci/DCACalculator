using System.ComponentModel.DataAnnotations;

namespace DCACalculator.Entities
{
    public class Investment
    {
        public int Id { get; set; }
        public required string Ticker { get; set; }
        public int Percentage { get; set; }

        [Required]
        public int InvestmentPlanId { get; set; }
        public virtual InvestmentPlan? InvestmentPlan { get; set; }
    }
}
