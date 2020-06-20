using System;
using System.Collections.Generic;
using System.Linq;
using maple_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Services
{
    public class InsuranceInfoRepository : IInsuranceInfoRepository
    {
        private readonly InsuranceInfoContext _context;

        public InsuranceInfoRepository(InsuranceInfoContext context)
        {
            _context = context;
        }

        public ContractItem GetContract(int Id)
        {
            return
            _context.ContractItems.Find(Id);
        }

        public IEnumerable<ContractItem> GetContracts()
        {
            return
            _context.ContractItems.ToList();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this._context.Customers.ToList();
        }

        public CoveragePlanItem GetCoveragePlan(int Id)
        {
            return this._context.CoveragePlans.Find(Id);
        }

        public IEnumerable<CoveragePlanItem> GetCoveragePlans()
        {
            return this._context.CoveragePlans.ToList();
        }

        public Customer GetCustomer(int Id)
        {
            return this._context.Customers.Find(Id);
        }

        public RateChartItem GetRate(int Id)
        {
            return this._context.RateCharts.Find(Id);
        }

        public IEnumerable<RateChartItem> GetRates()
        {
            return this._context.RateCharts.Include(rc => rc.CoveragePlan).ToList();
        }
        public Customer GetCustomerByName(string CustomerName)
        {
            return this._context.Customers.Where(c => c.Name == CustomerName).FirstOrDefault();
        }

        public CoveragePlanItem GetCoveragePlan(Country country, System.DateTime DOB)
        {
            return this._context.CoveragePlans.Where(cp =>
               cp.EligibilityCountry == country &&
               cp.EligibilityDateFrom < DOB &&
               cp.EligibilityDateTo > DOB).FirstOrDefault();
        }

        public RateChartItem GetRate(Gender cgender, int age, CoveragePlanItem planType)
        {
            return this._context.RateCharts.Include(rc => rc.CoveragePlan).Where(ch =>
             ch.Gender == cgender
             && ch.CuttoffAge > age &&
            ch.CoveragePlan.PlanId == planType.PlanId).FirstOrDefault();
        }

        public void EditContract(ContractItem contractItem)
        {
            _context.Entry(contractItem).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveContract(ContractItem contractItem)
        {

            _context.ContractItems.Add(contractItem);
            _context.SaveChanges();
        }

        public void DeleteContract(ContractItem contractItem)
        {
            _context.ContractItems.Remove(contractItem);
            _context.SaveChanges();

        }

        public void EditCoveragePlan(int id, CoveragePlanItem coveragePlan)
        {

            _context.Entry(coveragePlan).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void SaveCoveragePlan(CoveragePlanItem coveragePlanItem)
        {
            _context.CoveragePlans.Add(coveragePlanItem);
            _context.SaveChanges();
        }

        public void DeleteCoveragePlan(CoveragePlanItem coveragePlanItem)
        {
            _context.CoveragePlans.Remove(coveragePlanItem);
            _context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void EditRate(RateChartItem rateChartItem)
        {

            _context.Entry(rateChartItem).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveRate(RateChartItem rateChartItem)
        {
            _context.RateCharts.Add(rateChartItem);
            _context.SaveChanges();
        }

        public void DeleteRate(RateChartItem rateChartItem)
        {

            _context.RateCharts.Remove(rateChartItem);
            _context.SaveChanges();

        }
    }
}