
using System;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Models
{
    public class InsuranceInfoContext : DbContext
    {
        public InsuranceInfoContext(DbContextOptions<InsuranceInfoContext> options)
            : base(options)
        {
            //  Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoveragePlanItem>().HasData(new CoveragePlanItem
            {
                PlanId = 1,
                EligibilityDateFrom = DateTime.Parse("2009-01-01"),
                EligibilityDateTo = DateTime.Parse("2021-01-01"),
                EligibilityCountry = Country.USA,
                PlanName = "Gold"
            },
            new CoveragePlanItem
            {
                PlanId = 2,
                EligibilityDateFrom = DateTime.Parse("2005-01-01"),
                EligibilityDateTo = DateTime.Parse("2023-01-01"),
                EligibilityCountry = Country.Canada,
                PlanName = "Platinum"
            });
            modelBuilder.Entity<CoveragePlanItem>().HasData(new CoveragePlanItem
            {
                PlanId = 3,
                EligibilityDateFrom = DateTime.Parse("2001-01-01"),
                EligibilityDateTo = DateTime.Parse("2026-01-01"),
                EligibilityCountry = Country.Others,
                PlanName = "Silver"
            });
            modelBuilder.Entity<RateChartItem>().HasData(new RateChartItem
            {
                PlanId = 1,
                Gender = "M",
                CuttoffAge = 41,
                NetPrice = 1000,
                RateId = 1

            },
            new RateChartItem
            {
                PlanId = 1,
                Gender = "M",
                CuttoffAge = 200,
                NetPrice = 2000,
                RateId = 2

            },
            new RateChartItem
            {
                PlanId = 1,
                Gender = "F",
                CuttoffAge = 41,
                NetPrice = 1200,
                RateId = 3

            },
            new RateChartItem
            {
                PlanId = 1,
                Gender = "F",
                CuttoffAge = 200,
                NetPrice = 2500,
                RateId = 4

            },
            new RateChartItem
            {
                PlanId = 3,
                Gender = "M",
                CuttoffAge = 41,
                NetPrice = 1500,
                RateId = 5

            },
            new RateChartItem
            {
                PlanId = 3,
                Gender = "M",
                CuttoffAge = 200,
                NetPrice = 2600,
                RateId = 6

            },
           new RateChartItem
           {
               PlanId = 3,
               Gender = "F",
               CuttoffAge = 41,
               NetPrice = 1900,
               RateId = 7

           },
            new RateChartItem
            {
                PlanId = 3,
                Gender = "F",
                CuttoffAge = 200,
                NetPrice = 2800,
                RateId = 8

            },
            new RateChartItem
            {
                PlanId = 2,
                Gender = "M",
                CuttoffAge = 41,
                NetPrice = 1900,
                RateId = 9

            },
            new RateChartItem
            {
                PlanId = 2,
                Gender = "M",
                CuttoffAge = 200,
                NetPrice = 2900,
                RateId = 10

            },
            new RateChartItem
            {
                PlanId = 2,
                Gender = "F",
                CuttoffAge = 41,
                NetPrice = 2100,
                RateId = 11

            },
            new RateChartItem
            {
                PlanId = 2,
                Gender = "F",
                CuttoffAge = 200,
                NetPrice = 3200,
                RateId = 12

            });
        }
        public DbSet<CoveragePlanItem> CoveragePlans { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<RateChartItem> RateCharts { get; set; }

        public DbSet<ContractItem> ContractItems { get; set; }
    }
}