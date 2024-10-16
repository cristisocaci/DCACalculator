namespace DCACalculator.Entities
{
    public class InvestmentPlan
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int MonthlyBugetUsd { get; set; }

        public List<Investment> Investments { get; set; } = [];
    }
}
