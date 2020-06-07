
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class CoveragePlanItem
{
    [Key]
    public int PlanId { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Eligibility Date From is required")]
    public DateTime EligibilityDateFrom { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Eligibility Date To is required")]
    public DateTime EligibilityDateTo { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public Country EligibilityCountry { get; set; }



}