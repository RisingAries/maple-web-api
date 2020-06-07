using System;
using Microsoft.EntityFrameworkCore;

public class CoveragePlanContext : DbContext
{
    public CoveragePlanContext(DbContextOptions<CoveragePlanContext> options)
        : base(options)
    {
    }

    public DbSet<CoveragePlanItem> CoveragePlanItem { get; set; }
}
