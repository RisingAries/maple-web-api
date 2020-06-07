using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Models
{
    public class ContractContext : DbContext
    {
        public ContractContext(DbContextOptions<ContractContext> options)
            : base(options)
        {
        }

        public DbSet<ContractItem> ContractItems { get; set; }
    }
}