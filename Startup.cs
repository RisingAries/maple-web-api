using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using maple_web_api.Models;

namespace maple_web_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /* services.AddDbContext<ContractContext>(opt =>
               opt.UseSqlServer("CustomerContext"));
            services.AddDbContext<CustomerContext>(opt =>
                opt.UseSqlServer("CustomerList"));
            services.AddDbContext<CoveragePlanContext>(opt =>
                opt.UseSqlServer("CoveragePlanList")); */

            services.AddMvc().AddMvcOptions(opt => opt.EnableEndpointRouting = false);
            services.AddDbContext<InsuranceInfoContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CustomerContext")));

            services.AddDbContext<CustomerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CustomerContext")));

            services.AddDbContext<CoveragePlanContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CoveragePlanContext")));

            services.AddDbContext<RateChartContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RateChartContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
