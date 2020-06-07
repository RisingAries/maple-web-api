using System;
using Microsoft.EntityFrameworkCore;

public class CoveragePlanContext : DbContext
{
    public CoveragePlanContext(DbContextOptions<CoveragePlanContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<CoveragePlanItem>().HasData(new CoveragePlanItem
    {
        Id = 1,
        EligibilityDateFrom = DateTime.Parse("2009-01-01"),
        EligibilityDateTo = DateTime.Parse("2021-01-01")
    });

    public DbSet<CoveragePlanItem> CoveragePlanItem { get; set; }
}
