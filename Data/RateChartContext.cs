using Microsoft.EntityFrameworkCore;

public class RateChartContext : DbContext
{
    public RateChartContext(DbContextOptions<RateChartContext> options)
        : base(options)
    {
    }

    public DbSet<RateChartItem> RateChartItem { get; set; }
}
