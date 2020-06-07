using System;
using System.ComponentModel.DataAnnotations;

public class ContractItem
{
    public long Id { get; set; }
    public Customer Customer { get; set; }

    [DataType(DataType.Date)]
    public DateTime SaleDate { get; set; }

    public CoveragePlanItem CoveragePlan { get; set; }

    public double NetPrice { get; set; }
}