
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Models
{
    public class InsuranceInfoContext : DbContext
    {
        public InsuranceInfoContext(DbContextOptions<InsuranceInfoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CoveragePlanItem> CoveragePlans { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<RateChartItem> RateCharts { get; set; }

        public DbSet<ContractItem> ContractItems { get; set; }
    }
}