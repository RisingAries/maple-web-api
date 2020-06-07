
using System;
using System.ComponentModel.DataAnnotations;

public class CoveragePlanItem
{
    public long Id { get; set; }
    public CoveragePlanItem CoveragePlan { get; set; }

    [DataType(DataType.Date)]
    public DateTime EligibilityDateFrom { get; set; }

    [DataType(DataType.Date)]
    public DateTime EligibilityDateTo { get; set; }
    public Country EligibilityCountry { get; set; }
}