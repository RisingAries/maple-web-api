using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class RateChartContext : DbContext
    {
        public RateChartContext (DbContextOptions<RateChartContext> options)
            : base(options)
        {
        }

        public DbSet<RateChartItem> RateChartItem { get; set; }
    }
