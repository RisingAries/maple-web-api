
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class CoveragePlanItem
{
    public long Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime EligibilityDateFrom { get; set; }

    [DataType(DataType.Date)]
    public DateTime EligibilityDateTo { get; set; }
    public Country EligibilityCountry { get; set; }



}