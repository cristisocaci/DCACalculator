using System.ComponentModel.DataAnnotations;

namespace DCACalculator.Entities;

public class InvestmentPlanProgress
{
    public int Id { get; set; }

    [Required]
    public int InvestmentPlanId { get; set; }
    public virtual InvestmentPlan? InvestmentPlan { get; set; }

    public required string Symbol { get; set; }
    public double AmountInvestedEur { get; set; }
    public double AmountOwned { get; set; }
}