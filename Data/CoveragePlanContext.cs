using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class CoveragePlanContext : DbContext
    {
        public CoveragePlanContext (DbContextOptions<CoveragePlanContext> options)
            : base(options)
        {
        }

        public DbSet<CoveragePlanItem> CoveragePlanItem { get; set; }
    }
