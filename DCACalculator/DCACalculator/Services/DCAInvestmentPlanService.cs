using DCACalculator.Entities;
using DCACalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace DCACalculator.Services
{
    public class DCAInvestmentPlanService
    {
        private readonly IDbContextFactory<DCAContext> _dbFactory;

        public DCAInvestmentPlanService(IDbContextFactory<DCAContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task SimulateInvestmentPlanResults(InvestmentPlan investmentPlan, List<Investment> investments)
        {
            using var context = _dbFactory.CreateDbContext();

            var currentDate = investmentPlan.StartDate;
            var eurusd = 1.0863; // TODO: get from api


            var historicalData = (await context.HistoricalData
                .Where(x =>
                    investmentPlan.StartDate <= x.Date && x.Date <= investmentPlan.EndDate &&
                    investments.Select(y => $"{y.Symbol}/USD").Contains(x.Symbol))
                .ToListAsync())
                .GroupBy(x => x.Date)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Symbol, y => y.Close));

            Dictionary<string, double> amountsInvested = investments.ToDictionary(x => x.Symbol, _ => 0.0);
            Dictionary<string, double> amountsOwned = investments.ToDictionary(x => x.Symbol, _ => 0.0);

            int i = 0;
            while (currentDate <= investmentPlan.EndDate)
            {
                if (!historicalData.TryGetValue(currentDate, out var historicalDataForCurrentDate))
                {
                    currentDate = investmentPlan.StartDate.AddMonths(++i);
                    continue;
                }

                foreach (var investment in investments)
                {
                    if (!historicalDataForCurrentDate.TryGetValue($"{investment.Symbol}/USD", out var closePriceUsd))
                    {
                        continue;
                    }

                    amountsInvested[investment.Symbol] += investment.AmountEur;

                    var amountUsd = investment.AmountEur * eurusd;
                    amountsOwned[investment.Symbol] += amountUsd / closePriceUsd;
                }

                currentDate = investmentPlan.StartDate.AddMonths(++i);
            }

            investmentPlan.InvestmentProgress = amountsInvested.Keys.Select(x => new InvestmentPlanProgress
            {
                Symbol = x,
                AmountInvestedEur = amountsInvested[x],
                AmountOwned = amountsOwned[x]
            }).ToList();

            context.InvestmentPlans.Add(investmentPlan);
            await context.SaveChangesAsync();

        }
    }
}
