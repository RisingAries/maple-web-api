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

        CoveragePlanItem IInsuranceInfoRepository.GetCoveragePlan(int Id)
        {
            return this._context.CoveragePlans.Find(Id);
        }

        IEnumerable<CoveragePlanItem> IInsuranceInfoRepository.GetCoveragePlans()
        {
            return this._context.CoveragePlans.ToList();
        }

        Customer IInsuranceInfoRepository.GetCustomer(int Id)
        {
            return this._context.Customers.Find(Id);
        }

        RateChartItem IInsuranceInfoRepository.GetRate(int Id)
        {
            return this._context.RateCharts.Find(Id);
        }

        IEnumerable<RateChartItem> IInsuranceInfoRepository.GetRates()
        {
            return this._context.RateCharts.ToList();
        }
        Customer IInsuranceInfoRepository.GetCustomerByName(string CustomerName)
        {
            return this._context.Customers.Where(c => c.Name == CustomerName).FirstOrDefault();
        }

        CoveragePlanItem IInsuranceInfoRepository.GetCoveragePlan(Country country, System.DateTime DOB)
        {
            return this._context.CoveragePlans.Where(cp =>
               cp.EligibilityCountry == country &&
               cp.EligibilityDateFrom < DOB &&
               cp.EligibilityDateTo > DOB).FirstOrDefault();
        }

        RateChartItem IInsuranceInfoRepository.GetRate(Gender cgender, int age, CoveragePlanItem planType)
        {
            return this._context.RateCharts.Where(ch =>
             ch.Gender == cgender
             && ch.CuttoffAge > age &&
            ch.CoveragePlan.PlanId == planType.PlanId).FirstOrDefault();
        }

        void IInsuranceInfoRepository.EditContract(ContractItem contractItem)
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

        void IInsuranceInfoRepository.SaveContract(ContractItem contractItem)
        {

            _context.ContractItems.Add(contractItem);
            _context.SaveChanges();
        }

        void IInsuranceInfoRepository.DeleteContract(ContractItem contractItem)
        {
            _context.ContractItems.Remove(contractItem);
            _context.SaveChanges();

        }
    }
}