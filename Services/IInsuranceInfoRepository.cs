using System;
using System.Collections.Generic;

namespace maple_web_api.Services
{
    public interface IInsuranceInfoRepository
    {
        IEnumerable<ContractItem> GetContracts();

        ContractItem GetContract(int Id);

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(int Id);
        Customer GetCustomerByName(string CustomerName);
        IEnumerable<CoveragePlanItem> GetCoveragePlans();

        CoveragePlanItem GetCoveragePlan(int Id);

        IEnumerable<RateChartItem> GetRates();

        RateChartItem GetRate(int Id);

        CoveragePlanItem GetCoveragePlan(Country country, DateTime DOB);

        RateChartItem GetRate(Gender cgender, int age, CoveragePlanItem planType);

        void EditContract(ContractItem contractItem);

        void SaveContract(ContractItem contractItem);

        void DeleteContract(ContractItem contractItem);
    }
}