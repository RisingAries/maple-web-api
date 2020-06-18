using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maple_web_api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace maple_web_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            var scope = host.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<InsuranceInfoContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Application stopped because of error.");
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseNLog();
                });
    }
}
